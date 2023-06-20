using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.DTOS.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomID { get; set; }
        [Required(ErrorMessage = "Lütfen oda numarası yazınız.")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Lütfen görsel koyunuz.")]
        public string RoomCoverImage { get; set; }
        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Lütfen başlık bilgisi giriniz.")]
        [StringLength(100,ErrorMessage ="Lütfen en fazla 100 karakter veri girişi yapınız.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen yatak saysısı giriniz.")]
        public string BedCount { get; set; }
        [Required(ErrorMessage = "Lütfen banyo sayısı giriniz.")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }
        [Required(ErrorMessage = "Lütfen açıklamayı  giriniz.")]
        public string Description { get; set; }
    }
}
