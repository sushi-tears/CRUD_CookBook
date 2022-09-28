/******************************************************************* 
 * Name: Jake Levy
 * Date: 19 Sept 2022
 * Assignment: CIS317 Week 3 CP – Class Implementation
 * Lunch class -- Inherits from Recipe
*******************************************************************/ 

public class Lunch : Recipe {
    public Lunch(int id, string mealType, string recipeName, int servings, string ingredients, string nutrition, string instructions) : base(id, mealType, recipeName, servings, ingredients, nutrition, instructions) {

    }
    // public string Ingredients { get; set; }
    // public string Nutrition { get; set; }
    // public string Instructions { get; set; }
    // public Lunch(string recipeName, int servings, string ingredients, string nutrition, string instructions) : base(recipeName, servings){
    //     Ingredients = ingredients;
    //     Nutrition = nutrition;
    //     Instructions = instructions;
    // }
    // public override string GetIngredients() {
    //     return Ingredients;
    // }

    // public override string GetNutrition() {
    //     return Nutrition;
    // }

    // public override string GetInstructions() {
    //     return Instructions;
    // }
}