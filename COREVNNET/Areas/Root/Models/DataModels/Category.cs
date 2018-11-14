using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.DataModels
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Display(Name ="id chủ đề(đánh theo A,B,C,D)")]
        public string CategoryId { get; set; }

        [Display(Name ="Tên chủ đề")]
        [Required(ErrorMessage ="Nhập tên chủ đề")]
        [StringLength(256)]
        public string CategoryName { get; set; }

        [Display(Name ="Thứ tự xuất hiện")]
        [Required(ErrorMessage ="Nhập thứ tự xuất hiện")]
        public int OrderNo { get; set; }

        [Display(Name ="Trạng thái")]
        [StringLength(49)]
        public string Status { get; set; }

        [Required(ErrorMessage ="not null")]
        [Display(Name ="Người tạo")]
        [ForeignKey("Administrator")]
        public int UserId { get; set; }

        public virtual Administrator Administrator { get; set; }
    }
}