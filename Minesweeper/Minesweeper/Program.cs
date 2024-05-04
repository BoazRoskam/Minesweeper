public class Program{

    public static void Main(){

        while(true){
            Console.WriteLine("Welcome by MineSweepers, type 'play' to start the game or type 'quit' to quit the game");
            string choise = Console.ReadLine();
            if(choise == "play"){
                Game.Restart();
                Game.StartGame();
            }
            if(choise == "quit"){
                Console.WriteLine("Thanks for playing...");
                return;
            }
            
            //Settings menu
            /*
            if(choise == "settings"){
                Console.WriteLine("Here you can change your grid and the amount of mines");
                Console.WriteLine("What should the vertical range be of your grid?");
                Console.WriteLine("What should the horizontal range be of your grid?");
                Console.WriteLine("How many mines should there be?"):
            }
            */
        }
       
    }
}