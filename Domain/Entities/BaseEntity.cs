﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; } 
        public int CreatedBy { get; set; }
        public int UpdatedBy { get;set;}
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }  
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }

    }
}
