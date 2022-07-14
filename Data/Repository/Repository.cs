using Domain.Interfaces;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {

        public async Task<List<T>> GetAll()
        {
            return await DB.Find<T>().ExecuteAsync();
        }

        public async Task<T> Get(string id)
        {
            return await DB.Find<T>().OneAsync(id);
        }

        public async Task Insert(T entity)
        {
            await entity.SaveAsync();
        }

        public async Task Update(T entity)
        {
            await DB.Update<T>()
                    .MatchID(entity.ID)
                    .ModifyExcept(x => new { x.ID }, entity)
                    .ExecuteAsync();
        }

        public async Task Delete(T entity)
        {
            await DB.DeleteAsync<T>(entity.ID);

        }
    }
}
