using Common.Utilities;
using System;

namespace WebFramework.Permition
{
    public class PermissionAttribute : Attribute
    {
        public VencerPermission Permission { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public PermissionAttribute(VencerPermission permission, int order = 0, bool active = true)
        {
            this.Permission = permission;
            this.Order = order;
            this.Active = active;
        }
    }
}
