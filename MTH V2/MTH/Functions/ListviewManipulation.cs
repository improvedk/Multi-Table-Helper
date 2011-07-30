using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace MTH
{
	/// <summary>
	/// A class used for manipulating Win32 listview
	/// </summary>
	public class ListviewManipulation
	{
		private int handle;

		/// <summary>
		/// Constructor, takes a handle to the listview
		/// </summary>
		/// <param name="handle"></param>
		public ListviewManipulation(int handle)
		{
			// Set our handle
			this.handle = handle;
		}

		/// <summary>
		/// Returns the amount of items in the listview
		/// </summary>
		public int GetItemCount()
		{
			return (int)Win32.SendMessage((System.IntPtr)handle, (int)Win32.LVM.GETITEMCOUNT, 0, IntPtr.Zero);
		}

		/// <summary>
		/// Loops through all items in the listview forcing them to redraw
		/// </summary>
		public void Redraw()
		{
			for(int i=0; i<GetItemCount(); i++)
				Win32.PostMessage(handle, (int)Win32.LVM.UPDATE, i, 0);
		}

		/// <summary>
		/// Selects a row at the specified index
		/// </summary>
		/// <param name="index"></param>
		public void SelectItem(int index)
		{
			const int dwBufferSize = 1024;
          
			int				dwProcessID;
			Win32.LVITEM    lvItem;      
			bool			bSuccess;
			IntPtr			hProcess        = IntPtr.Zero;
			IntPtr			lpRemoteBuffer  = IntPtr.Zero;
			IntPtr			lpLocalBuffer   = IntPtr.Zero;
			IntPtr			threadID        = IntPtr.Zero;

			try
			{
				lvItem = new Win32.LVITEM();
				lpLocalBuffer = Marshal.AllocHGlobal(dwBufferSize);

				// Get the process ID
				threadID = Win32.GetWindowThreadProcessId(handle, out dwProcessID);
				if(threadID == IntPtr.Zero || dwProcessID == 0)
					throw new ArgumentException("Could not get remote process thread id");

				// Open the process with all access
				hProcess = Win32.OpenProcess(Win32.PROCESS_ALL_ACCESS, false, dwProcessID);
				if(hProcess == IntPtr.Zero)
					throw new ApplicationException("Failed to open remote process");

				// Allocate a buffer in the remote process
				lpRemoteBuffer = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, dwBufferSize, Win32.MEM_COMMIT, Win32.PAGE_READWRITE);
				if(lpRemoteBuffer == IntPtr.Zero)
					throw new SystemException("Failed to allocate memory in the remote process");

				// Fill in the local LVITEM struct, set the selected state flag
				lvItem.state = ((int)Win32.LVIS.SELECTED | (int)Win32.LVIS.FOCUSED);
				lvItem.stateMask = ((int)Win32.LVIS.SELECTED | (int)Win32.LVIS.FOCUSED);

				// Copy the local LVITEM struct to the remote buffer
				bSuccess = Win32.WriteProcessMemory(hProcess, lpRemoteBuffer, ref lvItem, Marshal.SizeOf(typeof(Win32.LVITEM)), IntPtr.Zero);
				if(!bSuccess)
					throw new SystemException("Failed to write to remote process memory");

				// Send a message to the listview with the address of the remote buffer
				Win32.SendMessage((IntPtr)handle, (int)Win32.LVM.SETITEMSTATE, index, lpRemoteBuffer);
				Win32.SendMessage((IntPtr)handle, (int)Win32.LVM.ENSUREVISIBLE, index, IntPtr.Zero);

				// Read the struct back from the remote process into the local buffer
				bSuccess = Win32.ReadProcessMemory(hProcess, lpRemoteBuffer, lpLocalBuffer, dwBufferSize, IntPtr.Zero);
				if(!bSuccess)
					throw new SystemException("Failed to read from remote process memory");
			}
			finally
			{
				if(lpLocalBuffer != IntPtr.Zero)
					Marshal.FreeHGlobal( lpLocalBuffer);
				if(lpRemoteBuffer != IntPtr.Zero)
					Win32.VirtualFreeEx( hProcess, lpRemoteBuffer, 0, Win32.MEM_RELEASE); 
				if(hProcess != IntPtr.Zero)
					Win32.CloseHandle( hProcess);
			}
		}

		/// <summary>
		/// Returns the text for a specified item index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public string GetItemText(int index, int columnIndex)
		{
			const int dwBufferSize = 1024;
          
			int				dwProcessID;
			Win32.LVITEM    lvItem;      
			string			retval;
			bool			bSuccess;
			IntPtr			hProcess        = IntPtr.Zero;
			IntPtr			lpRemoteBuffer  = IntPtr.Zero;
			IntPtr			lpLocalBuffer   = IntPtr.Zero;
			IntPtr			threadID        = IntPtr.Zero;
			
			try
			{
				lvItem = new Win32.LVITEM();
				lpLocalBuffer = Marshal.AllocHGlobal(dwBufferSize);

				// Get the process ID
				threadID = Win32.GetWindowThreadProcessId(handle, out dwProcessID);
				if(threadID == IntPtr.Zero || dwProcessID == 0)
					throw new ArgumentException("Could not get remote process thread id");

				// Open the process with all access
				hProcess = Win32.OpenProcess(Win32.PROCESS_ALL_ACCESS, false, dwProcessID);
				if(hProcess == IntPtr.Zero)
					throw new ApplicationException("Failed to open remote process");

				// Allocate a buffer in the remote process
				lpRemoteBuffer = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, dwBufferSize, Win32.MEM_COMMIT, Win32.PAGE_READWRITE);
				if(lpRemoteBuffer == IntPtr.Zero)
					throw new SystemException("Failed to allocate memory in the remote process");

				// Fill in the LVITEM struct in our own process
				// Set the pszText member to somewhere in the remote buffer, in this case immediatly following the LVITEM struct
				lvItem.iSubItem = columnIndex;
				lvItem.pszText = (IntPtr)(lpRemoteBuffer.ToInt32() + Marshal.SizeOf(typeof(Win32.LVITEM)));
				lvItem.cchTextMax = 1024;

				// Copy the local LVITEM struct to the remote buffer
				bSuccess = Win32.WriteProcessMemory(hProcess, lpRemoteBuffer, ref lvItem, Marshal.SizeOf(typeof(Win32.LVITEM)), IntPtr.Zero);
				if(!bSuccess)
					throw new SystemException("Failed to write to remote process memory");

				// Send a GETITEMTEXT message to the remote process, containing the address of the remote buffer
				Win32.SendMessage((IntPtr)handle, (int)Win32.LVM.GETITEMTEXT, index, lpRemoteBuffer);

				// Read the struct back from the remote process into the local buffer
				bSuccess = Win32.ReadProcessMemory(hProcess, lpRemoteBuffer, lpLocalBuffer, dwBufferSize, IntPtr.Zero);
				if(!bSuccess)
					throw new SystemException("Failed to read from remote process memory");

				// At this point the lpLocalBuffer contains the returned LVITEM structure
				// Now we can extract the text from the buffer
				retval = Marshal.PtrToStringAnsi((IntPtr)(lpLocalBuffer.ToInt32() + Marshal.SizeOf(typeof(Win32.LVITEM))));

			}
			catch(Exception e)
			{
				retval = e.Message;
			}
			finally
			{
				if(lpLocalBuffer != IntPtr.Zero)
					Marshal.FreeHGlobal(lpLocalBuffer);
				if(lpRemoteBuffer != IntPtr.Zero)
					Win32.VirtualFreeEx(hProcess, lpRemoteBuffer, 0, Win32.MEM_RELEASE); 
				if(hProcess != IntPtr.Zero)
					Win32.CloseHandle(hProcess);
			}

			return retval;
		}
	}
}