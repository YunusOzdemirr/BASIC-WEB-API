using CustomerHomework.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerHomework.Entities.Dtos
{
    public class CustomerDeleteDto
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden küçük olmalıdır.")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olmalıdır.")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden küçük olmalıdır.")]
        [MinLength(2, ErrorMessage = "{0} alanı {1} karakterden büyük olmalıdır.")]
        public string LastName { get; set; }
        [DisplayName("E-Posta Adresi")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden küçük olmalıdır.")]
        [MinLength(10, ErrorMessage = "{0} alanı {1} karakterden büyük olmalıdır.")]
        public string EmailAddress { get; set; }
        [DisplayName("Yaş")]
        public int Age { get; set; }
        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public Gender Gender { get; set; }
        [DisplayName("Oluşturulma Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Değiştirilme Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public DateTime ModifiedDate { get; set; }
    }
}
