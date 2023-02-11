using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.RecipesStorage
{
    public class TempRecipesStorage : IRecipesStorage
    {
        private const string fileName = "D:\\Recipes.dat";
        private List<Recipe> recipes = new List<Recipe>();
        private BinaryFormatter formatter = new BinaryFormatter(); 
        public Recipe Load(int Id)
        {
            LoadAll();
            var rc = recipes
                .Where(rc => rc.Id==Id)
                .ToList()
                .FirstOrDefault();
            return rc;
        }
     
        public List<Recipe> LoadAll()
        {
            if (File.Exists(fileName))
            {
                string[] stroki = File.ReadAllLines(fileName);
                if (stroki.Length > 0)
                {
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        recipes = (List<Recipe>)formatter.Deserialize(fs);
                    }
                }
                else
                {
                    recipes = new List<Recipe>();
                }
            }
            else
            {
                recipes = new List<Recipe>();
            }
            return recipes;
        }

        public void Save(Recipe recipe)
        {
            LoadAll();
            recipe.Id = recipes.Count + 1;
            recipes.Add(recipe);
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                fs.SetLength(0);
                formatter.Serialize(fs, recipes);
            }
        }
    }
}
