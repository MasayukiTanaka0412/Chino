using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsInput;

namespace Cocoa
{
    public class EventExecutor
    {   
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hwnd, int x, int y,
            int nWidth, int nHeight, int bRepaint);


        public static void ActivateWindow(int pid)
        {
            Process proc = Process.GetProcessById(pid);
            MoveWindow(proc.MainWindowHandle, 0, 0, 1024, 768, 1);
        }

        public static void Sleep(int millisec)
        {
            Thread.Sleep(millisec);
        }

        public static void MouseLeftPress(int x, int y)
        {
            MOUSEINPUT mouseinput = new MOUSEINPUT();
            mouseinput.X = x * (65535 / Screen.PrimaryScreen.Bounds.Width);
            mouseinput.Y = y * (65535 / Screen.PrimaryScreen.Bounds.Height);
            mouseinput.Flags = (uint)(MouseFlag.LEFTDOWN | MouseFlag.MOVE | MouseFlag.ABSOLUTE);
            var click = new INPUT();
            click.Type = (UInt32)InputType.MOUSE;
            click.Data.Mouse = mouseinput;
            INPUT[] inputList = new INPUT[1];
            inputList[0] = click;
            var numberOfSuccessfulSimulatedInputs = InputSimulator.SendInput(1, inputList, Marshal.SizeOf(typeof(INPUT)));
            if (numberOfSuccessfulSimulatedInputs == 0) throw new Exception("Mouse Click Failed");
        }

        public static void PressEnter()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.RETURN);
        }

        public static void PressTab()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.TAB);
        }

        public static void PressUp()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.UP);
        }

        public static void PressDown()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.DOWN);
        }

        public static void PressLeftArrow()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.LEFT);
        }

        public static void PressRightArrow()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.RIGHT);
        }

        public static void PressPageUp()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.PRIOR);
        }

        public static void PressPageDown()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.NEXT);
        }

        public static void PressHome()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.HOME);
        }

        public static void PressEnd()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.END);
        }

        public static void PressSpace()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.SPACE);
        }

        public static void PressEsc()
        {
            InputSimulator.SimulateKeyPressCitrix(VirtualKeyCode.ESCAPE);
        }
    }
}
