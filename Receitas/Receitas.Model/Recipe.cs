using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Author { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public Category Category { get; set; }
        public int PreparationTime { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public bool IsApproved { get; set; }
    }
}
