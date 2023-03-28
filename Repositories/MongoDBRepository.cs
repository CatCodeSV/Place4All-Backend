using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class MongoDBRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;
        private readonly ILogger<TDocument> _logger;

        public MongoDBRepository(IDatabaseSettings settings,ILogger<TDocument> logger )
        {
            var db = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
            _logger = logger;
        }

        private protected string GetCollectionName(Type documentType) //revisar
        {
        return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                typeof(BsonCollectionAttribute),
                true)
            .FirstOrDefault())?.CollectionName;
        }

        public virtual IQueryable<TDocument> AsQueryable()
        {
            try
            {
                return _collection.AsQueryable();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public virtual IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            try
            {
                return _collection.Find(filterExpression).ToEnumerable();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            try
            {
                return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            try
            {
                return _collection.Find(filterExpression).FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            try
            {
                return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public virtual TDocument FindById(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(id, objectId);
                return _collection.Find(filter).SingleOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
        }

        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            try
            {
                return Task.Run(async () =>
                {
                    var objectId = new ObjectId(id);
                    var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                    var res = await _collection.Find(filter).SingleOrDefaultAsync();
                    return res;
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }


        public virtual void InsertOne(TDocument document)
        {
            try
            {
                _collection.InsertOne(document);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            try
            {
                return Task.Run(() => _collection.InsertOneAsync(document));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            try
            {
                _collection.InsertMany(documents);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            try
            {
                await _collection.InsertManyAsync(documents);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public void ReplaceOne(TDocument document)
        {
            try
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
                _collection.FindOneAndReplace(filter, document);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            try
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
                await _collection.FindOneAndReplaceAsync(filter, document);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            try{
                _collection.FindOneAndDelete(filterExpression);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            try{
                return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public void DeleteById(string id)
        {
            try
            {
                var objectId = new ObjectId(id);
                //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                var filter = Builders<TDocument>.Filter.Eq(id, objectId);
                _collection.FindOneAndDelete(filter);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public Task DeleteByIdAsync(string id)
        {
            try
            {
                return Task.Run(() =>
                {
                    var objectId = new ObjectId(id);
                    //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                    var filter = Builders<TDocument>.Filter.Eq(id, objectId);
                    _collection.FindOneAndDeleteAsync(filter);
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            try
            {
                _collection.DeleteMany(filterExpression);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
            }
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            try
            {
                return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return null;
            }
        }

    }   
}
       

