using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new GraphicEditor();
            circle.DrawShape(new Rectangle());
        }
    }
}
