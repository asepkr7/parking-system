public class Vehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    public DateTime CheckInTime { get; set; }

    public Vehicle(string regNum, string color, string type)
    {
        RegistrationNumber = regNum;
        Color = color;
        Type = type;
        CheckInTime = DateTime.Now;
    }
}