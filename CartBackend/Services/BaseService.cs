using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Services
{
    public class BaseService<T>
    {
        private BaseRepository<T> _repo = new BaseRepository<T>();

        public List<T> GetAll()
        {
            return _repo.GetAll();
        }

        public T GetByID(int id)
        {
            return _repo.GetByID(id);
        }

        public void InsertUpdate(T model)
        {
            _repo.Insert(model);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

    }
}
