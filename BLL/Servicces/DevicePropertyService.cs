using DAL.EF;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL.Servicces
{
    public  class DevicePropertyService
    {
        DeviceDBEntities context = new DeviceDBEntities();

        private IBaserepository<DeviceProperty> repository;
        //FieldService fieldService = new FieldService();
        //GovernorateService governorateService = new GovernorateService();
        //DeviceService neighborhoodService = new DeviceService();

        public DevicePropertyService()
        {
            this.repository = new DevicePropertyRepository(new DeviceDBEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<DeviceProperty> GetAllDeviceProperties()
        {
            var DeviceProperty = repository.GetAll();
            if (DeviceProperty != null)
            {
                return DeviceProperty;
            }
            return new List<DeviceProperty>();
        }
        public DeviceProperty GetGetDevicePropertiesById(int? id)
        {
            var student = GetAllDeviceProperties().Where(c => c.Id == id).FirstOrDefault();
            return student;
        }
        //public DeviceProperty GetByStdId(int? id)
        //{
        //    var student = repository.GetByStdId(id);
        //    return student;
        //}
        
        public void InsertStudent(DeviceProperty entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateDeviceProperty(DeviceProperty entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteDeviceProperty(DeviceProperty entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
