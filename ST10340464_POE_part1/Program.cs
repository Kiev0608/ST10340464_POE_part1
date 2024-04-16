using System;
using System.Collections.Generic;

class Recipe
{
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }
    private List<Ingredient> originalIngredients; // To store original ingredient quantities

    public Recipe()
    {
        Ingredients = new List<Ingredient>(); // Initialize list of ingredients
        Steps = new List<string>(); // Initialize list of steps
        originalIngredients = new List<Ingredient>(); // Initialize list to store original ingredient quantities
    }

    // Method to scale all ingredient quantities by a given factor
    public void ScaleRecipe(double scaleFactor)
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].Quantity *= scaleFactor; // Multiply each ingredient quantity by the scale factor
        }
    }

    // Method to reset all ingredient quantities to their original values
    public void ResetQuantities()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].Quantity = originalIngredients[i].Quantity; // Set each ingredient quantity to its original value
        }
    }

    // Method to store original quantities of ingredients before scaling
    public void StoreOriginalQuantities()
    {
        originalIngredients.Clear(); // Clear previous original ingredient quantities
        for (int i = 0; i < Ingredients.Count; i++)
        {
            originalIngredients.Add(new Ingredient // Add a copy of each ingredient to the list of original ingredients
            {
                Name = Ingredients[i].Name,
                Quantity = Ingredients[i].Quantity,
                Unit = Ingredients[i].Unit
            });
        }
    }

    // Method to clear all data in the recipe (ingredients, steps, and original quantities)
    public void ClearData()
    {
        Ingredients.Clear(); // Clear list of ingredients
        Steps.Clear(); // Clear list of steps
        originalIngredients.Clear(); // Clear list of original ingredient quantities
    }
}

class Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Recipe recipe = new Recipe();

        // Input recipe details...

        // Store original quantities
        recipe.StoreOriginalQuantities();

        // Display the recipe
        DisplayRecipe(recipe);

        Console.WriteLine("\nEnter scaling factor: ");
        double scaleFactor = double.Parse(Console.ReadLine());

        // Scale the recipe
        recipe.ScaleRecipe(scaleFactor);

        // Display the scaled recipe
        DisplayRecipe(recipe);

        Console.WriteLine("\nReset quantities to original values? (yes or no)");
        string resetChoice = Console.ReadLine();
        if (resetChoice.ToLower() == "yes")
        {
            // Reset quantities
            recipe.ResetQuantities();

            // Display the recipe with original quantities
            DisplayRecipe(recipe);
        }

        Console.WriteLine("\nClear all data to enter a new recipe? (yes or no)");
        string clearChoice = Console.ReadLine();
        if (clearChoice.ToLower() == "yes")
        {
            // Clear all data
            recipe.ClearData();
        }
    }

    // Method to display the recipe details
    static void DisplayRecipe(Recipe recipe)
    {
        // Display Recipe Details
        Console.WriteLine("\nRecipe Details:");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < recipe.Ingredients.Count; i++)
        {
            Ingredient ingredient = recipe.Ingredients[i];
            Console.WriteLine(ingredient.Quantity + " " + ingredient.Unit + " of " + ingredient.Name);
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < recipe.Steps.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + recipe.Steps[i]);
        }
    }
}
