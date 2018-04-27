using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        try
        {
            //Type boxType = typeof(Box);

            //FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            //Console.WriteLine(fields.Count());

            var lenght = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var box = new Box(lenght, width, height);
            Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {box.Volume():f2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);          
        }
    }
}

