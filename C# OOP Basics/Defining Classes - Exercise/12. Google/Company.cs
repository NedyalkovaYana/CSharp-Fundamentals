public class Company
{
    // company<companyName> <department> <salary>”
    private string companyName;
    private string department;
    private decimal salary;

    public Company(string companyName, string department, decimal salary)
    {
        this.companyName = companyName;
        this.department = department;
        this.salary = salary;
    }
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }

    public override string ToString()
    {
        return $"{this.CompanyName} {this.Department} {this.Salary:f2}";
    }
}

