﻿using System.ComponentModel.DataAnnotations;

namespace CrudOperation.Models
{
    public class SampleTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public  string Name { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
