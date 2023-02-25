/*using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
	/*public class Repository<T>
	{
		private IList<T> list;

		public Repository()
		{
			list=new List<T>
		}
	}*/

    //Nuevo de learn
  /*  public class Repository<T> : IRepository<T> where T: class
    {

        private readonly IMongoCollection context;

        public Repository(IMongoCollection context)
        {
            this.context = context;
        }

        //Coger todos los datos
        public async Task<IEnumerable<T>> GetAll();
        {
            return await context.ToListAsync();
        }
        //Buscar por id
        public async Task<T> GetByID(int id);
        {
           return await context.FindAsync();
        }
        //Insertar
        public async Task<T> Insert(T context);
        {
            context.Add(context);
            await Save();
            return context;
        }
        //Borrar por id
        public async Task<T> Delete(int id);
        {
            T context = await context.FindAsync(id);
            context.Remove(context);
            await Save();
            return context;
        }
        //Actualizar
        public async Task Update(T context);
        {
            context.Entry(context).State = context.Modified;
            await Save();
        }
        //Guardar
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}*/


//Se tienen que cambiar los servicios por este repositorio, pero como??