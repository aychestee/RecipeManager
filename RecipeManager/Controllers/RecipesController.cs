using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;
using RecipeManager.Models;

namespace RecipeManager.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class RecipesController : Controller
    {
        private readonly RecipeDatabaseContext _recipedbcontext;

        public RecipesController(RecipeDatabaseContext recipedbcontext)
        {
            _recipedbcontext = recipedbcontext;
        }

        // Index.cshtml
        public async Task<IActionResult> Index()
        {
            var recipes = new List<Recipe>();
            recipes = await _recipedbcontext.Recipe.ToListAsync();
            return View(recipes);
        }

        // RecipeDetails.cshtml
        public async Task<IActionResult> RecipeDetails(int? id)
        {
            var recipe = await _recipedbcontext.Recipe.FirstOrDefaultAsync(item => item.Id == id);
            return View(recipe);
        }

        // CreateRecipe.cshtml
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRecipe([Bind("Id,Name,Description,Ingredients,Directions")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipedbcontext.Add(recipe);
                await _recipedbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // EditRecipe.cshtml
        public async Task<IActionResult> EditRecipe(int? id)
        {
            var recipe = await _recipedbcontext.Recipe.FindAsync(id);
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRecipe(int id, [Bind("Id,Name,Description,Ingredients,Directions")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _recipedbcontext.Update(recipe);
                await _recipedbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // DeleteRecipe.cshtml
        public async Task<IActionResult> DeleteRecipe(int? id)
        {
            var recipe = await _recipedbcontext.Recipe.FirstOrDefaultAsync(item => item.Id == id);
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _recipedbcontext.Recipe.FindAsync(id);
            _recipedbcontext.Recipe.Remove(recipe);
            await _recipedbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
