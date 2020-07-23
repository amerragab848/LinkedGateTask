
using DAL.EF;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DLL.Repository
{
    public class DeviceCategoryRepository : IBaserepository<DeviceCategory> 
    {
        private readonly DeviceDBEntities context;
       // private DbSet<Student> entities;
        string errorMessage = string.Empty;
        public DeviceCategoryRepository(DeviceDBEntities context)
        {
            this.context = context;
          //  entities = context.Set<Student>();
        }

        public void Delete(DeviceCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.DeviceCategories.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<DeviceCategory> GetAll()
        {
            var res = context.DeviceCategories.Include(c => c.Device);
               
            return res;
        }

        public List<DeviceCategory> GetUsersDataByManagerId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DeviceCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.DeviceCategories.Add(entity);
            context.SaveChanges();
        }

        public void Update(DeviceCategory entity)
        {
            try
            {
                if (entity != null)
                {
                    context.DeviceCategories.Attach(entity);
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
