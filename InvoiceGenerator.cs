using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorDay30
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRespository rideRespository;

        private readonly double Minimum_Cost_Per_Km;
        private readonly double Cost_Per_Time;
        private readonly double Minimum_Fare;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRespository = new RideRespository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.Minimum_Cost_Per_Km = 12;
                    this.Cost_Per_Time = 2;
                    this.Minimum_Fare = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.Minimum_Cost_Per_Km = 10;
                    this.Cost_Per_Time = 1;
                    this.Minimum_Fare = 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
            }
        }

        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * Minimum_Cost_Per_Km + time * Cost_Per_Time;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Ride_Type, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Distance, "Invalid Distance");

                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.Invalid_Time, "Invalid Time");
                }
            }
            return Math.Max(totalFare, Minimum_Fare);
        }

        public static InvoiceSummary CalculateFare(Ride[] rides)
        {
           
        }
    }
}
