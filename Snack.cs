/******************************************************************* 
 * Name: Jake Levy
 * Date: 19 Sept 2022
 * Assignment: CIS317 Week 3 CP – Class Implementation
 * Snack class -- Inherits from Recipe
*******************************************************************/ 

public class Snack : Recipe {
    public Snack(int id, string mealType, string recipeName, int servings, string ingredients, string nutrition, string instructions) : base(id, mealType, recipeName, servings, ingredients, nutrition, instructions) {

    }
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