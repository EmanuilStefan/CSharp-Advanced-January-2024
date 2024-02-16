using System.Text;

namespace AutomotiveRepairShop;

public class RepairShop
{
    public RepairShop(int capacity)
    {
        Capacity = capacity;
        Vehicles = new List<Vehicle>();
    }
    public RepairShop(int capacity, List<Vehicle> vehicles) : this(capacity)
    {
        Vehicles.AddRange(vehicles);
    }

    public int Capacity { get; set; }
    public List<Vehicle> Vehicles { get; set; }

    public void AddVehicle(Vehicle vehicle)
    {
        if (Vehicles.Count < Capacity)
        {
            Vehicles.Add(vehicle);
        }
    }
    public bool RemoveVehicle(string vin)
    {
        Vehicle vehicleToRemove = Vehicles.FirstOrDefault(x => x.VIN == vin);
        if (Vehicles.Count > 0 && Vehicles.Contains(vehicleToRemove))
        {
            Vehicles.Remove(vehicleToRemove);
            return true;
        }
        return false;
    }

    public int GetCount()
    {
        return Vehicles.Count;
    }

    public Vehicle GetLowestMileage()
    {
        int lowestMileage = Vehicles.Min(x=> x.Mileage);
        if (Vehicles.Any())
        {
            return Vehicles.FirstOrDefault(x=>x.Mileage == lowestMileage);
        }
        return default;
    }

    public string Report()
    {
        StringBuilder reportBuilder = new StringBuilder();

        reportBuilder.Append("Vehicles in the preparatory:");
        reportBuilder.Append(Environment.NewLine);

        foreach (Vehicle vehicle in Vehicles)
        {
            reportBuilder.Append(vehicle.ToString());
            reportBuilder.Append(Environment.NewLine);
        }

        return reportBuilder.ToString().TrimEnd();
    }
}