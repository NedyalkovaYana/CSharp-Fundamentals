public abstract class Gem : IGem
{
    protected Gem(GemClarity clarity, int agilityBonus, int strengthBonus, int vitalityBonus)
    {
        this.Clarity = clarity;
        this.AgilityBonus = agilityBonus + (int)clarity;
        this.StrenghtBonus = strengthBonus + (int)clarity;
        this.VatilityBonus = vitalityBonus + (int)clarity;
    }

    public GemClarity Clarity { get; private set; }
    public int StrenghtBonus { get; }

    public int AgilityBonus { get; private set; }
    public int VatilityBonus { get; }

}