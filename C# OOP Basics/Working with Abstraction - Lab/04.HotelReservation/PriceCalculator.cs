public class PriceCalculator
{
    //price per day, number of days, the season and a discount type
    public decimal PricePerDay { get; set; }

    public int NumberOfDays { get; set; }
    public string Season { get; set; }
    public string Discount { get; set; }

    public PriceCalculator(decimal pricePerDay, int numberOfDays, string season, string discount)
    {
        PricePerDay = pricePerDay;
        NumberOfDays = numberOfDays;
        Season = season;
        Discount = discount;
    }

    public decimal CalcPriceForAllHolyday()
    {
        var totalSumWithoutDiscount = 0m;
        var totalPriceAfterDiscount = 0m;

        switch (this.Season)
        {
            case "Spring":
                totalSumWithoutDiscount = (PricePerDay * NumberOfDays) * 2;              
                break;
            case "Summer":
                totalSumWithoutDiscount = (PricePerDay * NumberOfDays) * 4;
                break;
            case "Autumn":
                totalSumWithoutDiscount = (PricePerDay * NumberOfDays) * 1;
                break;
            case "Winter":
                totalSumWithoutDiscount = (PricePerDay * NumberOfDays) * 3;
                break;
        }

       var finalPrice =  this.CalcDiscunt(totalSumWithoutDiscount);
        return finalPrice;
    }

    public decimal CalcDiscunt(decimal totalSUmWithoutDiscount)
    {
        var finalPrice = 0m;
        if (this.Discount == null || this.Discount == "None")
        {
            finalPrice = totalSUmWithoutDiscount;
        }
        else
        {
            if (this.Discount.ToLower() == "vip")
            {
                finalPrice = totalSUmWithoutDiscount - ((totalSUmWithoutDiscount *  20) / 100);
            }
            else if (this.Discount.ToLower() == "secondvisit")
            {
                finalPrice = totalSUmWithoutDiscount - ((totalSUmWithoutDiscount * 10) / 100);
            }
        }
        return finalPrice;
    }
}

