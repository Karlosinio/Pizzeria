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

        public int Insert(T model)
        {
            return _repo.Insert(model);
        }

        public void Update(T model, int id)
        {
            _repo.Update(model, id);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

    }
}
