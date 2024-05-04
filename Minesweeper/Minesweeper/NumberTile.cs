public class NumberTile : Tile{

    public int Number{get;}
    public override string TileIcon{
        get{
            if(IsOpend) return $"[{Convert.ToString(Number)}]";
            else return "[?]";
            //else return $"[{Convert.ToString(Number)}]";
        }
    } 

    public NumberTile(int verIndex, int horIndex, int number) : base(verIndex, horIndex){
        Number = number;
    }

    

    public override void OpenTile()
    {
        IsOpend = true;

    }
}