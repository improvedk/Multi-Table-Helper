using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace MTH
{
	/// <summary>
	/// Summary description for Win32.
	/// </summary>
	public abstract class Win32
	{
		public const uint PROCESS_ALL_ACCESS = (uint)(0x000F0000L | 0x00100000L | 0xFFF);
		public const uint MEM_COMMIT = 0x1000;
		public const uint MEM_RELEASE = 0x8000;
		public const uint PAGE_READWRITE = 0x04;
		public const uint VK_CAPITAL = 20;
		public const uint VK_NUMLOCK = 144;
		public const int MAXWAIT = 10000; // 10 seconds
		public const uint WAIT_TIMEOUT = 258;
        public const long GWL_WNDPROC = -4;
        public const long SPY_ADDCAPTURE = 0x0011;
        public const long SPY_REMOVECAPTURE = 0x0012;
		private char[] kbArray = new char[256];
		public const int SRCCOPY = 13369376;

		[DllImport ("User32.dll")]
		public extern static bool PrintWindow (IntPtr hWnd, IntPtr dc, uint reservedFlag);

		[DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
		public static extern IntPtr DeleteObject(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint = "SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

		[DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
		public static extern IntPtr DeleteDC(IntPtr hDc);

		[DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		[DllImport("user32.dll")]
		public static extern long IsWindow(long hwnd);

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

		[DllImport("Kernel32.dll")]
		public static extern int WriteProcessMemory(int hProcess, int lpBaseAddress, ref string lpBuffer, int nSize, int lpNumberOfBytesWritten);

		[DllImport("Kernel32.dll")]
        public static extern int WaitForSingleObject(int hHandle, int dwMilliseconds);

		[DllImport("Kernel32.dll")]
		public static extern long GetTickCount();

		[DllImport("user32.dll")]
		public static extern long DefWindowProc(int hwnd, int wMsg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern long DestroyWindow(long hwnd);

		[DllImport("user32.dll")]
		public static extern long CallWindowProc(long lpPrevWndFunc, long hwnd, long msg, long wParam, long lParam);

		[DllImport("Kernel32.dll")]
		public static extern void Sleep(int dwMilliseconds);

		[DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
		public static extern void CopyMemory(object destination, object source, long length);

        [DllImport("Kernel32.dll")]
        public static extern int WaitForSingleObject(long hHandle, int dwMilliseconds);

        [DllImport("user32.dll")]
        public static extern int CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int hMenu, int hInstance, string lpParam);

		[DllImport("Kernel32.dll")]
        public static extern int CreateRemoteThread(int hProcess, int lpThreadAttributes, int dwStackSize, int lpStartAddress, int lpParameter, int dwCreationFlags, int lpThreadID);

        [DllImport("user32.dll")]
        public static extern long SetWindowLong(long hwnd, long nIndex, long dwNewLong);

		[DllImport("Kernel32.dll", EntryPoint = "GetModuleHandleA")]
		public static extern int GetModuleHandle(string lpModuleName);

		[DllImport("Kernel32.dll")]
        public static extern int GetProcAddress(int hModule, string lpProcName);

		public static int GetControlIDFromHwnd(int hwnd)
		{
			return (int)Win32.GetLowWord(Win32.GetWindowLong(hwnd, -12));
		}

        [DllImport("Kernel32.dll")]
        public static extern int GetProcAddress(long hModule, string lpProcName);

		[DllImport("User32.dll")]
		public static extern int GeyKeyState(int virtKey);

		[DllImport("user32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

		[DllImport("User32.dll")]
		public static extern int GetKeyboardState(ref char[] kbArray);

		[DllImport("User32.dll")]
		public static extern int SetKeyboardState(ref char[] kbArray);

		public static int GetLowWord(int input)
		{
			return (input << 16) >> 16;
		}

		public static int GetHighWord(int input)
		{
			return input >> 16;
		}

		public static long GetLowWord(long input)
		{
			return (input << 32) >> 32;
		}

		public static long GetHighWord(long input)
		{
			return input >> 32;
		}

		public static bool CapsLock()
		{
			return Convert.ToBoolean(GetKeyState((int)VK.CAPITAL));
		}

		public static bool NumLock()
		{
			return Convert.ToBoolean(GetKeyState((int)VK.NUMLOCK));
		}

        public static void SendLeftClick()
        {
            mouse_event(2, 0, 0, 0, new System.IntPtr());
            mouse_event(4, 0, 0, 0, new System.IntPtr());
        }

		[DllImport("kernel32")]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32")]
		public static extern IntPtr VirtualAllocEx(long hProcess, int lpAddress, int dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32")]
		public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, int dwSize, uint dwFreeType);

		[DllImport("kernel32")]
		public static extern bool WriteProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, 
			ref TVITEM buffer, int dwSize, IntPtr lpNumberOfBytesWritten );

		[DllImport("kernel32")]
		public static extern bool WriteProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, 
			ref LVITEM buffer, int dwSize, IntPtr lpNumberOfBytesWritten );

		[DllImport("kernel32")]
		public static extern bool ReadProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, 
			IntPtr lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead );

		[DllImport("kernel32")]
        public static extern bool CloseHandle(IntPtr hObject);

		[DllImport("kernel32")]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        public static void CloseWindow(int hWnd)
        {
            Win32.PostMessage(hWnd, (int)WM.SYSCOMMAND, (int)SC.CLOSE, 0);
        }

		[StructLayout(LayoutKind.Sequential)]
		public struct TVITEM
		{
			public int mask;
			public int hItem;
			public int state;
			public int stateMask;
			public IntPtr pszText;
			public int cchTextMax;
			public int iImage;
			public int iSelectedImage;
			public int cChildren;
			public IntPtr lParam;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct LVITEM
		{
			public uint   mask; 
			public int    iItem; 
			public int    iSubItem; 
			public uint   state; 
			public uint   stateMask; 
			public IntPtr pszText; 
			public int    cchTextMax; 
			public int    iImage;
			public IntPtr lParam;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct LVFINDINFO
		{
			public LVFI_FLAGS flags;
			public string psz;
			public IntPtr lParam;
			public Point pt;
			public VK vkDirection ;
		} 

		[StructLayout(LayoutKind.Sequential)]
		public struct lv_col_type
		{
			public LVColTypes type;
			public bool sort_disabled;
			public bool case_sensitive;
			public bool unidirectional;
			public bool prefer_descending;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct LV_SortType
		{
			public LVFINDINFO lvfi;
			public LVITEM lvi;
			public IntPtr hwnd;
			public lv_col_type col;
			public char[] buf1;
			public char[] buf2;
			public bool sort_ascending;
			public bool incoming_is_index;
		}
		
		[DllImport("user32")]
		public static extern IntPtr GetWindowThreadProcessId(Int32 hWnd, out Int32 lpdwProcessId);

		[DllImport("user32")]
		public static extern IntPtr GetWindowThreadProcessId(long hWnd, out long lpdwProcessId);

		public static Int32 GetWindowProcessID(Int32 hwnd)
		{
			Int32 pid = 1;
			GetWindowThreadProcessId(hwnd, out pid);
			return pid;
		}

		[DllImport("User32.dll")]
		public static extern int FindWindow(string strClassName, string strWindowName);

		[DllImport("User32.dll")]
		public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);

		[DllImport("User32.dll")]
		public static extern int FindWindowEx(long hwndParent, long hwndChildAfter, string strClassName, string strWindowName);

		[DllImport("User32.dll")]
		public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam); 
		
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, IntPtr lParam);
		
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref TVITEM tvItem);
		
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref LVITEM lvItem);
		
		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, ref Rectangle rect);

		[DllImport("user32.dll")]
		public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, bool wParam, ref Rectangle rect);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll")]
		public static extern bool BringWindowToTop(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(int hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetWindowDC(IntPtr Hwnd);

		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr windowHwnd, IntPtr hdcHwnd);

		[DllImport("user32.dll")]
		public static extern IntPtr GetShellWindow();

		[DllImport("gdi32.dll")]
		public static extern bool BitBlt(
			IntPtr hdcDest, // handle to destination DC
			int nXDest, // x-coord of destination upper-left corner
			int nYDest, // y-coord of destination upper-left corner
			int nWidth, // width of destination rectangle
			int nHeight, // height of destination rectangle
			IntPtr hdcSrc, // handle to source DC
			int nXSrc, // x-coordinate of source upper-left corner
			int nYSrc, // y-coordinate of source upper-left corner
			System.Int32 dwRop // raster operation code
			);

		[DllImport("user32.dll")]
		public static extern int UpdateWindow(IntPtr hwnd);

		[DllImport("user32")]
		public static extern bool InvalidateRect(int h, ref Rectangle rect, bool b);

        [DllImport("user32.dll")]
        public static extern IntPtr GetParent(int hWnd);

		[System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
		public static extern IntPtr CreateDC(
			  string lpszDriver,        // driver name
			  string lpszDevice,        // device name
			  string lpszOutput,        // not used; should be NULL
			 IntPtr lpInitData	// optional printer data
				  );

		//Overload for string lParam (e.g. WM_GETTEXT)
		[DllImport("user32.dll")]
		public static extern Int32 SendMessage(int hWnd, int Msg, int wParam,    
			[Out] StringBuilder lParam);

		[DllImport("user32.dll")]
		public static extern Int32 SendMessage(int hWnd, int Msg, int wParam,    
			TVITEM tvi);

		[DllImport("User32.dll")]
		public static extern Int32 SendMessage(
			int hWnd,               // handle to destination window
			int Msg,                // message
			int wParam,             // first message parameter
			int lParam);            // second message parameter

		[DllImport("User32.dll")] 
		public static extern int GetWindowText(
			int hWnd,
			StringBuilder text,
			int count); 

		[DllImport("user32.dll", EntryPoint = "SetWindowPos")]
		public static extern bool SetWindowPos(
			int hWnd,               // window handle
			int hWndInsertAfter,    // placement-order handle
			int X,                  // horizontal position
			int Y,                  // vertical position
			int cx,                 // width
			int cy,                 // height
			uint uFlags);           // window positioning flags

		[StructLayout(LayoutKind.Sequential)]
		private struct WINDOWPLACEMENT
		{
			internal int Length;
			internal int flags;
			internal int showCmd;
			internal Point ptMinPosition;
			internal Point ptMaxPosition;
			internal Rectangle rcNormalPosition;
		}

		public static void PostLeftClick(int x, int y, int hwnd)
		{
            PostMessage(hwnd, 0x201, 0x0001, ((y << 16) ^ x));
			PostMessage(hwnd, 0x202, 0, ((y << 16) ^ x));
        }

		[DllImport("user32.dll")]
		private static extern int GetWindowPlacement(int hwnd, ref WINDOWPLACEMENT lpwndpl);

		[DllImport("user32.dll")]
		private static extern int SetWindowPlacement(int hwnd, ref WINDOWPLACEMENT lpwndpl);

		public static void MinimizeWindow(int hWnd)
		{
			WINDOWPLACEMENT newWinPlace = new WINDOWPLACEMENT();
			GetWindowPlacement(hWnd, ref newWinPlace);
			newWinPlace.showCmd = (int)SW.MINIMIZE;
			newWinPlace.Length = Marshal.SizeOf(newWinPlace);
			SetWindowPlacement(hWnd, ref newWinPlace); 
		}

		[DllImport("user32.dll")]
		public static extern bool RedrawWindow(IntPtr hWnd, ref Rectangle lprcUpdate, IntPtr hrgnUpdate, uint flags);

		[DllImport("User32.Dll")]
		public static extern void GetClassName(int h, StringBuilder s, int nMaxCount);
		
		[DllImport("User32.Dll")]
		public static extern IntPtr PostMessage(int hWnd, int msg, int wParam, int lParam);

		[DllImport("User32.Dll")]
		public static extern IntPtr PostMessage(int hWnd, int msg, int wParam, string lParam);

		[DllImport("user32.dll")]
		public static extern bool UnhookWindowsHookEx(IntPtr hhk);

		[DllImport("User32.dll")]
		public static extern Boolean IsWindowVisible(int hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern long GetWindowRect(int hWnd, ref Rectangle lpRect);

		[DllImport("user32.dll")]
		public static extern long GetClientRect(int hWnd, ref Rectangle lpRect);

		[DllImport("user32.dll")]
		public static extern long SetFocus(int hWnd);

		[DllImport("user32.dll")]
		public static extern short GetKeyState(int nVirtKey);
		
		[DllImport("user32.dll")]
		public static extern long SetForegroundWindow(int hWnd);
		
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(int hWnd, int cmd);

		public static void SetText(int hWnd, string text)
		{
			SendMessage(hWnd, (int)WM.SETTEXT, 0, text);
		}

		public static int GetTextLength(int hWnd)
		{
			return SendMessage(hWnd, (int)WM.GETTEXTLENGTH, 0, 0);
		}

		public static string GetText(int hWnd)
		{
			int txtLength = SendMessage(hWnd, (int)WM.GETTEXTLENGTH, 0, 0);

			StringBuilder sb = new StringBuilder(txtLength + 1);
			SendMessage(hWnd, (int)WM.GETTEXT, sb.Capacity, sb);

			return sb.ToString();
		}

		public static void ClickButton(int hWnd)
		{
			Win32.PostMessage(hWnd, (int)WM.LBUTTONDOWN, 0, 0);
			Win32.PostMessage(hWnd, (int)WM.LBUTTONUP, 0, 0);
		}

		public enum SW : int
		{
			HIDE = 0,
			SHOWNORMAL = 1,
			SHOWMINIMIZED = 2,
			SHOWMAXIMIZED = 3,
			SHOWNOACTIVATE = 4,
			SHOW = 5,
			MINIMIZE = 6,
			SHOWMINNOACTIVE = 7,
			SHOWNA = 8,
			RESTORE = 9,
			SHOWDEFAULT = 10
		}

		public enum WH : int
		{
			MIN = -1,
			MSGFILTER = -1,
			JOURNALRECORD = 0,
			JOURNALPLAYBACK = 1,
			KEYBOARD = 2,
			GETMESSAGE = 3,
			CALLWNDPROC = 4,
			CBT = 5,
			SYSMSGFILTER = 6,
			MOUSE = 7,
			HARDWARE = 8,
			DEBUG = 9,
			SHELL = 10,
			FOREGROUNDIDLE = 11,
			CALLWNDPROCRET = 12,
			KEYBOARD_LL = 13,
			MOUSE_LL = 14
		}

		/// <summary>
		/// System constants
		/// </summary>
		public enum SC : int 
		{ 
			SIZE = 0xF000, 
			MOVE = 0xF010, 
			MINIMIZE = 0xF020, 
			MAXIMIZE = 0xF030, 
			NEXTWINDOW = 0xF040, 
			PREVWINDOW = 0xF050, 
			CLOSE = 0xF060, 
			VSCROLL = 0xF070, 
			HSCROLL = 0xF080, 
			MOUSEMENU = 0xF090, 
			KEYMENU = 0xF100, 
			ARRANGE = 0xF110, 
			RESTORE = 0xF120, 
			TASKLIST = 0xF130, 
			SCREENSAVE = 0xF140, 
			HOTKEY = 0xF150, 
			DEFAULT = 0xF160, 
			MONITORPOWER = 0xF170, 
			CONTEXTHELP = 0xF180, 
			SEPARATOR = 0xF00F,
			WS_CHILD = 0x40000000,
			WS_VISIBLE = 0x10000000,
			WM_ACTIVATEAPP = 0x001C
		} 

		/// <summary> 
		/// Window Messages 
		/// </summary> 
		public enum WM : int 
		{ 
			ACTIVATE = 0x0006, 
			ACTIVATEAPP = 0x001C, 
			AFXFIRST = 0x0360, 
			AFXLAST = 0x037F, 
			APP = 0x8000, 
			ASKCBFORMATNAME = 0x030C, 
			CANCELJOURNAL = 0x004B, 
			CANCELMODE = 0x001F, 
			CAPTURECHANGED = 0x0215, 
			CHANGECBCHAIN = 0x030D, 
			CHAR = 0x0102, 
			CHARTOITEM = 0x002F, 
			CHILDACTIVATE = 0x0022, 
			CLEAR = 0x0303, 
			CLOSE = 0x0010, 
			COMMAND = 0x0111, 
			COMPACTING = 0x0041, 
			COMPAREITEM = 0x0039, 
			CONTEXTMENU = 0x007B, 
			COPY = 0x0301, 
			COPYDATA = 0x004A, 
			CREATE = 0x0001, 
			CTLCOLORBTN = 0x0135, 
			CTLCOLORDLG = 0x0136, 
			CTLCOLOREDIT = 0x0133, 
			CTLCOLORLISTBOX = 0x0134, 
			CTLCOLORMSGBOX = 0x0132, 
			CTLCOLORSCROLLBAR = 0x0137, 
			CTLCOLORSTATIC = 0x0138, 
			CUT = 0x0300, 
			DEADCHAR = 0x0103, 
			DELETEITEM = 0x002D, 
			DESTROY = 0x0002, 
			DESTROYCLIPBOARD = 0x0307, 
			DEVICECHANGE = 0x0219, 
			DEVMODECHANGE = 0x001B, 
			DISPLAYCHANGE = 0x007E, 
			DRAWCLIPBOARD = 0x0308, 
			DRAWITEM = 0x002B, 
			DROPFILES = 0x0233, 
			ENABLE = 0x000A, 
			ENDSESSION = 0x0016, 
			ENTERIDLE = 0x0121, 
			ENTERMENULOOP = 0x0211, 
			ENTERSIZEMOVE = 0x0231, 
			ERASEBKGND = 0x0014, 
			EXITMENULOOP = 0x0212, 
			EXITSIZEMOVE = 0x0232, 
			FONTCHANGE = 0x001D, 
			GETDLGCODE = 0x0087, 
			GETFONT = 0x0031, 
			GETHOTKEY = 0x0033, 
			GETICON = 0x007F, 
			GETMINMAXINFO = 0x0024, 
			GETOBJECT = 0x003D, 
			GETTEXT = 0x000D, 
			GETTEXTLENGTH = 0x000E, 
			HANDHELDFIRST = 0x0358, 
			HANDHELDLAST = 0x035F, 
			HELP = 0x0053, 
			HOTKEY = 0x0312, 
			HSCROLL = 0x0114, 
			HSCROLLCLIPBOARD = 0x030E, 
			ICONERASEBKGND = 0x0027, 
			IME_CHAR = 0x0286, 
			IME_COMPOSITION = 0x010F, 
			IME_COMPOSITIONFULL = 0x0284, 
			IME_CONTROL = 0x0283, 
			IME_ENDCOMPOSITION = 0x010E, 
			IME_KEYDOWN = 0x0290, 
			IME_KEYLAST = 0x010F, 
			IME_KEYUP = 0x0291, 
			IME_NOTIFY = 0x0282, 
			IME_REQUEST = 0x0288, 
			IME_SELECT = 0x0285, 
			IME_SETCONTEXT = 0x0281, 
			IME_STARTCOMPOSITION = 0x010D, 
			INITDIALOG = 0x0110, 
			INITMENU = 0x0116, 
			INITMENUPOPUP = 0x0117, 
			INPUTLANGCHANGE = 0x0051, 
			INPUTLANGCHANGEREQUEST = 0x0050, 
			KEYDOWN = 0x0100, 
			KEYFIRST = 0x0100, 
			KEYLAST = 0x0108, 
			KEYUP = 0x0101, 
			KILLFOCUS = 0x0008, 
			LBUTTONDBLCLK = 0x0203, 
			LBUTTONDOWN = 0x0201, 
			LBUTTONUP = 0x0202, 
			MBUTTONDBLCLK = 0x0209, 
			MBUTTONDOWN = 0x0207, 
			MBUTTONUP = 0x0208, 
			MDIACTIVATE = 0x0222, 
			MDICASCADE = 0x0227, 
			MDICREATE = 0x0220, 
			MDIDESTROY = 0x0221, 
			MDIGETACTIVE = 0x0229, 
			MDIICONARRANGE = 0x0228, 
			MDIMAXIMIZE = 0x0225, 
			MDINEXT = 0x0224, 
			MDIREFRESHMENU = 0x0234, 
			MDIRESTORE = 0x0223, 
			MDISETMENU = 0x0230, 
			MDITILE = 0x0226, 
			MEASUREITEM = 0x002C, 
			MENUCHAR = 0x0120, 
			MENUCOMMAND = 0x0126, 
			MENUDRAG = 0x0123, 
			MENUGETOBJECT = 0x0124, 
			MENURBUTTONUP = 0x0122, 
			MENUSELECT = 0x011F, 
			MOUSEACTIVATE = 0x0021, 
			MOUSEFIRST = 0x0200, 
			MOUSEHOVER = 0x02A1, 
			MOUSELAST = 0x020A, 
			MOUSELEAVE = 0x02A3, 
			MOUSEMOVE = 0x0200, 
			MOUSEWHEEL = 0x020A, 
			MOVE = 0x0003, 
			MOVING = 0x0216, 
			NCACTIVATE = 0x0086, 
			NCCALCSIZE = 0x0083, 
			NCCREATE = 0x0081, 
			NCDESTROY = 0x0082, 
			NCHITTEST = 0x0084, 
			NCLBUTTONDBLCLK = 0x00A3, 
			NCLBUTTONDOWN = 0x00A1, 
			NCLBUTTONUP = 0x00A2, 
			NCMBUTTONDBLCLK = 0x00A9, 
			NCMBUTTONDOWN = 0x00A7, 
			NCMBUTTONUP = 0x00A8, 
			NCMOUSEHOVER = 0x02A0, 
			NCMOUSEMOVE = 0x00A0, 
			NCPAINT = 0x0085, 
			NCRBUTTONDBLCLK = 0x00A6, 
			NCRBUTTONDOWN = 0x00A4, 
			NCRBUTTONUP = 0x00A5, 
			NEXTDLGCTL = 0x0028, 
			NEXTMENU = 0x0213, 
			NOTIFY = 0x004E, 
			NOTIFYFORMAT = 0x0055, 
			NULL = 0x0000, 
			PAINT = 0x000F, 
			PAINTCLIPBOARD = 0x0309, 
			PAINTICON = 0x0026, 
			PALETTECHANGED = 0x0311, 
			PALETTEISCHANGING = 0x0310, 
			PARENTNOTIFY = 0x0210, 
			PASTE = 0x0302, 
			PENWINFIRST = 0x0380, 
			PENWINLAST = 0x038F, 
			POWER = 0x0048, 
			PRINT = 0x0317, 
			PRINTCLIENT = 0x0318, 
			QUERYDRAGICON = 0x0037, 
			QUERYENDSESSION = 0x0011, 
			QUERYNEWPALETTE = 0x030F, 
			QUERYOPEN = 0x0013, 
			QUEUESYNC = 0x0023, 
			QUIT = 0x0012, 
			RBUTTONDBLCLK = 0x0206, 
			RBUTTONDOWN = 0x0204, 
			RBUTTONUP = 0x0205, 
			RENDERALLFORMATS = 0x0306, 
			RENDERFORMAT = 0x0305, 
			SETCURSOR = 0x0020, 
			SETFOCUS = 0x0007, 
			SETFONT = 0x0030, 
			SETHOTKEY = 0x0032, 
			SETICON = 0x0080, 
			SETREDRAW = 0x000B, 
			SETTEXT = 0x000C, 
			SETTINGCHANGE = 0x001A, 
			SHOWWINDOW = 0x0018, 
			SIZE = 0x0005, 
			SIZECLIPBOARD = 0x030B, 
			SIZING = 0x0214, 
			SPOOLERSTATUS = 0x002A, 
			STYLECHANGED = 0x007D, 
			STYLECHANGING = 0x007C, 
			SYNCPAINT = 0x0088, 
			SYSCHAR = 0x0106, 
			SYSCOLORCHANGE = 0x0015, 
			SYSCOMMAND = 0x0112, 
			SYSDEADCHAR = 0x0107, 
			SYSKEYDOWN = 0x0104, 
			SYSKEYUP = 0x0105, 
			TCARD = 0x0052, 
			TIMECHANGE = 0x001E, 
			TIMER = 0x0113, 
			UNDO = 0x0304, 
			UNINITMENUPOPUP = 0x0125, 
			USER = 0x0400, 
			USERCHANGED = 0x0054, 
			VKEYTOITEM = 0x002E, 
			VSCROLL = 0x0115, 
			VSCROLLCLIPBOARD = 0x030A, 
			WINDOWPOSCHANGED = 0x0047, 
			WINDOWPOSCHANGING = 0x0046, 
			WININICHANGE = 0x001A 
		} 

		public enum HWND : int
		{
			BOTTOM = 1,
			NOTOPMOST = -2,
			TOPMOST = -1,
			TOP = 0
		}

		public enum SWP : uint
		{
			ASYNCWINDOWPOS = 0x4000,
			DEFERERASE = 0x2000,
			FRAMECHANGED = 0x0020,
			HIDEWINDOW = 0x0080,
			NOACTIVATE = 0x0010,
			NOCOPYBITS = 0x0100,
			NOMOVE = 0x0002,
			NOOWNERZORDER = 0x0200,
			NOREDRAW = 0x0008,
			NOSENDCHANGING = 0x0400,
			NOSIZE = 0x0001,
			NOZORDER = 0x0004,
			SHOWWINDOW = 0x0040
		}

		public enum VK : int
		{
			NUMPAD7 = 0x67,
			NUMPAD8 = 0x68,
			NUMPAD9 = 0x69,
			MULTIPLY = 0x6A,
			ADD = 0x6B,
			SEPARATOR = 0x6C,
			SUBTRACT = 0x6D,
			DECIMAL = 0x6E,
			DIVIDE = 0x6F,
			F1 = 0x70,
			F2 = 0x71,
			F3 = 0x72,
			F4 = 0x73,
			F5 = 0x74,
			F6 = 0x75,
			F7 = 0x76,
			F8 = 0x77,
			F9 = 0x78,
			F10 = 0x79,
			F11 = 0x7A,
			F12 = 0x7B,
			NUMLOCK = 0x90,
			SCROLL = 0x91,
			LSHIFT = 0xA0,
			RSHIFT = 0xA1,
			LCONTROL = 0xA2,
			RCONTROL = 0xA3,
			LMENU = 0xA4,
			RMENU = 0xA5,
			BACK = 0x08,
			TAB = 0x09,
			RETURN = 0x0D,
			SHIFT = 0x10,
			CONTROL = 0x11,
			MENU = 0x12,
			PAUSE = 0x13,
			CAPITAL = 0x14,
			ESCAPE = 0x1B,
			SPACE = 0x20,
			END = 0x23,
			HOME = 0x24,
			LEFT = 0x25,
			UP = 0x26,
			RIGHT = 0x27,
			DOWN = 0x28,
			PRINT = 0x2A,
			SNAPSHOT = 0x2C,
			INSERT = 0x2D,
			DELETE = 0x2E,
			LWIN = 0x5B,
			RWIN = 0x5C,
			NUMPAD0 = 0x60,
			NUMPAD1 = 0x61,
			NUMPAD2 = 0x62,
			NUMPAD3 = 0x63,
			NUMPAD4 = 0x64,
			NUMPAD5 = 0x65,
			NUMPAD6 = 0x66
		}
		
		public enum GW : int
		{
			HWNDFIRST		= 0,
			HWNDNEXT		= 2,
			OWNER			= 4
		}

		public enum TVM : int
		{
			INSERTITEMA		= 0x1100,
			INSERTITEMW		= 0x1100 + 50,
			DELETEITEM		= 0x1100 + 1,
			EXPAND			= 0x1100 + 2,
			GETITEMRECT		= 0x1100 + 4,
			GETCOUNT		= 0x1100 + 5,
			GETINDENT		= 0x1100 + 6,
			SETINDENT		= 0x1100 + 7,
			GETIMAGELIST	= 0x1100 + 8,
			SETIMAGELIST	= 0x1100 + 9,
			GETNEXTITEM		= 0x1100 + 10,
			SELECTITEM		= 0x1100 + 11,
			GETITEMA		= 0x1100 + 12,
			GETITEMW		= 0x1100 + 62,
			SETITEMA		= 0x1100 + 13,
			SETITEMW		= 0x1100 + 63,
			EDITLABELA		= 0x1100 + 14,
			EDITLABELW		= 0x1100 + 65,
			GETEDITCONTROL	= 0x1100 + 15,
			GETVISIBLECOUNT = 0x1100 + 16,
			HITTEST			= 0x1100 + 17,
			GETITEM			= Win32.TVM.GETITEMW,
			SETITEM			= Win32.TVM.SETITEMW
		}

		public enum TVGN : int
		{
			ROOT			= 0,
			NEXT			= 1,
			PREVIOUS		= 2,
			PARENT			= 3,
			CHILD			= 4,
			FIRSTVISIBlE	= 5,
			NEXTVISIBLE		= 6,
			PREVIOUSVISIBLE = 7,
			DROPHILITE		= 8,
			CARET			= 9
		}

		public enum NM : int
		{
			FIRST			= 0,
			OUTOFMEMORY		= NM.FIRST - 1,
			CLICK			= NM.FIRST - 2,
			DBLCLK			= NM.FIRST - 3,
			RETURN			= NM.FIRST - 4,
			RCLICK			= NM.FIRST - 5,
			RDBLCLK			= NM.FIRST - 6,
			SETFOCUS		= NM.FIRST - 7,
			KILLFOCUS		= NM.FIRST - 8
		}

		public enum TVIF : int
		{
			TEXT			= 1,
			IMAGE			= 2,
			PARAM			= 4,
			STATE			= 8,
			HANDLE			= 10,
			SELECTEDIMAGE	= 20,
			CHILDREN		= 40
		}

		public enum LVIS : int
		{
			FOCUSED			= 0x1,
			SELECTED		= 0x2,
			DROPHILITED		= 0x8,
			ACTIVATING		= 0x20,
			OVERLAYMASK		= 0xF00,
			STATEIMAGEMASK	= 0xF000
		}

		public enum LVIF : int
		{
			TEXT			= 0x1,
			PARAM			= 0x4,
			STATE			= 0x8
		}

        public enum LVS_EX : int
        {
            GRIDLINES           = 0x00000001,
            SUBITEMIMAGES       = 0x00000002,
            CHECKBOXES          = 0x00000004,
            TRACKSELECT         = 0x00000008,
            HEADERDRAGDROP      = 0x00000010,
            FULLROWSELECT       = 0x00000020,
            ONECLICKACTIVATE    = 0x00000040,
            TWOCLICKACTIVATE    = 0x00000080,
            FLATSB              = 0x00000100,
            REGIONAL            = 0x00000200,
            INFOTIP             = 0x00000400,
            UNDERLINEHOT        = 0x00000800,
            UNDERLINECOLD       = 0x00001000,
            MULTIWORKAREAS      = 0x00002000,
            LABELTIP            = 0x00004000,
            BORDERSELECT        = 0x00008000,
            DOUBLEBUFFER        = 0x00010000,
            HIDELABELS          = 0x00020000,
            SINGLEROW           = 0x00040000,
            SNAPTOGRID          = 0x00080000,
            SIMPLESELECT        = 0x00100000
        }

		public enum LVM : int
		{
			FIRST			            = 0x1000,
			GETITEMCOUNT	            = 0x1004,
			GETITEM			            = 0x1005,
			SETITEM			            = 0x1006,
			ENSUREVISIBLE	            = LVM.FIRST + 19,
			GETHEADER		            = LVM.FIRST + 31,
			UPDATE			            = LVM.FIRST + 42,
			SETITEMSTATE	            = LVM.FIRST + 43,
			GETITEMTEXT		            = LVM.FIRST + 45,
			SORTITEMS		            = LVM.FIRST + 48,
            GETEXTENDEDLISTVIEWSTYLE    = LVM.FIRST + 55,
            SETEXTENDEDLISTVIEWSTYLE    = LVM.FIRST + 54
		}

		public enum LVFI_FLAGS
		{
			PARAM			= 0x1,
			PARTIAL			= 0x8,
			STRING			= 0x2,
			WRAP			= 0x20,
			NEARESTXY		= 0x40,
		}

		public enum LVColTypes
		{
			LV_COL_TEXT		= 0,
			LV_COL_INTEGER	= 1,
			LV_COL_FLOAT	= 2
		}

		public enum SIZE : int
		{
			RESTORED	= 0,
			MINIMIZED	= 1,
			MAXIMIZED	= 2,
			MAXSHOW		= 3,
			MAXHIDE		= 4
		}

		public enum WMSZ : int
		{
			LEFT		= 1,
			RIGHT		= 2,
			TOP			= 3,
			TOPLEFT		= 4,
			TOPRIGHT	= 5,
			BOTTOM		= 6,
			BOTTOMLEFT	= 7,
			BOTTOMRIGHT	= 8
		}

		public enum RDW
		{
			INVALIDATE		= 0x0001,
			INTERNALPAINT	= 0x0002,
			ERASE			= 0x0004,
			VALIDATE		= 0x0008,
			NOINTERNALPAINT	= 0x0010,
			NOERASE			= 0x0020,
			NOCHILDREN		= 0x0040,
			ALLCHILDREN		= 0x0080,
			UPDATENOW		= 0x0100,
			ERASENOW		= 0x0200,
			FRAME			= 0x0400,
			NOFRAME			= 0x0800
		}

		public enum HDM : int
		{
			FIRST			= 0x1200,
			GETITEMCOUNT	= HDM.FIRST + 0,
			GETITEMRECT		= HDM.FIRST + 7
		}

		[DllImport("user32.dll")]
		public static extern long GetWindowLong(int hwnd, int nIndex);
	}

    /// <summary>
    /// A class used for finding windows based upon their class, name and size
    /// </summary>
    public class WindowFinder
    {
        private int parentHandle = 0, foundWindowHandle = 0;
        private string className = "", windowName = "";
        private Size size = new Size(0, 0);
        private bool foundWindowFlag = false;
        private bool minSize = false;
        private bool windowNameStartsWith = false;

        [DllImport("user32.Dll")]
        private static extern Boolean EnumChildWindows(int hWndParent, PChildCallBack lpEnumFunc, int lParam);

        private delegate bool PChildCallBack(int hWnd, int lParam);

        /// <summary>
        /// Looks for a given window
        /// </summary>
        /// <param name="parentHandle">The handle of the parent window</param>
        /// <param name="className">The classname of the window to find</param>
        /// <param name="windowName">The window name of the window to find</param>
        /// <param name="size">The dimensions of the window to find, use 0x0 to ignore size</param>
        /// <param name="minSize">Whether the size parameter is the minimum allowed size, or the actual size</param>
        /// <returns>A handle != 0 if the window was found, 0 if no window could be found</returns>
        public int FindWindow(int parentHandle, string className, string windowName, Size size, bool minSize)
        {
            this.parentHandle = parentHandle;
            this.className = className;
            this.windowName = windowName;
            this.size = size;
            this.minSize = minSize;
            foundWindowFlag = false;
            foundWindowHandle = 0;

            EnumChildWindows(parentHandle, new PChildCallBack(EnumChildWindowCallBack), 0);

            return foundWindowHandle;
        }

        /// <summary>
        /// Looks for a given window
        /// </summary>
        /// <param name="parentHandle">The handle of the parent window</param>
        /// <param name="className">The classname of the window to find</param>
        /// <param name="windowName">The window name of the window to find</param>
        /// <param name="size">The dimensions of the window to find, use 0x0 to ignore size</param>
        /// <param name="minSize">Whether the size parameter is the minimum allowed size, or the actual size</param>
        /// <param name="windowNameStartsWith">Whether the windowName determines the actual windowName, or whether it's the start of the window name</param>
        /// <returns>A handle != 0 if the window was found, 0 if no window could be found</returns>
        public int FindWindow(int parentHandle, string className, string windowName, Size size, bool minSize, bool windowNameStartsWith)
        {
            this.windowNameStartsWith = windowNameStartsWith;

            return FindWindow(parentHandle, className, windowName, size, minSize);
        }

        /// <summary>
        /// Called when a window is found, we gotta check if the foun window is the requested window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private bool EnumChildWindowCallBack(int hwnd, int lParam)
        {
            // Check for foundWindow flag
            if (foundWindowFlag)
                return true;

            // Check if class matches
            StringBuilder sbc = new StringBuilder(256);
            Win32.GetClassName(hwnd, sbc, sbc.Capacity);
            if (!sbc.ToString().Equals(className))
                return true;

            // Check if windowName matches
            StringBuilder sb = new StringBuilder(512);
            Win32.GetWindowText(hwnd, sb, sb.Capacity);
            if (windowNameStartsWith)
            {
                if (!sb.ToString().StartsWith(windowName))
                    return true;
            }
            else
                if (!sb.ToString().Equals(windowName))
                    return true;

            // Check if size matches
            if (size.Height != 0 && size.Width != 0)
            {
                Rectangle rect = new Rectangle(0, 0, 0, 0);
                Win32.GetWindowRect(hwnd, ref rect);

                int width = rect.Width - rect.X;
                int height = rect.Height - rect.Y;

                if (minSize)
                {
                    if (height < size.Height || width < size.Width)
                        return true;
                }
                else
                {
                    if (height != size.Height || width != size.Width)
                        return true;
                }
            }

            // If we get to here, we've found our window
            foundWindowFlag = true;
            foundWindowHandle = hwnd;

            // Return
            return true;
        }
    }
}