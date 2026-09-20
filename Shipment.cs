using System;
using System.Runtime.CompilerServices;

namespace Assigment.Net.OOP3
{
    public class Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public string TrackingCode
        {
            get { return trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    trackingCode = value;
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }

        public DeliveryAddress Destination { get; set; }

        public virtual decimal EstimatedCost
        {
            get
            {
                return deliveryFee + (weight * 5);
            }
        }

        public void WeightUpdate(decimal weight)
        {
            Weight = weight;
        }

        public void WeightUpdate(decimal weight, decimal extraWeight)
        {
            Weight = weight + extraWeight;
        }

        public Shipment(string trackingCode)
        {
            TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1m;
            DeliveryFee = 50m;
            Destination = default(DeliveryAddress);
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code : {TrackingCode}");
            Console.WriteLine($"Description   : {Description}");
            Console.WriteLine($"Weight        : {Weight} kg");
            Console.WriteLine($"Delivery Fee  : {DeliveryFee}");
        }
    }

    public class StandardShipment : Shipment
    {
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            base.PrintShipment();
            Console.WriteLine(EstimatedCost);
        }

    }

    public class ExpressShipment : Shipment
    {
        private decimal extraFee;
        public decimal ExtraFee
        {
            get
            {
                return extraFee;
            }
            set
            {
                if (value >= 0)
                {
                    extraFee = value;
                }
            }
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + ExtraFee;
            }
        }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }
        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");   // ناقصة
            base.PrintShipment();
            Console.WriteLine($"Extra Fee: {ExtraFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
        }
    }


    public class InternationalShipment : Shipment
    {

        private string destinationCountry;
        private decimal customsFee;

        public string DestinationCountry
        {
            get
            {
                return destinationCountry;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;
                }
            }
        }
        public decimal CustomsFee
        {
            get
            {
                return customsFee;
            }
            set
            {
                if (value >= 0)
                {
                    customsFee = value;
                }
            }
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5) + CustomsFee;
            }
        }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            base.PrintShipment();
            Console.WriteLine($"Dest Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee   : {CustomsFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs Report for {TrackingCode}");
            Console.WriteLine($"Destination Country : {DestinationCountry}");
            Console.WriteLine($"Customs Fee         : {CustomsFee}");
        }

    }

    public sealed class CompletedShipment : Shipment
    {
        public DateTime Time { get; set; }
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, DateTime time)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            Time = time;
        }
    }
}
