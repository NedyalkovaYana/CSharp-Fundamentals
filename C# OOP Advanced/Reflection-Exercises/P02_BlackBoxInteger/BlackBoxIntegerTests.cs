using System.Linq;
using System.Reflection;
using System.Text;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
          var createdClass = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");

            var createdInstance = (BlackBoxInteger) Activator.CreateInstance(createdClass, true);
            var methods = createdClass
                .GetMethods
                (BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);

            var fields = createdClass
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var commands = string.Empty;
            var sb = new StringBuilder();

            while ((commands = Console.ReadLine()) != "END")
            {
                var tokens = commands.Split('_');
                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                var currentMethod = methods.FirstOrDefault(m => m.Name == command);
                currentMethod?.Invoke(createdInstance, new object[] {value});

                foreach (var field in fields)
                {
                    sb.AppendLine(field.GetValue(createdInstance).ToString());
                }

                Console.WriteLine(sb.ToString().Trim());
                sb.Clear();
            }
        }
    }
}
