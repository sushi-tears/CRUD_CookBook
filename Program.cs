/******************************************************************* 
 * Name: Jake Levy
 * Date: 19 Sept 2022
 * Assignment: CIS317 Week 3 CP – Class Implementation
 *  
 * Main application class
*******************************************************************/ 
using System.Data.SQLite;
public class CookBook {
    public static void Main(string[] args) {
        const string dbName = "JakeLevy.db";
        Console.Title = "ASCII Art";
        string title = @"
 ________  ________  ________  ___  __            ________  ________  ________  ___  __       
|\   ____\|\   __  \|\   __  \|\  \|\  \         |\   __  \|\   __  \|\   __  \|\  \|\  \     
\ \  \___|\ \  \|\  \ \  \|\  \ \  \/  /|_       \ \  \|\ /\ \  \|\  \ \  \|\  \ \  \/  /|_   
 \ \  \    \ \  \\\  \ \  \\\  \ \   ___  \       \ \   __  \ \  \\\  \ \  \\\  \ \   ___  \  
  \ \  \____\ \  \\\  \ \  \\\  \ \  \\ \  \       \ \  \|\  \ \  \\\  \ \  \\\  \ \  \\ \  \ 
   \ \_______\ \_______\ \_______\ \__\\ \__\       \ \_______\ \_______\ \_______\ \__\\ \__\
    \|_______|\|_______|\|_______|\|__| \|__|        \|_______|\|_______|\|_______|\|__| \|__|

                                                   ";
        Console.WriteLine(title);
        SQLiteConnection conn = SQLiteDatabase.Connect(dbName);

        if (conn != null) {
            RecipeDB.CreateTable(conn);

            RecipeDB.DeleteRecipe(conn, 1);
            RecipeDB.DeleteRecipe(conn, 2);
            RecipeDB.DeleteRecipe(conn, 3);
            RecipeDB.DeleteRecipe(conn, 4);

            RecipeDB.AddRecipe(conn, new Recipe("Breakfast", "Anabolic French Toast", 1, "- 180g (3/4 cup) Egg Whites\n- 2 Slices favorite bread (ideally 80cal per slice)\n- 1tbsp Artificial Sweetener\n- 1tsp Cinnamon\n- 5g (1tsp) Vanilla Extract\n- Cooking Spray\n", "  Calories: 270\n  Fat(g): 1\n  Carbs(g): 30\n  Fiber(g): 6\n  Protein(g): 28\n", "1. In a bowl, add egg whites, sweetener, cinnamon, and vanilla extract. Whisk until spices are evenly distributed throughout the mixture.\n2. Heat a griddle over low-medium heat. Spray griddle with cooking spray.\n3. Dip bread slices into egg white mixture, and transfer to pan.\n4. Spoon any leftover egg white mixture on to the bread in thepan. If done slowly, the bread should absorb the mixture and get fuffy.\n5. Let cook for about 3-4 minutes on each side.\n6. Remove French toast from the pan and serve on a plate with toppings. Suggestions for toppings are fresh fruit and low-calorie syrup."));

            RecipeDB.AddRecipe(conn, new Recipe("Lunch","Cauliflower Mashed \"Potatoes\"", 8, "- 900g (2 lbs or ~6 medium) Potatoes\n- 900g (2 lbs) Caulifower Florets\n- 230g (1 cup) fat-free Sour Cream\n- 9g (3 tsp) Xanthan Gum\n- 8g (2 tsp) Baking Powder\n- Herbs/Spices to Taste\n", "  Calories: 150\n  Fat(g): 0\n  Carbs(g): 33\n  Fiber(g): 8\n  Protein(g): 5\n", "1. Boil 4 liters (or 4 quarts) of water with salt over high heat. Oncewater starts to boil, reduce heat to medium to bring the water to a simmer. Add the potatoes and leave in pot until fully cookedthrough. Drain in a colander and add to blender.\n2. Separately, cook the caulifower in a boiling pot of water. Drain in a colander and add to blender.\n3. Add baking powder, spices, half of the fat-free sour cream, and Xantham gum to blender. Pulse blend until smooth.\n4. Serve with the remaining fat-free sour cream and any preferred spices and garnish."));

            RecipeDB.AddRecipe(conn, new Recipe("Dinner", "Chicken Cacciatore", 4, "300g (11oz) Chicken Breast (cut into 1in cubes)\n- 700g Tomato, diced\n- 200g Yellow Onion\n- 200g Celery, diced\n- 200g White Mushrooms, slices\n- 4 Garlic Cloves, minced\n- 500ml Chicken Broth\n- 156g Tomato Paste\n- Salt + Pepper to taste", "  Calories: 255\n  Fat(g): 4\n  Carbs(g): 27\n  Fiber(g): 7\n  Protein(g): 29\n", "1. Spray a nonstick skillet with cooking spray and add the chicken. Sear the chicken on all sides.\n2. Add the chicken broth to the skillet with all the remaining ingredients and stir well.\n3. Bring the mixture to a rolling boil, then cover with a lid andreduce to a low simmer. Continue to cook on medium low heatfor 20 minutes. After 20 minutes, remove the lid and raise thetemperature to medium high. Cook for 5 minutes to reduce theliquid in the skillet and form a thick sauce. You want the sauce tobe slightly thick but not too much. The dish is supposed to bealmost like a stew.\n4. Remove from the heat and transfer the chicken cacciatore to a bowl. Garnish with fresh chopped parsley.\n"));

            RecipeDB.AddRecipe(conn, new Recipe("Snack", "Protein Caramel Corn", 2, "- 1 Bag of SmartPop Popcorn\n- 50g (1½ scoop) protein powder\n- 80g (1/3 cup) IMO syrup\n- 38g (2½ tbsp) Walden Farms Chocolate Syrup OR 30g (2 tbsp)sugar-free maple syrup\n", "  Calories: 270\n  Fat(g): 4\n  Carbs(g): 55\n  Fiber(g): 12\n  Protein(g): 22\n", "1. Pop popcorn in the microwave per directions. Once popped, place the popped popcorn in a large bowl (remove unpopped kernels).\n2. Separately, put IMO syrup and the Walden Farms syrup in a microwave-safe bowl, and microwave for 30 seconds.\n3. Add chocolate syrup and protein powder to the bowl of IMOsyrup and stir with a spoon.\n4. Pour the syrup/protein powder mixture on top of the popped SmartPop, and carefully mix with a spatula until well combined.\n5. Place and store the coated popcorn in the freezer (15min).\n"));

            PrintRecipes(RecipeDB.GetAllRecipes(conn));
        }
        
    }
    private static void PrintRecipes(List<Recipe> recipes) {
        foreach (Recipe r in recipes) {
            PrintRecipe(r);
        }
    }
    private static void PrintRecipe(Recipe r) {
        Console.WriteLine("--------------------------------------------------------------\n" + "ID: " + r.ID + "\nMeal Type: " + r.MealType + "\nRecipe Name: " + r.RecipeName + "\nServings: " + r.Servings + "\n\nIngredients:\n\n" + r.Ingredients + "\n\nNutrition:\n\n" + r.Nutrition + "\n\nInstructions:\n\n" + r.Instructions + "\n--------------------------------------------------------------" + "\n\n");
    }
}






        // Recipe mealOne = new Breakfast(
            
        // );

    //     Recipe mealTwo = new Lunch(
            // "Cauliflower Mashed \"Potatoes\"", 8, "- 900g (2 lbs or ~6 medium) Potatoes\n- 900g (2 lbs) Caulifower Florets\n- 230g (1 cup) fat-free Sour Cream\n- 9g (3 tsp) Xanthan Gum\n- 8g (2 tsp) Baking Powder\n- Herbs/Spices to Taste\n", "    Calories: 150\n    Fat(g): 0\n    Carbs(g): 33\n    Fiber(g): 8\n    Protein(g): 5\n", "    1. Boil 4 liters (or 4 quarts) of water with salt over high heat. Oncewater starts to boil, reduce heat to medium to bring the water to a simmer. Add the potatoes and leave in pot until fully cookedthrough. Drain in a colander and add to blender.\n    2.  eparately, cook the caulifower in a boiling pot of water. Drain in a colander and add to blender.\n    3. Add baking powder, spices, half of the fat-free sour cream, and Xantham gum to blender. Pulse blend until smooth.\n    4. Serve with the remaining fat-free sour cream and any preferred spices and garnish."
    //     );

    //     Recipe mealThree = new Dinner(
    //         "Chicken Cacciatore", 4, "300g (11oz) Chicken Breast (cut into 1in cubes)\n- 700g Tomato, diced\n- 200g Yellow Onion\n- 200g Celery, diced\n- 200g White Mushrooms, slices\n- 4 Garlic Cloves, minced\n- 500ml Chicken Broth\n- 156g Tomato Paste\n- Salt + Pepper to taste", "    Calories: 255\n    Fat(g): 4\n    Carbs(g): 27\n    Fiber(g): 7\n    Protein(g): 29\n", "    1. Spray a nonstick skillet with cooking spray and add the chicken.Sear the chicken on all sides.\n    2. Add the chicken broth to the skillet with all the remainingingredients and stir well.\n    3. Bring the mixture to a rolling boil, then cover with a lid andreduce to a low simmer. Continue to cook on medium low heatfor 20 minutes. After 20 minutes, remove the lid and raise thetemperature to medium high. Cook for 5 minutes to reduce theliquid in the skillet and form a thick sauce. You want the sauce tobe slightly thick but not too much. The dish is supposed to bealmost like a stew.\n    4. Remove from the heat and transfer the chicken cacciatore to a bowl. Garnish with fresh chopped parsley.\n"
    //     );

    //     Recipe mealFour = new Snack(
    //         "Protein Caramel Corn", 2, "- 1 Bag of SmartPop Popcorn\n- 50g (1½ scoop) protein powder\n- 80g (1/3 cup) IMO syrup\n- 38g (2½ tbsp) Walden Farms Chocolate Syrup OR 30g (2 tbsp)sugar-free maple syrup\n", "    Calories: 270\n    Fat(g): 4\n    Carbs(g): 55\n    Fiber(g): 12\n    Protein(g): 22\n", "    1. Pop popcorn in the microwave per directions. Once popped, place the popped popcorn in a large bowl (remove unpopped kernels).\n    2. Separately, put IMO syrup and the Walden Farms syrup in amicrowave-safe bowl, and microwave for 30 seconds.\n    3. Add chocolate syrup and protein powder to the bowl of IMOsyrup and stir with a spoon.\n    4. Pour the syrup/protein powder mixture on top of the poppedSmartPop, and carefully mix with a spatula until well combined.\n    5. Place and store the coated popcorn in the freezer (15min).\n"
    //     );

    //     List<Recipe> recipes = new List<Recipe>{mealOne, mealTwo, mealThree, mealFour};
    //     foreach (Recipe recipe in recipes) {
    //         PrintBook(recipe);
    //     }
    // }
    // private static void PrintBook(Recipe recipe) {
    //     Console.Write(recipe);
    // }
