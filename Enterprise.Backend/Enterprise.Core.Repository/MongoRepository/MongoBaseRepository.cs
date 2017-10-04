using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.DataLayers.EnterpriseDB_MongoModel;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Enterprise.API.Models.Settings;
using System.Linq;
using MongoDB.Bson;

namespace Enterprise.Core.Repository.MongoRepository
{
    public class MongoBaseRepository<T> : IMongoEntityBaseRepository<T> where T : class, new()
    {
        protected readonly MongoContext _context;
        public MongoBaseRepository(IOptions<MongoDBSettings> options)
        {
            _context = new MongoContext(options);
        }

        public virtual void Add(MongoCollection<T> col, T entity)
        {
            col.Insert(entity);
        }

        public virtual long Count(MongoCollection<T> col)
        {
            return col.Count();
        }

        public virtual void Delete(MongoCollection<T> col, IMongoQuery query)
        {
            col.Remove(query);
        }

        public virtual IEnumerable<T> FindBy(MongoCollection<T> col, IMongoQuery query)
        {
            return col.Find(query).AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(MongoCollection<T> col)
        {
            return col.FindAll().AsEnumerable();
        }

        public virtual T GetSingle(MongoCollection<T> col, IMongoQuery query)
        {
            return col.Find(query).FirstOrDefault();
        }

        public virtual void Update(MongoCollection<T> col, IMongoQuery query, IMongoUpdate update)
        {
            col.Update(query, update);
        }
    }
}
