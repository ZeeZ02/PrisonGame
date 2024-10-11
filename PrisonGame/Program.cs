namespace PrisonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Game Starts!");

            Game prison = new Game();
            var wonGame =prison.GameStart();
            if(wonGame)
            {
                Console.WriteLine("The prisoners WON the game and will LIVE!");
            }
            else
            {
                Console.WriteLine("The prisoners LOST the game and will ALL DIE!");
            }

            Console.WriteLine("Game has ended!");
        }
    }
}
