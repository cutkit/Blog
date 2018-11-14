using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.DataModels
{
    [Table("GrantPermission")]
    public class GrantPermission
    {
        [Key]
        [ForeignKey("Administrator")]
        [Required(ErrorMessage = "not null")]
        [Display(Name ="Mã quyền")]
        [Column(Order =2)]
        public int UserId { get; set; }

        [Key]
        [ForeignKey("Permission")]
        [Required(ErrorMessage = "not null")]
        [Column(Order =1)]
        public int PermissionId { get; set; }

        [MaxLength(256)]
        [Display(Name ="Mô tả quyền cấp cho admin")]
        public string Description { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual Permission Permission { get; set; }
    }
}