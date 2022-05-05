using System;
using System.Collections.Generic;
using topCoders.Models;

namespace topCoders.Structure
{
    public interface ITopCoders
    {
        Task<IEnumerable<Coder>> ListOfCoders();
        void CreateACoder(Coder dataCoder);
        void DeleteACoder(Coder dataCoder);
    }
}