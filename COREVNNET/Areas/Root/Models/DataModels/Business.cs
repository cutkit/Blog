using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.DataModels
{
    [Table("Business")]
    public class Business
    {
        [Key]
        [MaxLength(64)]
        [Display(Name ="Mã nghiệp vụ (Controller)")]
        [Column(TypeName ="varchar")]
        public string BusinessId { get; set; }

        [Required]
        [MaxLength(256)]
        [Display(Name ="Tên nghiệp vụ (Controller)")]
        public string BusinessName { get; set; }
    }
}