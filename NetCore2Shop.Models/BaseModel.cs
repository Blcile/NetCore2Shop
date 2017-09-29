using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore2Shop.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}