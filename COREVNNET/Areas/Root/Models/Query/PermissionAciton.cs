using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COREVNNET.Areas.Root.Models.Query
{
    public class PermissionAciton
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public bool IsGranted { get; set; }
        //PermissionId = p.PermissionId,
        //        PermissionName = p.PermissionName,
        //        Description = p.Description,
        //        IsGranted = true
    }
}