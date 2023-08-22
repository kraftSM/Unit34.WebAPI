using System.Net;

namespace Unit34.WebAPI.Configuration
{
    /// <summary>
    /// Информация о нашем доме
    /// </summary>
    public class HomeOptions
    {
        public  string Descrption  { get; set; } = "Descrption of Residence"; 
        public int FloorAmount { get; set; }
        public string Telephone { get; set; }
        public Heating Heating { get; set; }
        public int CurrentVolts { get; set; }
        public bool GasConnected { get; set; }
        public int Area { get; set; }
        public Material Material { get; set; }
        public Address Address { get; set; }
    }
}
