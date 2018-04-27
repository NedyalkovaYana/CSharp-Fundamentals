public abstract class Food
{
    public int quantity;

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }
    public int Quantity { get; private set; }
    
}

