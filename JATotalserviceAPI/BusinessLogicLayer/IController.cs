using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    interface IController<T>
    {
        void Create(T obj);
        T Get(int id);
        List<T> GetAll();
        void Update(T obj);
        void Delete(int id);
    }
}
