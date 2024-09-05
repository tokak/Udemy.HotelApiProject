using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linkini giriniz")]
        public string ServicesIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığını giriniz")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı 100 karekter olabilir.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması giriniz")]
        [StringLength(1000, ErrorMessage = "Hizmet açıklaması en fazla 1000 karekter olabilir.")]
        public string Description { get; set; }
    }
}
