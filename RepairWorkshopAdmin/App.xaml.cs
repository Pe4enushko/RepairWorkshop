using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RepairWorkshopAdmin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static object locker = new();
        public App()
        {
            // Глобальная обработка необработанных ошибок
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Log($"Exception Time: {DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")}\n" +
                $"Message: {e.Exception.Message}\n" +
                $"StackTrace: {e.Exception.StackTrace}\n");

            string errorMessage = $"Ошибка: {e.Exception.Message} \n Свяжитесь с разработчиком";
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true;
        }
        public static void Log(string message)
        {
            lock (locker)
            {
                var dir = @$"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\RepairWorkshop";
                var path = @$"{dir}\Logs.log";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            
                File.AppendAllText(path, message + "\n\n");
            }
        }
    }
}
