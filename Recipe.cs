using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        private List<Ingredient> ingredients;
        private List<string> steps;
        public delegate void CaloriesExceededHandler(string message);
        public event CaloriesExceededHandler OnCaloriesExceeded;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
            if (CalculateTotalCalories() > 300)
            {
                OnCaloriesExceeded?.Invoke($"Warning: {Name} recipe exceeds 300 calories!");
            }
        }

        public void AddStep(string description)
        {
            steps.Add(description);
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            Console.WriteLine($"\nTotal Calories: {CalculateTotalCalories()}");
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearData()
        {
            ingredients.Clear();
            steps.Clear();
            Console.WriteLine("Data cleared. You can now enter a new recipe.");
        }

        public int CalculateTotalCalories()
        {
            return ingredients.Sum(ingredient => ingredient.Calories);
        }
    }
}

