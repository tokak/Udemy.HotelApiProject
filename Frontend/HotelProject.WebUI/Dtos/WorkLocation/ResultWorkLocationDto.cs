using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.WorkLocation
{
    public class ResultWorkLocationDto
    {
        public int WorkLocationID { get; set; }
        public string? WorkLocationName { get; set; }
        public string? WorkLocationCity { get; set; }
    }
}
