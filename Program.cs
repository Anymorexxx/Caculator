using calculator.Controller;
using calculator.Model;
using calculator.Services;

namespace calculator
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
            var inputService = new InputService();
            var caculator = new Caculyator();
            ApplicationConfiguration.Initialize();
            var data = new CaculatorData();
            var view = new Form1();
            var controller = new CaculatorController(caculator, inputService, view, data);
            Application.Run(view);
        }
    }
}