
using System.Collections.Generic;
using System.Threading.Tasks;
using Students.Models;

namespace Students.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Student Get(string id);  
        Task Insert(T student);
        Task Update(T student);
        void Save();
    }
}       