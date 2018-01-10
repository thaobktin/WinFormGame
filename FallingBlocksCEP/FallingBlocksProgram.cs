using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FallingBlocksCEP
{
    static class FallingBlocksProgram
    {
        // UnsafeNativeMethods
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32", SetLastError = true)]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IntPtr ptr = GetForegroundWindow();
            int pid;
            GetWindowThreadProcessId(ptr, out pid);
            Process process = Process.GetProcessById(pid);
            AllocConsole();
            AttachConsole(process.Id);
            Console.WriteLine("{0} FallingBlocksCEP started", DateTime.Now);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FallingBlocksForm());
        }
    }
}
