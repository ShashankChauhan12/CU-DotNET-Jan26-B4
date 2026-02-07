namespace FreightTrackingSystem
{
    public class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message) : base(message)
        {
        }
    }
    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message) : base(message)
        {
        }
    }


    public abstract class Shipment
    {
        public string TrackingID { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        protected Shipment(string tr, double we, string dt,bool iF, bool ir)
        {
            TrackingID = tr;
            Weight = we;
            Destination = dt;
            IsFragile = iF;
            IsReinforced = ir;
        }

        public abstract void ProcessShipment();
    }

    public class ExpressShipment : Shipment
    {
        public ExpressShipment(string tr, double we, string dt, bool iF, bool ir) : base(tr, we, dt, iF, ir)
        {
        }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException();

            if (Destination == "North Pole" || Destination == "Unknown Island")
                throw new RestrictedDestinationException("Restricted Destination Zone");

            if (IsFragile && !IsReinforced)
                throw new InsecurePackagingException("Fragile items must be reinforced");

            Console.WriteLine($"Express shipment: {TrackingID}");

        }
    }

    public class HeavyFreight : Shipment
    {
        public bool HasPermit { get; set; }
        public HeavyFreight(string tr, double we, string dt, bool iF, bool ir, bool hp) : base(tr, we, dt, iF, ir)
        {
            HasPermit = hp;
        }

        public override void ProcessShipment()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException();

            if (Destination == "North Pole" || Destination == "Unknown Island")
                throw new RestrictedDestinationException("Restricted Destination Zone");

            if (IsFragile && !IsReinforced)
                throw new InsecurePackagingException("Fragile items must be reinforced");

            if (Weight > 1000 && !HasPermit)
                throw new Exception("Heavy Lift permit required");

            Console.WriteLine($"Heavy lift shipment: {TrackingID}");

        }
    }

    public interface ILoggable
    {
        void SaveLog(string message);
    }

    class LogManager : ILoggable
    {
        string logFile = @"..\..\..\shipment_audit.log";

        public void SaveLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(logFile, true))
            {
                sw.WriteLine(message);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            LogManager logg=new LogManager();

            List<Shipment> shipments = new List<Shipment>
            {
                new ExpressShipment("ABCD1267",400.00,"Australia",true, true),
                new HeavyFreight("ECOR0098",1200.54,"Russia",true, true,false),
                new ExpressShipment("TEWM5643",66,"Unknown Island",false, false),
                new HeavyFreight("TUEM9010",1549.00,"Finland",true,true,true),

            };


            foreach (var ship in shipments){
                try{
                    ship.ProcessShipment();

                    logg.SaveLog($"SUCCESS: Shipment {ship.TrackingID} processed.");
                } 
                catch (RestrictedDestinationException ex)
                {
                    logg.SaveLog($"Security Alert: Shipment  {ship.TrackingID}- {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logg.SaveLog($"Data Entry Error: Shipment  {ship.TrackingID} having wrong weight");
                }
                catch (Exception ex)
                {
                    logg.SaveLog($"ERROR: Shipment {ship.TrackingID}- {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {ship.TrackingID}");
                }

            }
        }
    }
}
