using Martin_AdventureWorks.Data;
using Martin_AdventureWorks.Services;

namespace Martin_AdventureWorks
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            AdventureWorksService adventureWorksService = new AdventureWorksService();
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(adventureWorksService));
        }
    }
}