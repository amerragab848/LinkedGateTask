using DAL.EF;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Servicces
{
    public  class DeviceCategoryService
    {
        DeviceDBEntities context = new DeviceDBEntities();

        private IBaserepository<DeviceCategory> repository;
        
        DeviceService Device = new DeviceService();

        public DeviceCategoryService()
        {
            this.repository = new DeviceCategoryRepository( new DeviceDBEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<DeviceCategory> GetAllDeviceCategories()
        {
            var DeviceCategory = repository.GetAll();
            if (DeviceCategory != null)
            {
                return DeviceCategory;
            }
            return new List<DeviceCategory>();
        }
        public DeviceCategory GetDeviceCategoryById(int? id)
        {
            var DeviceCategory = GetAllDeviceCategories().Where(c => c.Id == id).FirstOrDefault();
            return DeviceCategory;
        }
        //public DeviceCategory GetByStdId(int? id)
        //{
        //    var student = repository.GetByStdId(id);
        //    return student;
        //}
        
        public void InsertDeviceCategory(DeviceCategory entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateDeviceCategory(DeviceCategory entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteDeviceCategory(DeviceCategory entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
