using System;

namespace video5
{
    public delegate Car CarFactoryDel(int id, string name);
    public delegate void logDetailsIceCarContravariance(ICEcar icecar);
    public delegate void logDetailsEvCarContravariance(EVcar eVcar);
    class Program
    {
        static void Main(string[] args)
        {
            CarFactoryDel carFactoryDel = CarFactory.ReturnCar;
            Car icecar = carFactoryDel(1, "BMW");

            Console.WriteLine($"{icecar.GetType()}");
            Console.WriteLine($"{icecar.GetDetails()}");

            Console.WriteLine("-------------------------------------------------");
            carFactoryDel = CarFactory.ReturnEvCar;
            Car evcar = carFactoryDel(1, "Tesla");
            Console.WriteLine($"{evcar.GetType()}");
            Console.WriteLine($"{evcar.GetDetails()}");

            Console.WriteLine("-----------------------Contravariance--------------------------");
            logDetailsIceCarContravariance logDetailsIceCarContravariance = logCarDetails;
            logDetailsIceCarContravariance(icecar as ICEcar);

            logDetailsEvCarContravariance logDetailsEvCarContravariance = logCarDetails;
            logDetailsEvCarContravariance(evcar as EVcar);

            Console.ReadKey();
        }


        static void logCarDetails(Car car)
        {
            if(car is ICEcar)
            {
                Console.WriteLine($"{car.GetType()}");
                Console.WriteLine($"{car.GetDetails()}");
            }
            else if(car is EVcar) 
            {
                Console.WriteLine($"{car.GetType()}");
                Console.WriteLine($"{car.GetDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public static class CarFactory
    {
        public static ICEcar ReturnCar(int id , string name)
        {
            return new ICEcar { Id = id, Name = name };

        }

        public static EVcar ReturnEvCar(int id, string name)
        {
            return new EVcar { Id = id, Name = name };

        }
    } 
    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual string GetDetails()
        {
           return $"{Id} - {Name}";
        } 
    }

    public class ICEcar : Car
    {
        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }

    public class EVcar : Car
    {
        public override string GetDetails()
        {
            return base.GetDetails();
        }
    }
}
