namespace CentralizedPricingEngine.Services
{
    public class PricingService:IPricingService
    {
        public decimal CalculatePrice(decimal basePrice, string promoCode)
        {
            decimal finalPrice = basePrice;

            if (!string.IsNullOrEmpty(promoCode))
            {
                promoCode = promoCode.ToUpper();

                if(promoCode == "WINTER25")
                {
                    finalPrice = basePrice * 0.85m;
                }
                else if(promoCode == "FREESHIP")
                {
                    finalPrice = basePrice - 5.00m;
                }
            }

            return finalPrice < 0 ? 0 : finalPrice;
        }
    }
}
