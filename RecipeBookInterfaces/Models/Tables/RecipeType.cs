using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecipeBookInterfaces.Models.Tables
{
    public class RecipeType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
