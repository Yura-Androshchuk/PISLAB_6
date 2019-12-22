using AutoMapper;
using BusinessLogic.BlDto;
using BusinessLogic.Interfaces;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Servicies
{
    public class IngredientService:IIngredientService
    {
        private IMapper mapper;
        private RepositoryWrapper wrapper;
        public IngredientService(IMapper mapper, RepositoryWrapper wrapper)
        {
            this.mapper = mapper;
            this.wrapper = wrapper;
        }

        public IEnumerable<BlDto_Ingredient> GetAllIngredients()
        {
            var ingredients = wrapper.Ingredient.FindAll().ToList();
            return mapper.Map<IEnumerable<BlDto_Ingredient>>(ingredients);

        }

        public void AddIngredient(BlDto_Ingredient ingredient)
        {
            var newIngredient = mapper.Map<Dal.Models.Ingredient>(ingredient);
            wrapper.Ingredient.Create(newIngredient);
            wrapper.Save();
        }

        public void UpdateIngredient(BlDto_Ingredient ingredient)
        {
            var newIngredient = mapper.Map<Dal.Models.Ingredient>(ingredient);
            wrapper.Ingredient.Update(newIngredient);
            wrapper.Save();
        }

        public void DeleteIngredient(BlDto_Ingredient ingredient)
        {
            var newIngredient = mapper.Map<Dal.Models.Ingredient>(ingredient);
            wrapper.Ingredient.Delete(newIngredient);
            wrapper.Save();
        }
    }
}
