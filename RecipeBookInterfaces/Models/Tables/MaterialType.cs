﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBookInterfaces.Models.Tables
{
    public class MaterialType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
