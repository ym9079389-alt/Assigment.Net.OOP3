namespace Assigment.Net.OOP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q 1

            #region a
            //a)  What is the difference between Method Overloading and Method Overriding?
            //The purpose of method overloading is to reuse the function in more than one way,
            //while method overriding is to change the base function in more than one place.
            #endregion

            #region b
            //b)  What is the difference between Static Binding and Dynamic Binding?
            //Static Binding => Early Binding is called during code reading.
            //Dynamic Binding => Late لآinding is called in run time.
            #endregion

            #endregion

            #region Q 2

            #region a
            //a)  What is the purpose of the sealed keyword when applied to a class?
            //To prevent inheritance by any other class after that.
            #endregion

            #region b
            //b)  What is the difference between a sealed class and a sealed method?
            //A sealed class cannot be inherited by any other class.
            //A sealed method is a method that cannot be overridden in any derived class, but the class itself can still be inherited.
            #endregion

            #region c
            //c)  Can a sealed method be overridden? Why?
            //Yes, this keyword prevents inheritance for any method after that, not just the method it is on.
            #endregion

            #endregion

            #region Q 3
            
                Console.WriteLine("Delivery Center");

                Driver driver = new Driver("D001", "Ahmed Mohamed", "01000000000");

                DeliveryCenter center = new DeliveryCenter("Cairo Hub");

                center.Driver = driver;
                Console.WriteLine($"Driver : {center.Driver.FullName}");

                StandardShipment standard = new StandardShipment("SH01", "Laptop", 3, 80,new DeliveryAddress("Cairo", "Tahrir St", 12));

                ExpressShipment express = new ExpressShipment("SH002", "Mobile Phone", 2, 60, new DeliveryAddress("Giza", "Haram St", 5), 30);

                InternationalShipment international = new InternationalShipment("SH003", "Television", 8, 120, new DeliveryAddress("Berlin", "Alex Platz", 9), "Germany", 100);

                center.AddShipment(standard);
                center.AddShipment(express);
                center.AddShipment(international);

                center.PrintAllShipments();

                // i. Call DeliveryHelper.PrintShipmentDetails() for each shipment
                Console.WriteLine("==========================================");
                Console.WriteLine("Printing Using DeliveryHelper...");
                DeliveryHelper.PrintShipmentDetails(standard);
                DeliveryHelper.PrintShipmentDetails(express);
                DeliveryHelper.PrintShipmentDetails(international);

                // j. Demonstrate both versions of UpdateWeight()
                Console.WriteLine("==========================================");
                Console.WriteLine("Updating Weight...");
                Console.WriteLine($"Original Weight : {standard.Weight} KG");
                standard.WeightUpdate(5);
                Console.WriteLine($"Updated Weight : {standard.Weight} KG");
                standard.WeightUpdate(5, 0.5m);
                Console.WriteLine($"Updated Weight After Packing : {standard.Weight} KG");

                // k. Build a Shipment[] holding mixed types and print all of them in a loop
                Console.WriteLine("==========================================");
                Console.WriteLine("Printing Using Shipment[]...");
                Shipment[] mixed = new Shipment[] { standard, express, international };
                foreach (Shipment s in mixed)
                {
                    Console.WriteLine($"{s.GetType().Name}...");
                }

                // l. Demonstrate the sealed class and sealed method
                Console.WriteLine("==========================================");
                Console.WriteLine("Demonstrating sealed class and sealed method...");

                // Sealed class: CompletedShipment cannot be inherited further.
                CompletedShipment completed = new CompletedShipment("SH004", "Documents", 1, 40, new DeliveryAddress("Alexandria", "Corniche", 3), DateTime.Now);
                completed.PrintShipment();

                // Sealed method: PriorityInternationalShipment.GenerateCustomsReport()
                // overrides InternationalShipment's virtual method and seals it,
                // so no further subclass can override it again.
                PriorityInternationalShipment priority = new PriorityInternationalShipment("SHAA005", "Medical Supplies", 4, 150, new DeliveryAddress("Paris", "Champs-Elysees", 1), "France", 90);
                priority.GenerateCustomsReport();

            #endregion
        }
    }
}
