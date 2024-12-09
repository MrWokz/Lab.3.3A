using System;

// Road class
public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public int CurrentTrafficLevel { get; set; } // from 0 to 100

    public Road(double length, double width, int numberOfLanes, int currentTrafficLevel)
    {
        Length = length;
        Width = width;
        NumberOfLanes = numberOfLanes;
        CurrentTrafficLevel = currentTrafficLevel;
    }

    public override string ToString()
    {
        return $"Road: Length = {Length} m, Width = {Width} m, Number of lanes = {NumberOfLanes}, Traffic level = {CurrentTrafficLevel}%";
    }
}

// Vehicle class
public class Vehicle
{
    public double Speed { get; set; } // in km/h
    public double Size { get; set; } // in meters (length)
    public string Type { get; set; } // Vehicle type, e.g., "Car", "Truck", "Bus"

    public Vehicle(double speed, double size, string type)
    {
        Speed = speed;
        Size = size;
        Type = type;
    }

    public override string ToString()
    {
        return $"Vehicle type: {Type}, Speed = {Speed} km/h, Size = {Size} m";
    }
}

// IDriveable interface
public interface IDriveable
{
    void Move();
    void Stop();
}

// Class implementing IDriveable
public class VehicleMovement : Vehicle, IDriveable
{
    public VehicleMovement(double speed, double size, string type) : base(speed, size, type) { }

    public void Move()
    {
        Console.WriteLine($"{Type} is moving at {Speed} km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Type} has stopped.");
    }
}

// Main program class
public class Program
{
    public static void Main(string[] args)
    {
        // Collect road data from the user
        Console.WriteLine("Enter road details:");
        Console.Write("Length (in meters): ");
        double length = Convert.ToDouble(Console.ReadLine());
        Console.Write("Width (in meters): ");
        double width = Convert.ToDouble(Console.ReadLine());
        Console.Write("Number of lanes: ");
        int numberOfLanes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Current traffic level (0-100): ");
        int currentTrafficLevel = Convert.ToInt32(Console.ReadLine());

        Road road = new Road(length, width, numberOfLanes, currentTrafficLevel);
        Console.WriteLine(road);

        // Collect vehicle data from the user
        Console.WriteLine("\nEnter vehicle details:");
        Console.Write("Vehicle type (e.g., Car, Truck, Bus): ");
        string type = Console.ReadLine();
        Console.Write("Speed (in km/h): ");
        double speed = Convert.ToDouble(Console.ReadLine());
        Console.Write("Size (in meters): ");
        double size = Convert.ToDouble(Console.ReadLine());

        VehicleMovement vehicle = new VehicleMovement(speed, size, type);
        Console.WriteLine(vehicle);

        // Repeat actions until user decides to stop
        bool continueDriving = true;
        while (continueDriving)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Move the vehicle");
            Console.WriteLine("2. Stop the vehicle");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    vehicle.Move();
                    break;
                case "2":
                    vehicle.Stop();
                    break;
                case "3":
                    continueDriving = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("Program has ended.");
    }
}
