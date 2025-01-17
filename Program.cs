using System;

#nullable enable

class Program
{
    static void Main()
    {
        ParkingLot? parkingLot = null;
        string? input;

        while (!string.IsNullOrEmpty(input = Console.ReadLine()) && input != "exit")
        {
            var command = input.Split(' ');
            switch (command[0])
            {
                case "create_parking_lot":
                    if (command.Length < 2 || !int.TryParse(command[1], out var size) || size <= 0)
                    {
                        Console.WriteLine("Size parkir tidak valid.");
                    }
                    else
                    {
                        parkingLot = new ParkingLot(size);
                    }
                    break;
                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parkir belum dibuat.");
                    }
                    else if (command.Length < 4)
                    {
                        Console.WriteLine("Perintah parkir tidak lengkap.");
                    }
                    else
                    {
                        parkingLot.Park(command[1], command[2], command[3]);
                    }
                    break;
                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parkir belum dibuat.");
                    }
                    else if (command.Length < 2 || !int.TryParse(command[1], out var slotNum) || slotNum <= 0)
                    {
                        Console.WriteLine("Nomor slot tidak valid.");
                    }
                    else
                    {
                        parkingLot.Leave(slotNum);
                    }
                    break;
                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Parkir belum dibuat.");
                    }
                    else
                    {
                        parkingLot.Status();
                    }
                    break;
                case "type_of_vehicles":
                    if (command.Length < 2)
                        Console.WriteLine("Jenis kendaraan harus disertakan.");
                    else
                        parkingLot?.TypeOfVehicles(command[1]);
                    break;
                case "registration_numbers_for_vehicles_with_ood_plate":
                    parkingLot?.RegistrationNumbersForOddPlate();
                    break;
                case "registration_numbers_for_vehicles_with_event_plate":
                    parkingLot?.RegistrationNumbersForEvenPlate();
                    break;
                case "registration_numbers_for_vehicles_with_colour":
                    parkingLot?.RegistrationNumbersByColor(command[1]);
                    break;
                case "slot_numbers_for_vehicles_with_colour":
                    parkingLot?.SlotNumbersByColor(command[1]);
                    break;
                case "slot_number_for_registration_number":
                    parkingLot?.SlotNumberByRegistration(command[1]);
                    break;
                default:
                    Console.WriteLine("Perintah tidak dikenal.");
                    break;
            }
        }
    }
}
