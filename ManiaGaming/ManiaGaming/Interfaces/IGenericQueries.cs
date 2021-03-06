﻿using System.Collections.Generic;

namespace ManiaGaming.Interfaces
{
    public interface IGenericQueries<T>
    {
        List<T> GetAll();
        T GetById(long id);

        long Insert(T obj);
        bool Update(T obj);
        bool Actief(long id, bool actief);
    }
}
