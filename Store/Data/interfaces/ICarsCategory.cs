using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Data.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategorys { get; }
    }
}
