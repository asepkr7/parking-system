using System;
using System.Collections.Generic;
using System.Linq;

#nullable enable
public class ParkingLot
{
    private List<Slot> Slots;

    public ParkingLot(int size)
    {
        Slots = new List<Slot>();
        for (int i = 1; i <= size; i++)
            Slots.Add(new Slot(i));
        Console.WriteLine($"Created a parking lot with {size} slots");
    }

    public void Park(string regNum, string color, string type)
    {
        if (type != "Mobil" && type != "Motor")
        {
            Console.WriteLine("Hanya Mobil dan Motor yang boleh masuk.");
            return;
        }

        var slot = Slots.FirstOrDefault(s => !s.IsOccupied);
        if (slot != null)
        {
            slot.ParkedVehicle = new Vehicle(regNum, color, type);
            Console.WriteLine($"Allocated slot number: {slot.Number}");
        }
        else
        {
            Console.WriteLine("Sorry, parking lot is full");
        }
    }

    public void Leave(int slotNumber)
    {
        if (slotNumber <= 0 || slotNumber > Slots.Count)
        {
            Console.WriteLine("Nomor slot tidak valid.");
            return;
        }

        var slot = Slots[slotNumber - 1];
        if (slot.IsOccupied)
        {
            slot.ParkedVehicle = null;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine("Slot sudah kosong.");
        }
    }

    public void Status()
    {
        Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", "Slot No.", "Registration No.", "Type", "Colour");
        foreach (var slot in Slots.Where(s => s.IsOccupied))
        {
            var v = slot.ParkedVehicle;
            if (v != null)
                Console.WriteLine("{0,-10} {1,-20} {2,-10} {3,-10}", slot.Number, v.RegistrationNumber, v.Type, v.Color);
        }
    }

    public void TypeOfVehicles(string type)
    {
        var count = Slots.Count(s => s.IsOccupied && s.ParkedVehicle!.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(count);
    }

    public void RegistrationNumbersForOddPlate()
    {
        var result = Slots.Where(s => s.IsOccupied && IsOddPlate(s.ParkedVehicle!.RegistrationNumber))
                          .Select(s => s.ParkedVehicle!.RegistrationNumber);
        Console.WriteLine(string.Join(", ", result));
    }

    public void RegistrationNumbersForEvenPlate()
    {
        var result = Slots.Where(s => s.IsOccupied && !IsOddPlate(s.ParkedVehicle!.RegistrationNumber))
                          .Select(s => s.ParkedVehicle!.RegistrationNumber);
        Console.WriteLine(string.Join(", ", result));
    }

    public void RegistrationNumbersByColor(string color)
    {
        var result = Slots.Where(s => s.IsOccupied && s.ParkedVehicle!.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                          .Select(s => s.ParkedVehicle!.RegistrationNumber);
        Console.WriteLine(string.Join(", ", result));
    }

    public void SlotNumbersByColor(string color)
    {
        var result = Slots.Where(s => s.IsOccupied && s.ParkedVehicle!.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                          .Select(s => s.Number);
        Console.WriteLine(string.Join(", ", result));
    }

    public void SlotNumberByRegistration(string regNum)
    {
        var slot = Slots.FirstOrDefault(s => s.IsOccupied && s.ParkedVehicle!.RegistrationNumber == regNum);
        Console.WriteLine(slot != null ? slot.Number.ToString() : "Not found");
    }

    private bool IsOddPlate(string regNum)
    {
        var numbers = new string(regNum.Where(char.IsDigit).ToArray());
        return numbers.Length > 0 && int.Parse(numbers.Last().ToString()) % 2 != 0;
    }
}
