using Data.Models;
using Data.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AppService.Services.Food
{
    public class FoodService
    {
        private readonly IHomiesDataSystem homiesData;

        public FoodService(IHomiesDataSystem homiesData)
        {
            this.homiesData = homiesData;
        }

        public async Task<Category> GetCategoryAsync(string categoryName)
        {
            var category = this.homiesData.Categories.All().Where(m => m.Name.Equals(categoryName, 
                StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (category == null)
            {
                category = new Category()
                {
                    Name = categoryName,
                };
                this.homiesData.Categories.Add(category);
                await this.homiesData.SaveChangesAsync();
            };
           
            return category;
        }

        public async Task<bool> AddFoodAsync(Common.ApiModels.FoodModels.FoodApiModel model)
        {
            var category = await this.GetCategoryAsync(model.CategoryName);

            var food = new Data.Models.Food()
            {
                CategoryId = category.Id,
                IsMealOfTheDay = false,
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Currency = Currency.Naira,
                CanFoodShowOnApp = true //remove this later, and only show the food when the Admin is ready to show it.
            };

            this.homiesData.Foods.Add(food);
            await this.homiesData.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateFoodAsync(Common.ApiModels.FoodModels.FoodApiModel model)
        {
            Category category = null;

            //if there is no category passed
            if(string.IsNullOrWhiteSpace(model.CategoryName))
                category = await this.GetCategoryAsync(model.CategoryName);


            var food = this.homiesData.Foods.GetById(model.Id);
            if (food != null)
            {
                food.CategoryId = (category == null) ? food.Category.Id : category.Id; //if category is null, then category remains unchanged
                food.Description = model.Description ?? food.Description;
                food.Name = model.Name ?? food.Name;
                food.Price = model.Price;

                this.homiesData.Foods.Update(food);
                await this.homiesData.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}