//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NTP_Backend2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryTime
    {
        public int Id { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int time { get; set; }
        public int ProductId { get; set; }
    }
}
