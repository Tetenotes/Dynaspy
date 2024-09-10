using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace DynaSpyLibraryMonitor
{
    public partial class MainWindow : Window
    {
        private DynaSpyLibraryMonitor monitor;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            string libraryName = SoNameTextBox.Text;

            if (!string.IsNullOrEmpty(libraryName))
            {
                monitor = new SharedLibraryMonitor(libraryName);
                monitor.Loaded += OnLibraryLoaded;
                monitor.CheckIfLoaded();
            }
        }

        private void OnLibraryLoaded(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StatusLabel.Content = $"{monitor.LibraryName} loaded!";
            });
            MessageBox.Show($"{monitor.LibraryName} has been loaded!");

            bool isInfected = monitor.CheckForMalware();
            if (isInfected)
            {
                MessageBox.Show($"{monitor.LibraryName} contains malware!");
            }
            else
            {
                MessageBox.Show($"{monitor.LibraryName} is clean.");
            }
        }
    }

    class DynaSpyLibraryMonitor
    {
        public event EventHandler Loaded;

        public string LibraryName { get; private set; }

        public bool IsLoaded { get; private set; }

        public DynaSpyLibraryMonitor(string libraryName)
        {
            LibraryName = libraryName;
        }

        public void CheckIfLoaded()
        {
            try
            {
                NativeMethods.dlopen(LibraryName, NativeMethods.RTLD_NOW);
            }
            catch
            {
                IsLoaded = false;
            }

            if (IsLoaded)
            {
                Loaded?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool CheckForMalware()
        {
            bool isInfected = false;
            byte[] fileBytes = File.ReadAllBytes(LibraryName);

            using (var scanner = new ClamScan())
            {
                var result = scanner.ScanFileOnServer(fileBytes);
                isInfected = result.IsVirusDetected;
            }

            return isInfected;
        }

        private static class NativeMethods
        {
            public const int RTLD_NOW = 2;

            [DllImport("libdl.so")]
            public static extern IntPtr dlopen(string filename, int flags);
        }
    }
}
