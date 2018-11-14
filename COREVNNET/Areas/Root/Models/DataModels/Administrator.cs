using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.DataModels
{
    [Table("Administrator")]
    public class Administrator
    {
        [Display(Name ="Mã Administrator")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage ="Phải nhập username")]
        [Display(Name ="Username của admin")]
        [StringLength(77,ErrorMessage ="Username phải từ 3 đến 77 ký tự"),MinLength(3)]
        [Column(TypeName ="varchar")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Phải nhập họ tên admin")]
        [Display(Name ="Họ và tên Admin")]
        [Column(TypeName ="nvarchar")]
        [StringLength(27,ErrorMessage ="Họ và tên phải từ 7 đến 32 ký tự"),MinLength(7)]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Xin nhập Password")]
        [Display(Name ="Mật khẩu")]
        [Column(TypeName ="varchar")]
        [StringLength(256,ErrorMessage ="Mật khẩu phải lớn hơn 3 ký tự"),MinLength(3)]
        public string PassWord { get; set; }

        [Required(ErrorMessage ="Nhập email")]
        [EmailAddress(ErrorMessage ="Email không đúng định dạng")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Ảnh đại diện")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string Avatar { get; set; }

        [Display(Name = "Là Admin(1 là admin)")]
        public byte? IsAdmin { get; set; }

        [Display(Name ="Trang thái kích hoạt")]
        public byte? Allowed { get; set; }
    }
}