﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer
{
    public interface IDB<T>
    {
        bool Create(T obj);
        T Get(int id);
        List<T> GetAll();
        bool Update(T obj);
        bool Delete(int id);
    }
}
