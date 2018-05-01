public class Player
{
    public Player(int cakes)
    {
    }

    public boolean firstMove(int cakes){
        if((cakes % 3) == 0)
        return false;

        return true;
    }

    public int move(int cakes, int last){
        if(cakes > 10)
        {
            if(last != 3)
            {
                return 3;
            }
            else 
            {
                return 2;
            }
        }

        if(last == 3)
        {
            return 2;
        }

		return last == 1 ? 2 : 1;

    }
}