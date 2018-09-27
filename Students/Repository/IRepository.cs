
using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Models;

namespace Students.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Student Get(string id);  
        void Insert(T student);
        void Update(T student);
        void Save();
    }
}           