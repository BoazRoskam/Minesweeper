public static class Game{

    private static bool Playing{get; set;} = true;
    public static Grid Grid{get; private set;}

    public static void StartGame(){
        Grid = new(14, 18);

        while(Playing){
            try{
                Grid.DisplayGrid();
                Console.WriteLine("Choose a tile to open");
                Console.WriteLine("What is the row number?");
                int verIndex = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What is the column number?");
                int horIndex = Convert.ToInt32(Console.ReadLine());
                
                if(!Grid.Tiles[verIndex - 1][horIndex - 1].IsOpend){
                    Grid.Tiles[verIndex - 1][horIndex - 1].OpenTile();
                    if(Grid.CheckForWin()) GameWon();
                }
                else{
                    Console.WriteLine("That tile is already open!");
                }
            }

            catch (IndexOutOfRangeException){
                Console.WriteLine("Please choose a valid number!");
            }

            catch (FormatException){
                Console.WriteLine("Please choose a valid number!");
            }
        }
        return;
    }

    public static void GameOver(){
        Playing = false;
        Grid.DisplayGrid();
        Console.WriteLine("To bad, you hit a mine and now you lost!");
    }

    public static void GameWon(){
        Playing = false;
        Grid.DisplayGrid();
        Console.WriteLine("Congratulations you won!!");
    }
    
    public static void Restart(){
        Playing = true;
    }


}