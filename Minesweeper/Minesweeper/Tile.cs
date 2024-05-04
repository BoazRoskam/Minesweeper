public abstract class Tile{
    public int VerIndex{get;}
    public int HorIndex{get;}
    public bool IsOpend{get; set;} = false;
    public abstract string TileIcon{get;}

    public Tile(int verIndex, int horIndex){
        VerIndex = verIndex;
        HorIndex = horIndex;
    }

    public abstract void OpenTile();
}