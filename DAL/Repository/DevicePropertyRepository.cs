
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DLL.Repository
{
    public class DevicePropertyRepository : IBaserepository<DeviceProperty> 
    {
        private readonly DeviceDBEntities context;
       // private DbSet<Student> entities;
        string errorMessage = string.Empty;
        public DevicePropertyRepository(DeviceDBEntities context)
        {
            this.context = context;
          //  entities = context.Set<Student>();
        }

        public void Delete(DeviceProperty entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.DeviceProperties.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<DeviceProperty> GetAll()
        {
            var res= context.DeviceProperties.Include(c => c.Device);
            return res;
        }

        public List<DeviceProperty> GetUsersDataByManagerId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DeviceProperty entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.DeviceProperties.Add(entity);
            context.SaveChanges();
        }

        public void Update(DeviceProperty entity)
        {
            try
            {
                if (entity != null)
                {
                    context.DeviceProperties.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public IEnumerable<T> GetAll()
        //{
        //    return entities.AsEnumerable();
        //}

        //public void Insert(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Add(entity);
        //    context.SaveChanges();
        //}
        //public void Update(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    context.SaveChanges();
        //}
        //public void Delete(T entity)
        //{
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    entities.Remove(entity);
        //    context.SaveChanges();
        //}

        //public List<T> GetUsersDataByManagerId(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
