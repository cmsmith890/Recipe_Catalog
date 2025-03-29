using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe_Generator.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeDbContext _context;

        public RecipeService(RecipeDbContext context)
        {
            _context = context;
        }

        public async Task AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            return await _context.Recipes.Select(r => r.Category).Distinct().ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task UpdateRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
