using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using Graphics = System.Drawing.Graphics;

namespace Scrpts
{
    public class UtilsScreen : MonoBehaviour
    {
        private const int SW_SHOWMINIMIZED = 2;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void MinimizeAllWindows()
        {
            IntPtr hWnd = GetForegroundWindow();
            ShowWindow(hWnd, SW_SHOWMINIMIZED);
        }
    
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const byte VK_LWIN = 0x5B;
        private const byte VK_D = 0x44;
        private const uint KEYEVENTF_KEYUP = 0x0002;

        public static void ShowDesktop()
        {
            keybd_event(VK_LWIN, 0, 0, UIntPtr.Zero);
            keybd_event(VK_D, 0, 0, UIntPtr.Zero);
            keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            keybd_event(VK_D, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
        }
    
        public static Bitmap CaptureScreen()
        {
            int screenWidth = Screen.width;
            int screenHeight = Screen.height;

            Bitmap bmp = new Bitmap(screenWidth, screenHeight);
            
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            }

            string path = Path.Combine(Application.persistentDataPath, "screenshot.png");
            //bmp.Save(path, ImageFormat.Png);
            //Debug.Log("Screenshot saved at: " + path);
            return bmp;
            
        }
    }
}
