using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.BlDto;

namespace BusinessLogic.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<BlDto_Ingredient> GetAllIngredients();
        //IEnumerable<BlDto_Ingredient> GetIgredientByName();

        //SomeOtherChanges
        //
        //void AddIngredient(BlDto_Ingredient ingredient);
        void UpdateIngredient(BlDto_Ingredient ingredient);
        void DeleteIngredient(BlDto_Ingredient ingredient);

        void SomeNewMethod();
    }
}
