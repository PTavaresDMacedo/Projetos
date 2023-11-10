using Receitas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receitas.Repository.RecipeIngredients
{
    public interface IRecipeIngredientsRepository
    {
        RecipeIngredient Create(RecipeIngredient recipeIngredients);
        RecipeIngredient Retrieve(int id);
        List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId);
        void Delete(int id);
        void DeleteAllByRecipeId(int recipeId);
    }
}
