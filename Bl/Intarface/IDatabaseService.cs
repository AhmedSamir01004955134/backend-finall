using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinallShope.Bl.Intarface
{
    public interface IDatabaseService<T>
    {
        T GetItem(int id);

        IEnumerable<T> GetList();

        void Edit(T data);

        void Add(T data);

        void Remove(int id);
    }
}
