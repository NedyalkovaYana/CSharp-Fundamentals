public class MyMood : MyFood
{
    public string GetMoodFace(MyFood food)
    {
        string mood = string.Empty;

        if (food.Points < -5)
        {
            mood = "Angry";
        }

        else if (food.Points >= -5 && food.Points < 0)
        {
            mood = "Sad";
        }

        else if (food.Points >= 0 && food.Points <= 15)
        {
            mood = "Happy";
        }

        else if (food.Points > 15)
        {
            mood = "JavaScript";
        }

        return mood;
    }
}

