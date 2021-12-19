using Store.Data.interfaces;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.repository
{
    public class categoryRepository:ICarsCategory
    {
        private readonly ApplicationDbContext appDBContent;
        public categoryRepository(ApplicationDbContext appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategorys => appDBContent.Category;
    }
}
