public class MineTile : Tile{

    public override string TileIcon{
        get{
            if(IsOpend) return "[*]";
            //else return "[*]";
            else return "[?]";
        }
    } 
    
    public MineTile(int verIndex, int horIndex) : base(verIndex, horIndex){
    }


    public override void OpenTile()
    {
        IsOpend = true;
        Game.GameOver();
    }
}