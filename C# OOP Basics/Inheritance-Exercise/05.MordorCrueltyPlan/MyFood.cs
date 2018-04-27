using System.Collections.Generic;

public class MyFood
{
    private int points;
   
    public int Points
    {
        get { return this.points; }
        private set { this.points = value; }
    }

    public void AddFoodType(string foodType)
    {
        switch (foodType.ToLower())
        {
            case "cram":
                this.Points += 2;
                break;
            case "lembas":
                this.Points += 3;
                    break;
            case "apple":
                this.Points += 1;
                break;
            case "melon":
                this.Points += 1;
                break;
            case "honeycake":
                this.Points += 5;
                break;
            case "Mushrooms":
                this.Points += -10;
                break;
            default:
                this.Points += - 1;
                break;
        }
    }




}

