using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_startup.Models
{
    public class Booking
    {
        public long Id { set; get; }
        public Guid? _guid { set; get; }
        public string? Name { set; get; }
        public DateTime? createdDate { set; get; }
        public DateTime? modifiedDate { set; get; }
        public string? mobile { set; get; }
        public DateTime? startDate { set; get; }
        public DateTime? endDate { set; get; }
        public long? cityId { set; get; }
        public long? roomTypeId { set; get; }
        public int? personNo { set; get; }
        public string? notes { set; get; }
        public int? createdUserId { set; get; }
        public int? modifiedUserId { set; get; }
        //[Required]
        //[Display(Name = "Room Type")]
        //public string SelectedroomTypeId { get; set; }
        //public IEnumerable<SelectListItem> RoomType { get; set; }
        public virtual City City { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
