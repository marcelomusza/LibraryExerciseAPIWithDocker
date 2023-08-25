using LibraryExercise.Domain.Interfaces;

namespace LibraryExercise.Application.Commands
{
    public class ExitCommand : IBookCommand
    {
        public void Execute()
        {
            Console.WriteLine("Thanks for using this wonderful application. Press any key to continue...");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
