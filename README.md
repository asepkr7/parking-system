# Parking Lot Management System

This repository contains a **Parking Lot Management System** implemented in C#. The system allows users to create a parking lot, park vehicles, manage slots, and retrieve vehicle information based on various criteria.

## Features

1. **Create Parking Lot**: Initialize a parking lot with a specified number of slots.
2. **Park Vehicles**: Add a vehicle to the parking lot if space is available. Supports only `Mobil` and `Motor`.
3. **Leave Slot**: Vacate a specific parking slot.
4. **Display Status**: Display the current status of all occupied slots.
5. **Search Vehicles by Criteria**:
   - Registration numbers of vehicles with odd/even plate numbers.
   - Vehicles with a specific color.
   - Slot numbers for vehicles with a specific color.
   - Slot number of a vehicle by its registration number.
6. **Count Vehicles by Type**: Show the count of parked vehicles by type (`Motor` or `Mobil`).

## Commands

| Command                                         | Description                                                                 |
|------------------------------------------------|-----------------------------------------------------------------------------|
| `create_parking_lot <size>`                    | Creates a parking lot with the given number of slots.                      |
| `park <registration_number> <color> <type>`    | Parks a vehicle with the given details (`type` must be `Mobil` or `Motor`).|
| `leave <slot_number>`                          | Vacates the specified slot.                                                |
| `status`                                       | Displays the current status of the parking lot.                            |
| `registration_numbers_for_vehicles_with_ood_plate` | Displays registration numbers of vehicles with odd plate numbers.          |
| `registration_numbers_for_vehicles_with_event_plate`| Displays registration numbers of vehicles with even plate numbers.         |
| `registration_numbers_for_vehicles_with_colour <color>`| Displays registration numbers of vehicles with the specified color.       |
| `slot_numbers_for_vehicles_with_colour <color>`| Displays slot numbers for vehicles with the specified color.               |
| `slot_number_for_registration_number <registration_number>`| Displays the slot number for a vehicle with the specified registration number.|
| `type_of_vehicles <type>`                      | Displays the count of vehicles of the specified type (`Mobil` or `Motor`). |

## Example Usage

```bash
$ create_parking_lot 6
Created a parking lot with 6 slots

$ park KA-01-HH-1234 White Mobil
Allocated slot number: 1

$ park KA-01-HH-9999 Red Motor
Allocated slot number: 2

$ type_of_vehicles Motor
1

$ type_of_vehicles Mobil
1

$ status
Slot No.   Registration No.      Type       Colour    
1          KA-01-HH-1234         Mobil      White     
2          KA-01-HH-9999         Motor      Red       

$ leave 1
Slot number 1 is free
