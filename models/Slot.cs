public class Slot
{
    public int Number { get; set; }
    public Vehicle? ParkedVehicle { get; set; }
    public bool IsOccupied => ParkedVehicle != null;

    public Slot(int number)
    {
        Number = number;
        ParkedVehicle = null;
    }
}
