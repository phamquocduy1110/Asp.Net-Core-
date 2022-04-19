using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Services
{
    public class MockCategory : ICategory
    {
        static List<Category> categories = new List<Category>()
        {
            new Category { Id = 1, Name ="Phone"},
            new Category { Id = 2, Name ="Laptop"},
            new Category { Id = 3, Name ="Tablet"},
            new Category { Id = 4, Name ="Air Condition"},
        };

        Category ICategory.Create(string name)
        {
            throw new NotImplementedException();
        }

        List<Category> ICategory.GetAll()
        {
            return categories;
        }

        Category ICategory.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Category> ICategory.Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
