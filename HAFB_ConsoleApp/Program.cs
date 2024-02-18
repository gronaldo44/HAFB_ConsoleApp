using System;
namespace HAFB
{
    /// <summary>
    /// Hypothetical GUI where the time is being displayed 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller(ConsoleWriteLineCallback);
            controller.StartTimer();

            // Keep the program running
            Console.ReadLine(); // Terminate program when user types
        }

        private static void ConsoleWriteLineCallback(string message)
        {
            Console.WriteLine(message);
        }
    }
}
