using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Hizmet ikon linkini giriniz")]
        public string ServicesIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığını giriniz")]
        [StringLength(100,ErrorMessage ="Hizmet başlığı 100 karekter olabilir.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
