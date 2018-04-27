public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }
    public decimal Salary
    {
        get { return salary; }
        private set { salary = value; }
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }

    public string LastName
    {
        get { return lastName; }
        private set { lastName = value; }
    }


    public string FirstName
    {
        get { return firstName; }
        private set { firstName = value; }
    }

    public void GetBonus(decimal bonusPercent)
    {
        if (this.Age < 30)
        {
            bonusPercent /= 2;
        }
        this.Salary += (Salary * bonusPercent) / 100;
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} get {this.Salary:f2} leva";
    }
}

