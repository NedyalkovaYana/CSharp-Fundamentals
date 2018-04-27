using System;
public class TypeAttribute : Attribute
{
    public string Type { get; set; }
    public string Category { get; set; }
    public string Descripton { get; set; }

    public TypeAttribute(string type, string category, string descripton)
    {
        this.Type = type;
        this.Category = category;
        this.Descripton = descripton;
    }

    public override string ToString()
    {
        return $"Type = {this.Type}, Descripton = {this.Descripton}";
    }
}

