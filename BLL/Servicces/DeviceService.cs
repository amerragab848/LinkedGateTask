using DAL.EF;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Servicces
{
    public class DeviceService
    {
        DeviceDBEntities context = new DeviceDBEntities();

        private IRepository<Device> repository;
        public DeviceService()
        {
            this.repository = new Repository<Device>(new DeviceDBEntities());
        }

        //public EmployeeService()
        //{
        //}

        public IEnumerable<Device> GetAllDevices()
        {
            var Device = repository.GetAll();
            if (Device != null)
            {
                return Device;
            }
            return new List<Device>();
        }
        public Device GetDeviceById(int? id)
        {
            var neighborhood = GetAllDevices().Where(c => c.Id == id).FirstOrDefault();
            return neighborhood;
        }
        public void InsertDevice(Device entity)
        {
            if (entity != null)
            {
                repository.Insert(entity);
            }
        }
        public void UpdateDevice(Device entity)
        {
            if (entity != null)
            {
                repository.Update(entity);
            }
        }
        public void DeleteDevice(Device entity)
        {
            if (entity != null)
            {
                repository.Delete(entity);
            }
        }
    }
}
