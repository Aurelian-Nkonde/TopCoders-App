using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using topCoders.Data;
using topCoders.Models;


namespace topCoders.Structure
{
    public class ITopCodersRepo : ITopCoders
    {
        private readonly TopCodersDbContext _databaseContext;

        public ITopCodersRepo(TopCodersDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void CreateACoder(Coder dataCoder)
        {
            _databaseContext.coders.Add(dataCoder);
            _databaseContext.SaveChanges();
        }

        public void DeleteACoder(Coder dataCoder)
        {
            _databaseContext.coders.Remove(dataCoder);
            _databaseContext.SaveChanges();
        }

        public async Task<IEnumerable<Coder>> ListOfCoders()
        {
            return await _databaseContext.coders.ToListAsync();
        }
    }
}