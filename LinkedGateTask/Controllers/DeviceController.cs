using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
    //added
using BLL.Servicces;
using LinkedGateTask.Models;
using Microsoft.Ajax.Utilities;
using BLL;
namespace ArmyTechTask.Controllers
{
    public class DeviceController : Controller
    {
        DeviceService DeviceService = new DeviceService();
        // GET: Teacher
        public ActionResult Index()
        {
            List<TeacherListingVM> teacherListingVM = new List<TeacherListingVM>();
            teacherService.GetAllTeachers().ToList().ForEach(c => {
                TeacherListingVM teacherListing = new TeacherListingVM
                {
                    ID = c.ID,
                    Name = c.Name,
                    BirthDate=c.BirthDate.ToString()
                };
                teacherListingVM.Add(teacherListing);
            });

            return View(teacherListingVM);
        }

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            var teacher = teacherService.GetTeacherById(id);
            TeacherVM teacherVM = new TeacherVM()
            {
                ID = teacher.ID,
                Name = teacher.Name,
                BirthDate = teacher.BirthDate
            };
            return View(teacherVM);
        }

        // GET: Field/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Field/Create
        [HttpPost]
        public ActionResult Create(TeacherVM teacherVM)
        {
            try
            {
                Teacher teacher = new Teacher
                {
                    ID = teacherVM.ID,
                    Name = teacherVM.Name,
                    BirthDate=teacherVM.BirthDate
                    
                };
                teacherService.InsertTeacher(teacher);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: Field/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = teacherService.GetTeacherById(id);
            TeacherVM teacherVM = new TeacherVM()
            {
                ID = teacher.ID,
                Name = teacher.Name,
                BirthDate=teacher.BirthDate
            };
            return View(teacherVM);
        }

        // POST: Field/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TeacherVM teacher)
        {
            try
            {
                var teacherEF = teacherService.GetTeacherById(id);

                if (teacherEF != null)
                {
                    teacherEF.ID = teacher.ID;
                    teacherEF.Name = teacher.Name;
                    teacherEF.BirthDate = teacher.BirthDate;
                    teacherService.UpdateTeacher(teacherEF);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ActionResult Delete(int? id)
        {
            var teacher = teacherService.GetTeacherById(id);
            TeacherVM teacherVM = new TeacherVM()
            {
                ID = teacher.ID,
                Name = teacher.Name,
                BirthDate = teacher.BirthDate
            };
            return View(teacherVM);

        }
        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult Delete(int id )
        {
            try
            {
                var teacher = teacherService.GetTeacherById(id);
                teacherService.DeleteTeacher(teacher);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
