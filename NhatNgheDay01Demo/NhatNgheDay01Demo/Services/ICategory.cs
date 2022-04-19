using NhatNgheDay01Demo.Models;

namespace NhatNgheDay01Demo.Services
{
    public interface ICategory
    {
        public List<Category> GetAll();
        public List<Category> Search(string filter);
        public Category GetById(int id);
        public Category Create(string name);
    }
}
