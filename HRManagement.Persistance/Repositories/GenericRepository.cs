﻿using HRManagement.Application.Contracts.Persistance;
using HRManagement.Persistance.DatabaseContext;
using HRmanagementDomain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepositor<T> where T : BaseEntity
    {
        protected readonly HrDatabaseContext _context;
        public GenericRepository(HrDatabaseContext context)
        {
            this._context = context;     
        }
        public async Task CreateAsync(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }

      
    }


}
