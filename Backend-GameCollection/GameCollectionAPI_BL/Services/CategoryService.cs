using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Data;
using GameCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryService(DatabaseContext databaseContext)
        {
                _databaseContext = databaseContext;
        }

        public string AddCategory(CategoryDTO category)
        {
            Category? myCategory = _databaseContext.Categories.FirstOrDefault(cat => cat.CategoryName.ToLower() == category.CategoryName.ToLower());
            if (myCategory != null) return $"Category -<{category.CategoryName}>- already exist";

            myCategory = new Category(category.CategoryName);
            _databaseContext.Categories.Add(myCategory);
            _databaseContext.SaveChanges();
            _databaseContext.Dispose();
            return $"Category ID:{myCategory.CategoryId} -<{myCategory.CategoryName}>- added successfully";
        }
        
        public ICollection<CategoryResponseDTO> GetCategories()
        {
            List<Category> categories = _databaseContext.Categories.Include(cat => cat.Games).ToList();
            List<CategoryResponseDTO> result = new List<CategoryResponseDTO>();

            foreach(Category category in categories)
            {
                result.Add(new CategoryResponseDTO
                {
                    CategoryName = category.CategoryName,
                    Games = category.Games.Select(games => games.GameName).ToList(),
                });
            }

            return result;
        }
    }
}
