/*	 
	Copyright 2007 Mark S. Rasmussen - www.improve.dk

    This file is part of Multi Table Helper.

    Multi Table Helper is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Multi Table Helper is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using MTH.Framework;

namespace MTH.Core
{
	public class UserActivityHook : object 
	{
		public UserActivityHook() 
		{
			Start();
		}
		
		~UserActivityHook() 
		{ 
			Stop();
		} 

		public event KeyEventHandler KeyDown;
		public event KeyPressEventHandler KeyPress;
		public event KeyEventHandler KeyUp;

		public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

		static int hKeyboardHook = 0; //Declare keyboard hook handle as int.
		public const int WH_KEYBOARD_LL = 13;	//keyboard hook constant	

		HookProc KeyboardHookProcedure; //Declare KeyboardHookProcedure as HookProc type.
			

		//Declare wrapper managed POINT class.
		[StructLayout(LayoutKind.Sequential)]
		public class POINT 
		{
			public int x;
			public int y;
		}

		//Declare wrapper managed KeyboardHookStruct class.
		[StructLayout(LayoutKind.Sequential)]
		public class KeyboardHookStruct
		{
			public int vkCode;	//Specifies a virtual-key code. The code must be a value in the range 1 to 254. 
			public int scanCode; // Specifies a hardware scan code for the key. 
			public int flags;  // Specifies the extended-key flag, event-injected flag, context code, and transition-state flag.
			public int time; // Specifies the time stamp for this message.
			public int dwExtraInfo; // Specifies extra information associated with the message. 
		}


		//Import for SetWindowsHookEx function.
		//Use this function to install a hook.
		[DllImport("user32.dll",CharSet=CharSet.Auto,
		CallingConvention=CallingConvention.StdCall)]
		public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

		//Import for UnhookWindowsHookEx.
		//Call this function to uninstall the hook.
		[DllImport("user32.dll",CharSet=CharSet.Auto,
		CallingConvention=CallingConvention.StdCall)]
		public static extern bool UnhookWindowsHookEx(int idHook);
		
		//Import for CallNextHookEx.
		//Use this function to pass the hook information to next hook procedure in chain.
		[DllImport("user32.dll",CharSet=CharSet.Auto,
		CallingConvention=CallingConvention.StdCall)]
		public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);  

		public void Start()
		{
            // install Keyboard hook 
			if(hKeyboardHook == 0)
			{
				KeyboardHookProcedure = new HookProc(KeyboardHookProc);
				hKeyboardHook = SetWindowsHookEx( WH_KEYBOARD_LL, KeyboardHookProcedure, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);

				//If SetWindowsHookEx fails.
				if(hKeyboardHook == 0 )	
				{
					Stop();
					throw new Exception("SetWindowsHookEx ist failed.");
				}
			}
		}

		public void Stop()
		{
			bool retKeyboard = true;
			
			if(hKeyboardHook != 0)
			{
				retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
				hKeyboardHook = 0;
			} 
			
			//If UnhookWindowsHookEx fails.
			if (!retKeyboard)
				throw new Exception("UnhookWindowsHookEx failed.");
		}


		//The ToAscii function translates the specified virtual-key code and keyboard state to the corresponding character or characters. The function translates the code using the input language and physical keyboard layout identified by the keyboard layout handle.
		[DllImport("user32")] 
		public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

		//The GetKeyboardState function copies the status of the 256 virtual keys to the specified buffer. 
		[DllImport("user32")] 
		public static extern int GetKeyboardState(byte[] pbKeyState);

		private const int WM_KEYDOWN 		= 0x100;
		private const int WM_KEYUP 			= 0x101;
		private const int WM_SYSKEYDOWN 	= 0x104;
		private const int WM_SYSKEYUP 		= 0x105;

		private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
		{
			// it was ok and someone listens to events
			if ((nCode >= 0) && (KeyDown!=null || KeyUp!=null || KeyPress!=null))
			{
				KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct) Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
				
				if ( KeyDown!=null && ( wParam ==WM_KEYDOWN || wParam==WM_SYSKEYDOWN ))
				{
					Keys keyData=(Keys)MyKeyboardHookStruct.vkCode;
					
					if ((Win32.GetKeyState((int)Win32.VK.LSHIFT) & 0x8000) != 0)
						keyData |= Keys.Shift;
					if ((Win32.GetKeyState((int)Win32.VK.RSHIFT) & 0x8000) != 0)
						keyData |= Keys.Shift;
					
					KeyEventArgs e = new KeyEventArgs(keyData);
					KeyDown(this, e);
				}
				
				// raise KeyPress
				if ( KeyPress!=null &&  wParam ==WM_KEYDOWN )
				{
					byte[] keyState = new byte[256];
					GetKeyboardState(keyState);

					byte[] inBuffer= new byte[2];
					if (ToAscii(MyKeyboardHookStruct.vkCode, MyKeyboardHookStruct.scanCode, keyState, inBuffer, MyKeyboardHookStruct.flags) == 1) 
					{
						KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
						KeyPress(this, e);
					}
				}
				
				// raise KeyUp
				if ( KeyUp!=null && ( wParam ==WM_KEYUP || wParam==WM_SYSKEYUP ))
				{
					Keys keyData=(Keys)MyKeyboardHookStruct.vkCode;
					KeyEventArgs e = new KeyEventArgs(keyData);
					KeyUp(this, e);
				}

			}

			return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam); 
		}
	}
}