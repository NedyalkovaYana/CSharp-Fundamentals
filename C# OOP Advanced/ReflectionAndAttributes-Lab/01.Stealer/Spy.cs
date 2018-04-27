using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] namesofFields)
    {
        var findedClass = Type.GetType(investigatedClass);
        var findedFields = findedClass.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
            | BindingFlags.Static | BindingFlags.Public);

        var classInstance = Activator.CreateInstance(findedClass, new object[] {});



        var sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {findedClass}");

        foreach (var field in findedFields.Where(f => namesofFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}

