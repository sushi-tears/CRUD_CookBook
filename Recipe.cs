/******************************************************************* 
 * Name: Jake Levy
 * Date: 19 Sept 2022
 * Assignment: CIS317 Week 3 CP – Class Implementation
 *  
 * Interface class IBook - defines all methods that classes that 
 * implement this interface must implement. 
*******************************************************************/ 

public class Recipe {
    public int ID { get; set; }
    public string MealType { get; set; }
    public string RecipeName { get; set; }
    public int Servings { get; set; }
    public string Ingredients { get; set; }
    public string Nutrition { get; set; }
    public string Instructions { get; set; }

    public Recipe(int id, string mealType, string recipeName, int servings, string ingredients, string nutrition, string instructions) {
        ID = id;
        MealType = mealType;
        RecipeName = recipeName;
        Servings = servings;
        Ingredients = ingredients;
        Nutrition = nutrition;
        Instructions = instructions;
    }
    public Recipe(string mealType, string recipeName, int servings, string ingredients, string nutrition, string instructions) {
        MealType = mealType;
        RecipeName = recipeName;
        Servings = servings;
        Ingredients = ingredients;
        Nutrition = nutrition;
        Instructions = instructions;
    }

    // public abstract string GetIngredients();
    // public abstract string GetNutrition();
    // public abstract string GetInstructions();

    // public override string ToString() {
    //     return 
    //         "Recipe Name: " + RecipeName + "\n" + 
    //         "Meal Type: " + this.GetType().Name + "\n" + 
    //         "Servings: " + Servings + "\n" + 
    //         "\n" +
    //         "Required Ingredients: " + "\n" + GetIngredients() + 
    //         "\n" +
    //         "Nutrional Information: " + "\n" + GetNutrition() +
    //         "\n" +
    //         "Cooking Instructions: " + "\n" + GetInstructions() +
    //         "\n" + "\n";
    // }
}