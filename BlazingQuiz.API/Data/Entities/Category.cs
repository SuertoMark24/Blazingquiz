﻿using System.ComponentModel.DataAnnotations;

namespace BlazingQuiz.API.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
