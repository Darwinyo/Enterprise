using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using MongoDB.Driver.Builders;
using MongoDB.Driver;

namespace Enterprise.Core.Repository.Abstract
{
    public interface IMongoEntityBaseRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll(MongoCollection<T> col);
        long Count(MongoCollection<T> col);
        T GetSingle(MongoCollection<T> col, IMongoQuery query);
        IEnumerable<T> FindBy(MongoCollection<T> col, IMongoQuery query);
        void Add(MongoCollection<T> col, T entity);
        void Update(MongoCollection<T> col, IMongoQuery query, IMongoUpdate update);
        void Delete(MongoCollection<T> col, IMongoQuery query);
    }
}
