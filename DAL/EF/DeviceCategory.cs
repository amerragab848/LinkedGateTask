//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeviceCategory
    {
        public int Id { get; set; }
        public string DeviceCategory1 { get; set; }
        public Nullable<int> DeviceId { get; set; }
    
        public virtual Device Device { get; set; }
    }
}
