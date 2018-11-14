using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using COREVNNET.Areas.Root.Models.DataModels;

namespace COREVNNET.Models.Query
{
    public class AdminVsPost
    {
        public Administrator Administrator { get; set; }
        public Post Post { get; set; }
    }
}