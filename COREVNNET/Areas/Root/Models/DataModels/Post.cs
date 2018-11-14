using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COREVNNET.Areas.Root.Models.DataModels
{   
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }

        [Display(Name ="Chủ đề")]
        [ForeignKey("Category")]
        public string CategoryId { get; set; }

        [Display(Name ="Người viết")]
        [ForeignKey("Administrator")]
        public int? UserId { get; set; }

        [Display(Name ="Tiêu đề")]
        [Column(TypeName ="nvarchar")]
        [DataType(DataType.MultilineText)]
        [StringLength(1024)]
        [Required(ErrorMessage ="Nhập tiêu đề bài viết")]
        public string Title { get; set; }

        [Display(Name ="Mô tả ngắn gọn")]
        [Required(ErrorMessage ="Nhập mô tả")]
        [DataType(DataType.MultilineText)]
        [StringLength(2048)]
        [Column(TypeName ="nvarchar")]
        public string Brief { get; set; }

        [Display(Name ="Nội dung")]
        [Required(ErrorMessage ="Nhập nội dung")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName ="ntext")]
        [AllowHtml]
        public string Content { get; set; }

        [Display(Name ="Ảnh bài viết")]
        [StringLength(256)]
        public string Picture { get; set; }


        [Required(ErrorMessage ="Nhập ngày tháng viết bài")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [Display(Name ="Ngày viết")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreate { get; set; }

        [Display(Name ="Thẻ tìm kiếm")]
        [StringLength(256)]
        public string Tags { get; set; }

        [Display(Name = "Số lượt xem")]
        public int? ViewNo { get; set; }

        [Display(Name ="Trạng thái")]
        [StringLength(64)]
        public string Status { get; set; }

        //navi
        public virtual Category Category { get; set; }
        public virtual  Administrator Administrator { get; set; }

    }
}