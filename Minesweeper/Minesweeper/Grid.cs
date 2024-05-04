using System.Reflection;

public class Grid{

    public Tile[][] Tiles{get;}
    public int AmountOfMines{get;}
    public (int Ver, int Hor) Size{get;}

    public Grid(int vertical, int horizontal, int amountOfMines = 40){
        Tiles = CreateEmptyGrid(vertical, horizontal);
        AmountOfMines = amountOfMines;
        Size = new(vertical, horizontal);
        FillGrid();
    }

    private Tile[][] CreateEmptyGrid(int vertical, int horizontal){
        Tile[][] grid = new Tile[vertical][];
        for(int i = 0; i < grid.Length; i++){
            grid[i] = new Tile[horizontal];
        }
        return grid;
    }

    public int GetTotalTiles(){
        return Tiles.Length * Tiles[0].Length;
    }

    public void FillGrid(){
        Random randGen = new();
        for(int i = 0; i < AmountOfMines; i++){
            int vIndex = randGen.Next(0, Size.Ver);
            int hIndex = randGen.Next(0, Size.Hor);
            Tiles[vIndex][hIndex] = new MineTile(vIndex, hIndex);
        }
    
        for(int i = 0; i < Size.Ver; i++){
            for(int j = 0; j < Size.Hor; j++){
                if(Tiles[i][j] == null){
                    if(MinesInRange(i, j) > 0){
                        Tiles[i][j] = new NumberTile(i, j, MinesInRange(i, j));
                    }
                    else{
                        Tiles[i][j] = new EmptyTile(i, j);
                    }
                }
            }
        }
    }

    public void DisplayGrid(){
        Console.Write("   ");
        for(int a = 0; a < Size.Hor; a++){
            Console.Write($" {(a + 1).ToString("00")}");
        }

        for(int i = 0; i < Size.Ver; i++){
            Console.WriteLine();
            Console.Write($"{(i + 1).ToString("00")}. ");
            for(int j = 0; j < Size.Hor; j++){
                Console.Write($"{Tiles[i][j].TileIcon}");
            }
        }
        Console.WriteLine("\n\n");
    }

    public int MinesInRange(int verIndex, int horIndex){
        int minesInRange = 0;
        for(int i = 1; i >= -1; i--){
            for(int j = -1; j <= 1; j++){
                try{
                    if(Tiles[verIndex + i][horIndex + j] is MineTile){
                        minesInRange++;
                    }
                }
                catch(IndexOutOfRangeException){
                    continue;
                }
            }
        }
        return minesInRange;
    }

    public void OpenInRange(int verIndex, int horIndex){
        for(int i = 1; i >= -1; i--){
            for(int j = -1; j <= 1; j++){
                try{
                    if(!Tiles[verIndex + i][horIndex + j].IsOpend){
                        Tiles[verIndex + i][horIndex + j].OpenTile();
                    }
                }
                catch(IndexOutOfRangeException){
                    continue;
                }
            }
        }
    }

    public bool CheckForWin(){
        foreach(Tile[] tileArray in Tiles){
            foreach(Tile tile in tileArray){
                if(!tile.IsOpend && tile is not MineTile){
                    return false;
                }
            }
        }
    return true;
    }
}