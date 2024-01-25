using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.Services
{
    public interface ICategoryService
    {
        public string AddCategory(CategoryDTO category);
        public ICollection<CategoryResponseDTO> GetCategories();
    }
}
