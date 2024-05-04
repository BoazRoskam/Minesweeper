public class EmptyTile : Tile{
 
    public override string TileIcon{
        get{
            if(IsOpend) return $"[ ]";
            else return "[?]";
            //else return "[ ]";
        }
    } 

    public EmptyTile(int verIndex, int horIndex) : base(verIndex, horIndex){

    }

    public override void OpenTile()
    {
        IsOpend = true;
        Game.Grid.OpenInRange(VerIndex, HorIndex);
    }
}