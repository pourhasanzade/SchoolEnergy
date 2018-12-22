using System;
using System.ComponentModel.DataAnnotations;

namespace RobokaBimeBazar.Domain.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDateTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
