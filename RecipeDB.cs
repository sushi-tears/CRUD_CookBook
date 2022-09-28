/******************************************************************* 
 * Name: Jake Levy
 * Date: 28 Sept 2022
 * Assignment: CIS317 Week 4 CP – DB Implementation
 *  
*******************************************************************/ 

using System.Data.SQLite;

public class RecipeDB {
    public static void CreateTable(SQLiteConnection conn) {
        //Create a new table 
        string sql = 
            "CREATE TABLE IF NOT EXISTS Recipes (\n"
            + "   ID integer PRIMARY KEY\n"
            + "   ,MealType varchar(20)\n"
            + "   ,RecipeName varchar(20)\n"
            + "   ,Servings integer\n"
            + "   ,Ingredients varchar(5000)\n"
            + "   ,Nutrition varchar(5000)\n"
            + "   ,Instructions varchar(5000));";

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void AddRecipe(SQLiteConnection conn, Recipe r) {
        string sql = string.Format(
            "INSERT INTO Recipes(MealType, RecipeName, Servings, Ingredients, Nutrition, Instructions) "
            + "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", r.MealType, r.RecipeName, r.Servings, r.Ingredients, r.Nutrition, r.Instructions);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public static void UpdateRecipe(SQLiteConnection conn, Recipe r) {
        string sql = string.Format(
            "UPDATE Recipes SET MealType='{0}', RecipeName='{1}', Servings='{2}'Ingredients='{3}', Nutrition='{4}', Instructions='{5}'" 
            + " WHERE ID={6}", r.MealType, r.RecipeName, r.Servings, r.Ingredients, r.Nutrition, r.Instructions, r.ID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public  static void DeleteRecipe(SQLiteConnection conn, int id) {
        string sql = string.Format("DELETE FROM Recipes WHERE ID  = {0}", id);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }

    public static List<Recipe> GetAllRecipes (SQLiteConnection conn) {
        List<Recipe> recipes = new List<Recipe>();
        string sql = "SELECT * FROM Recipes";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read()) {
            recipes.Add(new Recipe(
                rdr.GetInt32(0), 
                rdr.GetString(1), 
                rdr.GetString(2),
                rdr.GetInt32(3),
                rdr.GetString(4),
                rdr.GetString(5),
                rdr.GetString(6)
            ));
        }

        return recipes;
    }

    public static Recipe GetRecipe(SQLiteConnection conn, int id) {
        string sql = string.Format("SELECT * FROM Recipes WHERE ID = {0}", id);

        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;

        SQLiteDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read()) {
            return new Recipe(
                rdr.GetInt32(0), 
                rdr.GetString(1), 
                rdr.GetString(2),
                rdr.GetInt32(3),
                rdr.GetString(4),
                rdr.GetString(5),
                rdr.GetString(6)
            );
        } else  {
            return new Recipe(-1, string.Empty, string.Empty, -1, string.Empty, string.Empty, string.Empty);
        }
    }
}