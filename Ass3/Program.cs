namespace Ass3
{

   public  enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    public class Commodity
    {
        public CommodityCategory Category { get; set; }

        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }


        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;
        }
    }
    public class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        private CommodityCategory category;

        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (!_taxRates.ContainsKey(category))
            {
                _taxRates.Add(category, taxRate);
            }
        }
    

        public double CalculateBillAmount(IList<Commodity> items)
        {
            double total = 0;
            

            foreach (Commodity i in items)
            {
                double tax = 0, price = 0;

                try
                {
                    if (!_taxRates.ContainsKey(category))
                    {
                        throw new ArgumentException("tax not added ");
                    }
                    else
                    {
                        price = i.CommodityPrice * i.CommodityQuantity;
                        tax = ((i.CommodityPrice * _taxRates[i.Category]) / 100) * i.CommodityQuantity;

                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                total += price + tax;

               
            }
            return total;
            

        }
    }
    public class program
    {



        static void Main(string[] args)
        {
            var commodities = new List<Commodity>() {
                     new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
                new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
                new Commodity(CommodityCategory.Service, "Insurance", 8, 8500)
                };
            var prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine($"Total Bill Amount: {billAmount}");

        }
    }
}


