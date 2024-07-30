using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Builder.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create shop
            var shop = new Shop();

            // Construct and display vehicles
            shop.Construct(new ScooterBuilder());
            shop.ShowVehicle();

            shop.Construct(new CarBuilder());
            shop.ShowVehicle();

            shop.Construct(new MotorCycleBuilder());
            shop.ShowVehicle();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Shop
    {
        private VehicleBuilder _vehicleBuilder;

        // Builder uses a complex series of steps
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            _vehicleBuilder = vehicleBuilder;

            _vehicleBuilder.BuildFrame();
            _vehicleBuilder.BuildEngine();
            _vehicleBuilder.BuildWheels();
            _vehicleBuilder.BuildDoors();
        }

        public void ShowVehicle()
        {
            _vehicleBuilder.Vehicle.Show();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class VehicleBuilder
    {
        public Vehicle Vehicle { get; private set; }

        // Constructor
        public VehicleBuilder(VehicleType vehicleType)
        {
            Vehicle = new Vehicle(vehicleType);
        }

        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class MotorCycleBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public MotorCycleBuilder()
            : base(VehicleType.MotorCycle)
        {
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "MotorCycle Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class CarBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public CarBuilder()
            : base(VehicleType.Car)
        {
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Car Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "2500 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "4";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "4";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class ScooterBuilder : VehicleBuilder
    {
        // Invoke base class constructor
        public ScooterBuilder() : base(VehicleType.Scooter)
        {
        }

        public override void BuildFrame()
        {
            Vehicle[PartType.Frame] = "Scooter Frame";
        }

        public override void BuildEngine()
        {
            Vehicle[PartType.Engine] = "50 cc";
        }

        public override void BuildWheels()
        {
            Vehicle[PartType.Wheel] = "2";
        }

        public override void BuildDoors()
        {
            Vehicle[PartType.Door] = "0";
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Vehicle
    {
        private VehicleType _vehicleType;
        private Dictionary<PartType, string> _parts = new Dictionary<PartType, string>();

        // Constructor
        public Vehicle(VehicleType vehicleType)
        {
            _vehicleType = vehicleType;
        }

        public string this[PartType key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Vehicle Type: {0}", _vehicleType);
            Console.WriteLine(" Frame  : {0}",
                this[PartType.Frame]);
            Console.WriteLine(" Engine : {0}",
                this[PartType.Engine]);
            Console.WriteLine(" #Wheels: {0}",
                this[PartType.Wheel]);
            Console.WriteLine(" #Doors : {0}",
                this[PartType.Door]);
        }
    }

    /// <summary>
    /// Part type enumeration
    /// </summary>
    public enum PartType
    {
        Frame,
        Engine,
        Wheel,
        Door
    }

    /// <summary>
    /// Vehicle type enumeration
    /// </summary>
    public enum VehicleType
    {
        Car,
        Scooter,
        MotorCycle
    }
}

