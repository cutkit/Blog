using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.DataModels
{
    [Table("Counter")]
    public class Counter
    {
        [Key]
        public int CountId { get; set; }

        [Display(Name ="Tổng truy cập:")]
        public int CountVisitor { get; set; }

        [Display(Name = "Đang online")]
        public int CountOnline { get; set; }
    }
}