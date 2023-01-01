using Inventory.Models;

namespace Inventory.RecipesStorage
{
    public interface IRecipesStorage
    {
        public void Save(Recipe recipe);
        public Recipe Load(int Id);
        public List<Recipe> LoadAll();
    }
}