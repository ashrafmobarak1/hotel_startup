using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_startup.Models
{
    public class RoomType
    {
        public long Id { set; get; }

        public string? Name { set; get; }
        public DateTime? createdDate { set; get; }
        public DateTime? modifiedDate { set; get; }
    }
}
