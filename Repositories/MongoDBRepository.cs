﻿using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class MongoDBRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBRepository(IDatabaseSettings settings)
        {
            //var client = new MongoClient(settings.ConnectionString);
            //var db = client.GetDatabase(settings.DatabaseName);

            var db = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = db.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));//repasar

        }

        private protected string GetCollectionName(Type documentType)//revisar
        {
            return ((IDatabaseSettings)documentType.GetCustomAttributes(
                    typeof(IDatabaseSettings),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public virtual IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual TDocument FindById(string id)
        {
            var objectId = new ObjectId(id);
            //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            var filter = Builders<TDocument>.Filter.Eq(id, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                var filter = Builders<TDocument>.Filter.Eq(id, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }


        public virtual void InsertOne(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public void DeleteById(string id)
        {
            var objectId = new ObjectId(id);
            //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            var filter = Builders<TDocument>.Filter.Eq(id, objectId);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                //var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                var filter = Builders<TDocument>.Filter.Eq(id, objectId);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }

    }   
}
       

