namespace TISM_Api
{
    public class Sensors
    {
        public int TemperatureC { get; set; }

        public Sensors() { }
        public Sensors(int statusCode)
        {
            if(statusCode == -1)
            {
                TemperatureC = 0;
            }
        }
    }
}
