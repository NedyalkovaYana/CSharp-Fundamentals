public interface IPhonable
{
    string Model { get; }
    string Call(string number);
}

