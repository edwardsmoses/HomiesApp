using Common.ApiModels.FoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Mappers
{
    public class FoodMapper
    {

        public static FoodApiModel MapSingleFoodToApiModel(Data.Models.Food foodDbModel)
        {
            var foodApiModel = new Common.ApiModels.FoodModels.FoodApiModel()
            {
                CategoryName = foodDbModel.Category.Name,
                Currency = foodDbModel.Currency.ToString(),
                Description = foodDbModel.Description,
                Id = foodDbModel.Id,
                Name = foodDbModel.Name,
                Price = foodDbModel.Price,
                Pictures = foodDbModel.Pictures.Select(m => m.FileName).ToList()
            };
            if (foodDbModel.Pictures.Any())
                foodApiModel.PicturePath = foodDbModel.Pictures.FirstOrDefault().FileName;
            else
                foodApiModel.PicturePath = Common.GlobalConstants.DefaultFoodPicture;

            return foodApiModel;
        }

        public static List<FoodApiModel> MapFoodDbModelToApiModels(List<Data.Models.Food> foods)
        {
            List<FoodApiModel> returnFoods = new List<FoodApiModel>();

            foreach (var c in foods)
            {
                var food = MapSingleFoodToApiModel(c);

                returnFoods.Add(food);
            }

            return returnFoods;
        }


    }
}