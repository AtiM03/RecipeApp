using RecipeApp;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace RecipeApp
//References
//C# Tutorials Blog. (2019). Create a Menu in C# Console Application. [online] Available at: https://wellsb.com/csharp/beginners/create-menu-csharp-console-application.
//Stack Overflow. (n.d.). Change Background color on C# console application. [online] Available at: https://stackoverflow.com/questions/14792066/change-background-color-on-c-sharp-console-application.
//Stack Overflow. (n.d.). How to display list items on console window in C#. [online] Available at: https://stackoverflow.com/questions/759133/how-to-display-list-items-on-console-window-in-c-sharp [Accessed 30 May 2024].
//BillWagner (2022). Delegates - C# Programming Guide. [online] learn.microsoft.com. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/.
//Stack Overflow. (n.d.). Store data in array, object, struct, list or class. C#. [online] Available at: https://stackoverflow.com/questions/26157154/store-data-in-array-object-struct-list-or-class-c-sharp [Accessed 30 May 2024].
//Stack Overflow. (n.d.). C# Console writeline print out generics list collection. [online] Available at: https://stackoverflow.com/questions/33957801/c-sharp-console-writeline-print-out-generics-list-collection [Accessed 30 May 2024].
{
    class Program
    {
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // changing text color 
                Console.BackgroundColor = ConsoleColor.White;

                Console.WriteLine("Welcome to the Recipe App!");
                bool exit = false;
                // Menu display 
                while (!exit)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Add a new recipe");
                    Console.WriteLine("2. Display all recipes");
                    Console.WriteLine("3. Select and display a recipe");
                    Console.WriteLine("4. Scale a recipe");
                    Console.WriteLine("5. Clear all data");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");
                    string choice = Console.ReadLine();

                    //Options from menu
                    switch (choice)
                    {
                        case "1":
                            AddRecipe();
                            break;
                        case "2":
                            DisplayAllRecipes();
                            break;
                        case "3":
                            SelectAndDisplayRecipe();
                            break;
                        case "4":
                            ScaleRecipe();
                            break;
                        case "5":
                            ClearAllData();
                            break;
                        case "6":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            //Add recipe 
            static void AddRecipe()
            {
                Console.Write("Enter the name of the recipe: ");
                string name = Console.ReadLine();
                Recipe recipe = new Recipe(name);
                recipe.OnCaloriesExceeded += NotifyCaloriesExceeded;

                Console.Write("Enter the number of ingredients: ");
                int ingredientCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < ingredientCount; i++)
                {
                    Console.Write($"Enter name of ingredient {i + 1}: ");
                    string ingredientName = Console.ReadLine();


                    Console.Write($"Enter quantity of {ingredientName}: ");
                    double quantity = Convert.ToDouble(Console.ReadLine());

                    Console.Write($"Enter unit of measurement for {ingredientName}: ");
                    string unit = Console.ReadLine();

                    Console.Write($"Enter the number of calories for {ingredientName}: ");
                    int calories = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Enter the food group for {ingredientName}: ");
                    string foodGroup = Console.ReadLine();

                    recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
                }

                Console.Write("Enter the number of steps: ");
                int stepCount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < stepCount; i++)
                {
                    Console.Write($"Enter step {i + 1}: ");
                    string step = Console.ReadLine();
                    recipe.AddStep(step);
                }

                recipes.Add(recipe);
            }

            static void DisplayAllRecipes()
            {
                Console.WriteLine("\nAll Recipes:");
                foreach (var recipe in recipes.OrderBy(r => r.Name))
                {
                    Console.WriteLine(recipe.Name);
                }
            }

            static void SelectAndDisplayRecipe()
            {
                Console.Write("Enter the name of the recipe to display: ");
                string name = Console.ReadLine();
                var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (recipe != null)
                {
                    recipe.DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
            }

            static void ScaleRecipe()
            {
                Console.Write("Enter the name of the recipe to scale: ");
                string name = Console.ReadLine();
                var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (recipe != null)
                {
                    Console.Write("Enter scaling factor (0.5 for half, 2 for double, 3 for triple): ");
                    double factor = Convert.ToDouble(Console.ReadLine());
                    recipe.ScaleRecipe(factor);
                    recipe.DisplayRecipe();
                }
                else
                {
                    Console.WriteLine("Recipe not found.");
                }
            }
            static void NotifyCaloriesExceeded(string message)
            {
                Console.WriteLine(message);

            }
        }

        private static void ClearAllData()
        {
            throw new NotImplementedException();
        }
    }
}


    

