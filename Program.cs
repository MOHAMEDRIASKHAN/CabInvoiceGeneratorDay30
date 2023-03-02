using GoogleApi.Entities.Maps.Common;

namespace CabInvoiceGeneratorDay30
{
    class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To cab Invoice Generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double flare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare : {Fare}");
        }
    }
}