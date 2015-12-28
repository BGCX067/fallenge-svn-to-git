/*
 * Code below is mostley taken from www.pinvoke.net
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FallenGE.Win32
{
    public class Core
    {
        public const UInt32 WM_ACTIVATE = 0x0006;
        public const UInt32 WM_ACTIVATEAPP = 0x001C;
        public const UInt32 WM_AFXFIRST = 0x0360;
        public const UInt32 WM_AFXLAST = 0x037F;
        public const UInt32 WM_APP = 0x8000;
        public const UInt32 WM_ASKCBFORMATNAME = 0x030C;
        public const UInt32 WM_CANCELJOURNAL = 0x004B;
        public const UInt32 WM_CANCELMODE = 0x001F;
        public const UInt32 WM_CAPTURECHANGED = 0x0215;
        public const UInt32 WM_CHANGECBCHAIN = 0x030D;
        public const UInt32 WM_CHANGEUISTATE = 0x0127;
        public const UInt32 WM_CHAR = 0x0102;
        public const UInt32 WM_CHARTOITEM = 0x002F;
        public const UInt32 WM_CHILDACTIVATE = 0x0022;
        public const UInt32 WM_CLEAR = 0x0303;
        public const UInt32 WM_CLOSE = 0x0010;
        public const UInt32 WM_COMMAND = 0x0111;
        public const UInt32 WM_COMPACTING = 0x0041;
        public const UInt32 WM_COMPAREITEM = 0x0039;
        public const UInt32 WM_CONTEXTMENU = 0x007B;
        public const UInt32 WM_COPY = 0x0301;
        public const UInt32 WM_COPYDATA = 0x004A;
        public const UInt32 WM_CREATE = 0x0001;
        public const UInt32 WM_CTLCOLORBTN = 0x0135;
        public const UInt32 WM_CTLCOLORDLG = 0x0136;
        public const UInt32 WM_CTLCOLOREDIT = 0x0133;
        public const UInt32 WM_CTLCOLORLISTBOX = 0x0134;
        public const UInt32 WM_CTLCOLORMSGBOX = 0x0132;
        public const UInt32 WM_CTLCOLORSCROLLBAR = 0x0137;
        public const UInt32 WM_CTLCOLORSTATIC = 0x0138;
        public const UInt32 WM_CUT = 0x0300;
        public const UInt32 WM_DEADCHAR = 0x0103;
        public const UInt32 WM_DELETEITEM = 0x002D;
        public const UInt32 WM_DESTROY = 0x0002;
        public const UInt32 WM_DESTROYCLIPBOARD = 0x0307;
        public const UInt32 WM_DEVICECHANGE = 0x0219;
        public const UInt32 WM_DEVMODECHANGE = 0x001B;
        public const UInt32 WM_DISPLAYCHANGE = 0x007E;
        public const UInt32 WM_DRAWCLIPBOARD = 0x0308;
        public const UInt32 WM_DRAWITEM = 0x002B;
        public const UInt32 WM_DROPFILES = 0x0233;
        public const UInt32 WM_ENABLE = 0x000A;
        public const UInt32 WM_ENDSESSION = 0x0016;
        public const UInt32 WM_ENTERIDLE = 0x0121;
        public const UInt32 WM_ENTERMENULOOP = 0x0211;
        public const UInt32 WM_ENTERSIZEMOVE = 0x0231;
        public const UInt32 WM_ERASEBKGND = 0x0014;
        public const UInt32 WM_EXITMENULOOP = 0x0212;
        public const UInt32 WM_EXITSIZEMOVE = 0x0232;
        public const UInt32 WM_FONTCHANGE = 0x001D;
        public const UInt32 WM_GETDLGCODE = 0x0087;
        public const UInt32 WM_GETFONT = 0x0031;
        public const UInt32 WM_GETHOTKEY = 0x0033;
        public const UInt32 WM_GETICON = 0x007F;
        public const UInt32 WM_GETMINMAXINFO = 0x0024;
        public const UInt32 WM_GETOBJECT = 0x003D;
        public const UInt32 WM_GETTEXT = 0x000D;
        public const UInt32 WM_GETTEXTLENGTH = 0x000E;
        public const UInt32 WM_HANDHELDFIRST = 0x0358;
        public const UInt32 WM_HANDHELDLAST = 0x035F;
        public const UInt32 WM_HELP = 0x0053;
        public const UInt32 WM_HOTKEY = 0x0312;
        public const UInt32 WM_HSCROLL = 0x0114;
        public const UInt32 WM_HSCROLLCLIPBOARD = 0x030E;
        public const UInt32 WM_ICONERASEBKGND = 0x0027;
        public const UInt32 WM_IME_CHAR = 0x0286;
        public const UInt32 WM_IME_COMPOSITION = 0x010F;
        public const UInt32 WM_IME_COMPOSITIONFULL = 0x0284;
        public const UInt32 WM_IME_CONTROL = 0x0283;
        public const UInt32 WM_IME_ENDCOMPOSITION = 0x010E;
        public const UInt32 WM_IME_KEYDOWN = 0x0290;
        public const UInt32 WM_IME_KEYLAST = 0x010F;
        public const UInt32 WM_IME_KEYUP = 0x0291;
        public const UInt32 WM_IME_NOTIFY = 0x0282;
        public const UInt32 WM_IME_REQUEST = 0x0288;
        public const UInt32 WM_IME_SELECT = 0x0285;
        public const UInt32 WM_IME_SETCONTEXT = 0x0281;
        public const UInt32 WM_IME_STARTCOMPOSITION = 0x010D;
        public const UInt32 WM_INITDIALOG = 0x0110;
        public const UInt32 WM_INITMENU = 0x0116;
        public const UInt32 WM_INITMENUPOPUP = 0x0117;
        public const UInt32 WM_INPUTLANGCHANGE = 0x0051;
        public const UInt32 WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const UInt32 WM_KEYDOWN = 0x0100;
        public const UInt32 WM_KEYFIRST = 0x0100;
        public const UInt32 WM_KEYLAST = 0x0108;
        public const UInt32 WM_KEYUP = 0x0101;
        public const UInt32 WM_KILLFOCUS = 0x0008;
        public const UInt32 WM_LBUTTONDBLCLK = 0x0203;
        public const UInt32 WM_LBUTTONDOWN = 0x0201;
        public const UInt32 WM_LBUTTONUP = 0x0202;
        public const UInt32 WM_MBUTTONDBLCLK = 0x0209;
        public const UInt32 WM_MBUTTONDOWN = 0x0207;
        public const UInt32 WM_MBUTTONUP = 0x0208;
        public const UInt32 WM_MDIACTIVATE = 0x0222;
        public const UInt32 WM_MDICASCADE = 0x0227;
        public const UInt32 WM_MDICREATE = 0x0220;
        public const UInt32 WM_MDIDESTROY = 0x0221;
        public const UInt32 WM_MDIGETACTIVE = 0x0229;
        public const UInt32 WM_MDIICONARRANGE = 0x0228;
        public const UInt32 WM_MDIMAXIMIZE = 0x0225;
        public const UInt32 WM_MDINEXT = 0x0224;
        public const UInt32 WM_MDIREFRESHMENU = 0x0234;
        public const UInt32 WM_MDIRESTORE = 0x0223;
        public const UInt32 WM_MDISETMENU = 0x0230;
        public const UInt32 WM_MDITILE = 0x0226;
        public const UInt32 WM_MEASUREITEM = 0x002C;
        public const UInt32 WM_MENUCHAR = 0x0120;
        public const UInt32 WM_MENUCOMMAND = 0x0126;
        public const UInt32 WM_MENUDRAG = 0x0123;
        public const UInt32 WM_MENUGETOBJECT = 0x0124;
        public const UInt32 WM_MENURBUTTONUP = 0x0122;
        public const UInt32 WM_MENUSELECT = 0x011F;
        public const UInt32 WM_MOUSEACTIVATE = 0x0021;
        public const UInt32 WM_MOUSEFIRST = 0x0200;
        public const UInt32 WM_MOUSEHOVER = 0x02A1;
        public const UInt32 WM_MOUSELAST = 0x020D;
        public const UInt32 WM_MOUSELEAVE = 0x02A3;
        public const UInt32 WM_MOUSEMOVE = 0x0200;
        public const UInt32 WM_MOUSEWHEEL = 0x020A;
        public const UInt32 WM_MOUSEHWHEEL = 0x020E;
        public const UInt32 WM_MOVE = 0x0003;
        public const UInt32 WM_MOVING = 0x0216;
        public const UInt32 WM_NCACTIVATE = 0x0086;
        public const UInt32 WM_NCCALCSIZE = 0x0083;
        public const UInt32 WM_NCCREATE = 0x0081;
        public const UInt32 WM_NCDESTROY = 0x0082;
        public const UInt32 WM_NCHITTEST = 0x0084;
        public const UInt32 WM_NCLBUTTONDBLCLK = 0x00A3;
        public const UInt32 WM_NCLBUTTONDOWN = 0x00A1;
        public const UInt32 WM_NCLBUTTONUP = 0x00A2;
        public const UInt32 WM_NCMBUTTONDBLCLK = 0x00A9;
        public const UInt32 WM_NCMBUTTONDOWN = 0x00A7;
        public const UInt32 WM_NCMBUTTONUP = 0x00A8;
        public const UInt32 WM_NCMOUSEMOVE = 0x00A0;
        public const UInt32 WM_NCPAINT = 0x0085;
        public const UInt32 WM_NCRBUTTONDBLCLK = 0x00A6;
        public const UInt32 WM_NCRBUTTONDOWN = 0x00A4;
        public const UInt32 WM_NCRBUTTONUP = 0x00A5;
        public const UInt32 WM_NEXTDLGCTL = 0x0028;
        public const UInt32 WM_NEXTMENU = 0x0213;
        public const UInt32 WM_NOTIFY = 0x004E;
        public const UInt32 WM_NOTIFYFORMAT = 0x0055;
        public const UInt32 WM_NULL = 0x0000;
        public const UInt32 WM_PAINT = 0x000F;
        public const UInt32 WM_PAINTCLIPBOARD = 0x0309;
        public const UInt32 WM_PAINTICON = 0x0026;
        public const UInt32 WM_PALETTECHANGED = 0x0311;
        public const UInt32 WM_PALETTEISCHANGING = 0x0310;
        public const UInt32 WM_PARENTNOTIFY = 0x0210;
        public const UInt32 WM_PASTE = 0x0302;
        public const UInt32 WM_PENWINFIRST = 0x0380;
        public const UInt32 WM_PENWINLAST = 0x038F;
        public const UInt32 WM_POWER = 0x0048;
        public const UInt32 WM_POWERBROADCAST = 0x0218;
        public const UInt32 WM_PRINT = 0x0317;
        public const UInt32 WM_PRINTCLIENT = 0x0318;
        public const UInt32 WM_QUERYDRAGICON = 0x0037;
        public const UInt32 WM_QUERYENDSESSION = 0x0011;
        public const UInt32 WM_QUERYNEWPALETTE = 0x030F;
        public const UInt32 WM_QUERYOPEN = 0x0013;
        public const UInt32 WM_QUEUESYNC = 0x0023;
        public const UInt32 WM_QUIT = 0x0012;
        public const UInt32 WM_RBUTTONDBLCLK = 0x0206;
        public const UInt32 WM_RBUTTONDOWN = 0x0204;
        public const UInt32 WM_RBUTTONUP = 0x0205;
        public const UInt32 WM_RENDERALLFORMATS = 0x0306;
        public const UInt32 WM_RENDERFORMAT = 0x0305;
        public const UInt32 WM_SETCURSOR = 0x0020;
        public const UInt32 WM_SETFOCUS = 0x0007;
        public const UInt32 WM_SETFONT = 0x0030;
        public const UInt32 WM_SETHOTKEY = 0x0032;
        public const UInt32 WM_SETICON = 0x0080;
        public const UInt32 WM_SETREDRAW = 0x000B;
        public const UInt32 WM_SETTEXT = 0x000C;
        public const UInt32 WM_SETTINGCHANGE = 0x001A;
        public const UInt32 WM_SHOWWINDOW = 0x0018;
        public const UInt32 WM_SIZE = 0x0005;
        public const UInt32 WM_SIZECLIPBOARD = 0x030B;
        public const UInt32 WM_SIZING = 0x0214;
        public const UInt32 WM_SPOOLERSTATUS = 0x002A;
        public const UInt32 WM_STYLECHANGED = 0x007D;
        public const UInt32 WM_STYLECHANGING = 0x007C;
        public const UInt32 WM_SYNCPAINT = 0x0088;
        public const UInt32 WM_SYSCHAR = 0x0106;
        public const UInt32 WM_SYSCOLORCHANGE = 0x0015;
        public const UInt32 WM_SYSCOMMAND = 0x0112;
        public const UInt32 WM_SYSDEADCHAR = 0x0107;
        public const UInt32 WM_SYSKEYDOWN = 0x0104;
        public const UInt32 WM_SYSKEYUP = 0x0105;
        public const UInt32 WM_TCARD = 0x0052;
        public const UInt32 WM_TIMECHANGE = 0x001E;
        public const UInt32 WM_TIMER = 0x0113;
        public const UInt32 WM_UNDO = 0x0304;
        public const UInt32 WM_UNINITMENUPOPUP = 0x0125;
        public const UInt32 WM_USER = 0x0400;
        public const UInt32 WM_USERCHANGED = 0x0054;
        public const UInt32 WM_VKEYTOITEM = 0x002E;
        public const UInt32 WM_VSCROLL = 0x0115;
        public const UInt32 WM_VSCROLLCLIPBOARD = 0x030A;
        public const UInt32 WM_WINDOWPOSCHANGED = 0x0047;
        public const UInt32 WM_WINDOWPOSCHANGING = 0x0046;
        public const UInt32 WM_WININICHANGE = 0x001A;
        public const UInt32 WM_XBUTTONDBLCLK = 0x020D;
        public const UInt32 WM_XBUTTONDOWN = 0x020B;
        public const UInt32 WM_XBUTTONUP = 0x020C;

        [Flags]
        public enum QueueStatusFlags : uint
        {
            QS_KEY = 0x0001,
            QS_MOUSEMOVE = 0x0002,
            QS_MOUSEBUTTON = 0x0004,
            QS_POSTMESSAGE = 0x0008,
            QS_TIMER = 0x0010,
            QS_PAINT = 0x0020,
            QS_SENDMESSAGE = 0x0040,
            QS_HOTKEY = 0x0080,
            QS_ALLPOSTMESSAGE = 0x0100,
            QS_RAWINPUT = 0x0400,
            QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,
            QS_INPUT = QS_MOUSE | QS_KEY | QS_RAWINPUT,
            QS_ALLEVENTS = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY,
            QS_ALLINPUT = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE
        }

        [Flags]
        public enum PeekMessageParams : uint
        {
            PM_NOREMOVE = 0x0000,
            PM_REMOVE = 0x0001,
            PM_NOYIELD = 0x0002,
            PM_QS_INPUT = QueueStatusFlags.QS_INPUT << 16,
            PM_QS_POSTMESSAGE = (QueueStatusFlags.QS_POSTMESSAGE | QueueStatusFlags.QS_HOTKEY | QueueStatusFlags.QS_TIMER) << 16,
            PM_QS_PAINT = QueueStatusFlags.QS_PAINT << 16,
            PM_QS_SENDMESSAGE = QueueStatusFlags.QS_SENDMESSAGE << 16
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hwnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DEVMODE
        {
            public const int CCHDEVICENAME = 32;
            public const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;

            public short dmOrientation;
            public short dmPaperSize;
            public short dmPaperLength;
            public short dmPaperWidth;

            public short dmScale;
            public short dmCopies;
            public short dmDefaultSource;
            public short dmPrintQuality;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;

            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;

            public int dmPositionX; // Using a PointL Struct does not work
            public int dmPositionY;

        }

        public const int DM_ORIENTATION = 0x00000001;
        public const int DM_PAPERSIZE = 0x00000002;
        public const int DM_PAPERLENGTH = 0x00000004;
        public const int DM_PAPERWIDTH = 0x00000008;
        public const int DM_SCALE = 0x00000010;
        public const int DM_POSITION = 0x00000020;
        public const int DM_NUP = 0x00000040;
        public const int DM_DISPLAYORIENTATION = 0x00000080;
        public const int DM_COPIES = 0x00000100;
        public const int DM_DEFAULTSOURCE = 0x00000200;
        public const int DM_PRINTQUALITY = 0x00000400;
        public const int DM_COLOR = 0x00000800;
        public const int DM_DUPLEX = 0x00001000;
        public const int DM_YRESOLUTION = 0x00002000;
        public const int DM_TTOPTION = 0x00004000;
        public const int DM_COLLATE = 0x00008000;
        public const int DM_FORMNAME = 0x00010000;
        public const int DM_LOGPIXELS = 0x00020000;
        public const int DM_BITSPERPEL = 0x00040000;
        public const int DM_PELSWIDTH = 0x00080000;
        public const int DM_PELSHEIGHT = 0x00100000;
        public const int DM_DISPLAYFLAGS = 0x00200000;
        public const int DM_DISPLAYFREQUENCY = 0x00400000;
        public const int DM_ICMMETHOD = 0x00800000;
        public const int DM_ICMINTENT = 0x01000000;
        public const int DM_MEDIATYPE = 0x02000000;
        public const int DM_DITHERTYPE = 0x04000000;
        public const int DM_PANNINGWIDTH = 0x08000000;
        public const int DM_PANNINGHEIGHT = 0x10000000;
        public const int DM_DISPLAYFIXEDOUTPUT = 0x20000000;

        public const int SWP_ASYNCWINDOWPOS = 0x4000;
        public const int SWP_DEFERERASE = 0x2000;
        public const int SWP_DRAWFRAME = 0x0020;
        public const int SWP_FRAMECHANGED = 0x0020;
        public const int SWP_HIDEWINDOW = 0x0080;
        public const int SWP_NOACTIVATE = 0x0010;
        public const int SWP_NOCOPYBITS = 0x0100;
        public const int SWP_NOMOVE = 0x0002;
        public const int SWP_NOOWNERZORDER = 0x0200;
        public const int SWP_NOREDRAW = 0x0008;
        public const int SWP_NOREPOSITION = 0x0200;
        public const int SWP_NOSENDCHANGING = 0x0400;
        public const int SWP_NOSIZE = 0x0001;
        public const int SWP_NOZORDER = 0x0004;
        public const int SWP_SHOWWINDOW = 0x0040;

        public const int HWND_TOP = 0;
        public const int HWND_BOTTOM = 1;
        public const int HWND_TOPMOST = -1;
        public const int HWND_NOTOPMOST = -2;

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(
           ref DEVMODE devMode, int flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PeekMessage(out MSG lpMsg, HandleRef hWnd, uint wMsgFilterMin,
           uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport("user32.dll")]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll")]
        public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

        [DllImport("user32.dll")]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hwnd, int hwnd2, int x, int y, int cx, int cy, int uFlags);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Int32 vKey);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("kernel32.dll")]
        public extern static short QueryPerformanceCounter(ref long cycles);

        [DllImport("kernel32.dll")]
        public extern static short QueryPerformanceFrequency(ref long cycles);

        [DllImport("winmm.dll", EntryPoint = "timeGetTime")]
        public extern static uint timeGetTime();

        [DllImport("gdi32.dll")]
        public static extern uint GetGlyphOutline(IntPtr hdc, uint uChar, uint uFormat,
           out GLYPHMETRICS lpgm, uint cbBuffer, IntPtr lpvBuffer, ref MAT2 lpmat2);

        [DllImport("gdi32.dll")]
        public static extern bool GetTextExtentPoint(IntPtr hdc, string lpString,
           int cbString, ref SIZE lpSize);

        [DllImport("user32.dll")]
        public static extern bool ShowCursor(int value);

        [StructLayout(LayoutKind.Sequential)]
        public struct SIZE
        {
            public int cx;
            public int cy;

            public SIZE(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct GLYPHMETRICS
        {
            public Single gmfBlackBoxX;
            public Single gmfBlackBoxY;
            public POINTFLOAT gmfptGlyphOrigin;
            public Single gmfCellIncX;
            public Single gmfCellIncY;
        }

        public struct POINTFLOAT
        {
            public Single x;
            public Single y;
        }

        public struct MAT2
        {
            public FIXED eM11;
            public FIXED eM12;
            public FIXED eM21;
            public FIXED eM22;
        }

        public struct FIXED
        {
            public short fract;
            public short value;
        }

        public Core()
        {

        }

        private static Queue<char> keyStack = new Queue<char>();

        public static char[] KeyStack
        {
            get
            {
                return keyStack.ToArray();
            }
        }

        public static char PopKey()
        {
            return keyStack.Dequeue();
        }

        public static void FlushKeys()
        {
            keyStack.Clear();
        }

        public static bool Update()
        {
            MSG message = new MSG();

            if (PeekMessage(out message, new HandleRef(null, IntPtr.Zero), 0, 0, Convert.ToUInt32(PeekMessageParams.PM_REMOVE)))
            {
                TranslateMessage(ref message);
                DispatchMessage(ref message);

                if (message.message == WM_QUIT)
                    return false;

                if (message.message == WM_CHAR || message.message == WM_SYSCHAR)
                		keyStack.Enqueue((char)message.wParam);
            }
            System.Threading.Thread.Sleep(10);

            return true;
        }

        public static void Quit()
        {
            PostQuitMessage(0);
        }

        public static void Fullscreen(int width, int height, int bitDepth)
        {
            DEVMODE deviceMode = new DEVMODE();

            deviceMode.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            deviceMode.dmPelsWidth = width;
            deviceMode.dmPelsHeight = height;
            deviceMode.dmBitsPerPel = (short)bitDepth;
            deviceMode.dmFields = DM_PELSWIDTH | DM_PELSHEIGHT | DM_BITSPERPEL;

            ChangeDisplaySettings(ref deviceMode, 0x00000004);
        }

        public static void PositionWindow(IntPtr hWnd, int x, int y, int width, int height)
        {
            SetWindowPos(hWnd, 0, x, y, width, height, SWP_NOMOVE);
        }
    }
}
