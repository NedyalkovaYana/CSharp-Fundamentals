
using DependencyInversion.Strategies;

public class PrimitiveCalculator
{
    private IStrategy strategy;

    public PrimitiveCalculator()
    {
        this.strategy = new AdditionStrategy();
    }

    public void ChangeStrategy(char @operator)
    {
        switch (@operator)
        {
            case '+':
                this.strategy = new AdditionStrategy();
                break;
            case '-':
                this.strategy = new SubtractionStrategy();
                break;
            case '*':
                this.strategy = new MultipleStrategy();
                break;
            case '/':
                this.strategy = new DividerStrategy();
                break;
        }
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
       return this.strategy.Calculate(firstOperand, secondOperand);
    }
}

