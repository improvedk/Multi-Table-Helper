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
	/// A class used for manipulating Win32 treeviews
	/// </summary>
	public class TreeviewManipulation
	{
		private readonly int handle;

		/// <summary>
		/// Constructor, takes a handle to the treeview
		/// </summary>
		/// <param name="handle"></param>
		public TreeviewManipulation(int handle)
		{
			// Set our handle
			this.handle = handle;
		}

		/// <summary>
		/// Selects (clicks) the specified item
		/// </summary>
		/// <param name="hWnd"></param>
		public void SelectItem(int hWnd)
		{
			Win32.PostMessage(handle, (int)Win32.TVM.SELECTITEM, (int)Win32.TVGN.CARET, hWnd);
		}

		/// <summary>
		/// Loops all items through, looking for the specified text
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public int GetItemByText(string text)
		{
			int root = GetRootItem();

			if(root != 0)
			{
				// If the root's text is what we want, return the root
				if(GetItemText(root) == text)
					return root;

				// Loop through all items until we find the desired item
				int item = root;
				
				// Check if text matches, return if it does
				while((item = GetNextItem(item)) != 0)
					if(GetItemText(item) == text)
						return item;

				// No item has been found, return 0
				return 0;
			}
			else
			{
				// There isn't any root element, return 0
				return 0;
			}
		}

		/// <summary>
		/// Returns a handle to the previous item (sibling or parent)
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetPreviousItem(int hWnd)
		{
			// Get sibling
			int sibling = GetPreviousSiblingItem(hWnd);

			if(sibling != 0)
			{
				// If a sibling exists, check if it has children
				int siblingChild = GetChildItem(sibling);

				// If the sibling has children, find the last item before the specified item, otherwise just return the sibling
				if(siblingChild != 0)
				{
					int intNext;
					int intPrevious = siblingChild;

					// Continue going forward until we hit our specified item
					while((intNext = GetNextItem(intPrevious)) != hWnd)
						intPrevious = intNext;

					// Return the item just before
					return intPrevious;
				}
				else
					return sibling;
			}
			else
			{
				// If a sibling doesn't exist, return the parent
				return GetParentItem(hWnd);
			}
		}

		/// <summary>
		/// Returns a handle to the next item (child or sibling, or next sibling to parent item)
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetNextItem(int hWnd)
		{
			// Get child
			int child = GetChildItem(hWnd);

			// If a child exists, return it
			if(child != 0)
				return child;
			else
			{
				// If child doesn't exist, return next sibling
				int nextSibling = GetNextSiblingItem(hWnd);

				// If a sibling exists, return it
				if(nextSibling != 0)
					return nextSibling;
				else
				{
					// If a sibling doesn't exist, look for siblings of parent items
					int parent = GetParentItem(hWnd);

					while(GetNextSiblingItem(parent) == 0 && parent != 0)
						parent = GetParentItem(parent);

					return GetNextSiblingItem(parent);
				}
			}
		}

		/// <summary>
		/// Returns a handle to the previous sibling to the specified item
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetPreviousSiblingItem(int hWnd)
		{
			return (int)Win32.SendMessage((IntPtr)handle, (int)Win32.TVM.GETNEXTITEM, (int)Win32.TVGN.PREVIOUS, (IntPtr)hWnd);
		}

		/// <summary>
		/// Returns a handle to the next sibling to the specified item
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetNextSiblingItem(int hWnd)
		{
			return (int)Win32.SendMessage((IntPtr)handle, (int)Win32.TVM.GETNEXTITEM, (int)Win32.TVGN.NEXT, (IntPtr)hWnd);
		}

		/// <summary>
		/// Returns the handle to the child after the specified item
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetChildItem(int hWnd)
		{
			return (int)Win32.SendMessage((IntPtr)handle, (int)Win32.TVM.GETNEXTITEM, (int)Win32.TVGN.CHILD, (IntPtr)hWnd);
		}

		/// <summary>
		/// Returns the handle to the parent of the specified item
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetParentItem(int hWnd)
		{
			return (int)Win32.SendMessage((IntPtr)handle, (int)Win32.TVM.GETNEXTITEM, (int)Win32.TVGN.PARENT, (IntPtr)hWnd);
		}

		/// <summary>
		/// Returns the handle to the root item in a treeview control
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		public int GetRootItem()
		{
			return Win32.SendMessage(handle, (int)Win32.TVM.GETNEXTITEM, (int)Win32.TVGN.ROOT, 0);
		}

		/// <summary>
		/// Returns the handle to the currently selected item
		/// </summary>
		public int GetSelectedItem()
		{
			return (int)Win32.SendMessage((System.IntPtr)handle, (int)Win32.TVM.GETNEXTITEM, (int)Win32.TVGN.CARET, IntPtr.Zero);
		}

		/// <summary>
		/// Returns the text for a specific item
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		public string GetItemText(int itemHwnd)
		{
			const int dwBufferSize = 1024;
          
			int				dwProcessID;
			Win32.TVITEM    tvItem;      
			string			retval;
			bool			bSuccess;
			IntPtr			hProcess        = IntPtr.Zero;
			IntPtr			lpRemoteBuffer  = IntPtr.Zero;
			IntPtr			lpLocalBuffer   = IntPtr.Zero;
			IntPtr			threadId        = IntPtr.Zero;

			try
			{
				tvItem = new Win32.TVITEM();

				// Allocate a buffer in the local process
				lpLocalBuffer = Marshal.AllocHGlobal(dwBufferSize);

				// Get the process id owning the treeview
				threadId = Win32.GetWindowThreadProcessId(handle, out dwProcessID);
				if((threadId == IntPtr.Zero) || (dwProcessID == 0))
					throw new ArgumentException("Could not found thread process id");

				// Open the process with all access
				hProcess = Win32.OpenProcess(Win32.PROCESS_ALL_ACCESS, false, dwProcessID);
				if(hProcess == IntPtr.Zero)
					throw new ApplicationException("Failed to access process");

				// Allocate a buffer in the remote process
				lpRemoteBuffer = Win32.VirtualAllocEx(hProcess, IntPtr.Zero, dwBufferSize, Win32.MEM_COMMIT, Win32.PAGE_READWRITE);
				if(lpRemoteBuffer == IntPtr.Zero)
					throw new SystemException("Failed to allocate memory in remote process");
      
				// Fill in the TVITEM struct, this is in your own process
				// Set the pszText member to somewhere in the remote buffer,
				// In this case we use the address imediately following the TVITEM stuct
				tvItem.mask = ((int)Win32.TVIF.TEXT | (int)Win32.TVIF.HANDLE);
				tvItem.hItem = itemHwnd;
				tvItem.pszText = (IntPtr)(lpRemoteBuffer.ToInt32() + Marshal.SizeOf(typeof(Win32.TVITEM)));
				tvItem.cchTextMax = 1024;

				// Copy the local LVITEM to the remote buffer
				bSuccess = Win32.WriteProcessMemory(hProcess, lpRemoteBuffer, ref tvItem, Marshal.SizeOf(typeof(Win32.TVITEM)), IntPtr.Zero);
				if(!bSuccess)
					throw new SystemException("Failed to write to process memory");

				// Send the message to the remote window with the address of the remote buffer
				Win32.SendMessage((System.IntPtr)handle, (int)Win32.TVM.GETITEM, itemHwnd, lpRemoteBuffer);
      
				// Read the struct back from the remote process into local buffer
				bSuccess = Win32.ReadProcessMemory(hProcess, lpRemoteBuffer, lpLocalBuffer, dwBufferSize, IntPtr.Zero);
				if(!bSuccess)
					throw new SystemException("Failed to read from process memory");
      
				// At this point the lpLocalBuffer contains the returned LV_ITEM structure
				// the next line extracts the text from the buffer into a managed string
				retval = Marshal.PtrToStringAuto((IntPtr)(lpLocalBuffer.ToInt32() + Marshal.SizeOf(typeof(Win32.TVITEM))));
			}
			catch (Exception e)
			{
				// If an exception occurred, return the error string
				retval = e.Message;
			}
			finally
			{ 
				// Make sure to clean up memory buffers!
				if(lpLocalBuffer != IntPtr.Zero)
					Marshal.FreeHGlobal( lpLocalBuffer );
				if(lpRemoteBuffer != IntPtr.Zero)
					Win32.VirtualFreeEx(hProcess, lpRemoteBuffer, 0, Win32.MEM_RELEASE); 
				if( hProcess != IntPtr.Zero )
					Win32.CloseHandle(hProcess);
			}

			// Return what we found
			return retval;
		}
		
		/// <summary>
        	/// Returns the checked status for a specific item
        	/// </summary>
        	/// <param name="hwnd"></param>
        	/// <param name="checked"></param>
        	/// <returns></returns>
        	public bool GetItemIsChecked(int itemHwnd)
        	{
            	Win32.TVITEM tvItem = new Win32.TVITEM
            	{
                	mask = (int)Win32.TVIF.TEXT,
                	hItem = itemHwnd
            	};

            	Win32.SendMessage(handle, (int)Win32.TVM.GETITEM, 0, tvItem);
            	return (tvItem.state & (int)Win32.TVIF.CHECKED) == (int)Win32.TVIF.CHECKED;
        	}
	}
}
