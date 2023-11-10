using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Model
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public long Quantity { get; set; }
        public Measure Measure { get; set; }
    }
}
