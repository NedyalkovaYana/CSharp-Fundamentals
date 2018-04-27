 using System.Collections.Generic;
 using System.Linq;
 using System.Reflection;
 using System.Text;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var command = string.Empty;

            var allFields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                                                  BindingFlags.Public | BindingFlags.Static);


            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "all":
                        Console.WriteLine(AppendFields(allFields));
                        break;
                    case "private":
                        Console.WriteLine(AppendFields(allFields.Where(a => a.IsPrivate)));
                        break;
                    case "public":
                        Console.WriteLine(AppendFields(allFields.Where(a => a.IsPublic)));
                        break;
                    case "protected":
                        Console.WriteLine(AppendFields(allFields.Where(a => a.IsFamily)));
                        break;
                }
            }
        }

        private static string AppendFields(IEnumerable<FieldInfo> fieldsCollection)
        {
            var sb = new StringBuilder();
            foreach (var field in fieldsCollection)
            {
                var accessmodifare = field.Attributes.ToString().ToLower();

                if (accessmodifare.Equals("family"))
                {
                    accessmodifare = "protected";
                }
                sb.AppendLine($"{accessmodifare} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}
