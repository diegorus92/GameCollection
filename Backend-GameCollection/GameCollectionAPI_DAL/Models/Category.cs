﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }

        public ICollection<Game>? Games { get; set; } = new List<Game>();
    }
}
