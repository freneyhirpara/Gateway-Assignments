//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMS.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Booking
    {
        public int BookingId { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string StatusOfBooking { get; set; }
    
        public virtual Room Room { get; set; }
    }
}
