using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.DataModels
{
    [Table("Permission")]
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }

        [Required(ErrorMessage ="not null")]
        [Display(Name ="Tên quyền")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string PermissionName { get; set; }

        [Required(ErrorMessage = "not null")]
        [Display(Name ="Mô tả")]
        [MaxLength(256)]
        public string Description { get; set; }

        [Required(ErrorMessage = "not null")]
        [ForeignKey("Business")]
        [Display(Name ="Mã nghiệp vụ")]
        public string BusinessId { get; set; }

        public virtual Business Business { get; set; }
    }
}