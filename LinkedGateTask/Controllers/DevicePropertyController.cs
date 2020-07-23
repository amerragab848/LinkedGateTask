using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//added
using BLL.Servicces;
using ArmyTechTask.Models;
using DataAccessL.EF;
using System.Net;
using Newtonsoft.Json;

namespace ArmyTechTask.Controllers
{
    public class DevicePropertyController : Controller
    {
        StudentService studentService = new StudentService();
        FieldService fieldService = new FieldService();
        GovernorateService governorateService = new GovernorateService();
        NeighborhoodService neighborhoodService = new NeighborhoodService();

        // GET: Student
        public ActionResult Index()
        {
            StudentVM student = new StudentVM();

            student.Governorates = governorateService.GetAllGovernorates().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.Fields = fieldService.GetAllFields().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            student.Neighborhoods = neighborhoodService.GetAllNeighborhoods().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.ID.ToString()
            }).ToList();
            return View(student);
        }
        public JsonResult GetStudentList()
        {
            List<StudentListingVM> studentListingVM = new List<StudentListingVM>();
            studentService.GetAllStudents().ToList().ForEach(c => {
                StudentListingVM studentListing = new StudentListingVM
                {
                    ID = c.ID,
                    Name = c.Name,
                    BirthDate=c.BirthDate.ToString("dd-MM-yyyy"),
                    Field=c.Field.Name,
                    Governorate=c.Governorate.Name,
                    Neighborhood=c.Neighborhood.Name

                };
                studentListingVM.Add(studentListing);
            });

            return Json(studentListingVM,JsonRequestBehavior.AllowGet);
        }

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            var student = studentService.GetStudentById(id);
            StudentListingVM studentListingVM = new StudentListingVM()
            {
                ID = student.ID,
                Name = student.Name,
                BirthDate = student.BirthDate.ToString("dd-MM-yyyy"),
                Field = student.Field.Name,
                Governorate = student.Governorate.Name,
                Neighborhood = student.Neighborhood.Name
            };
            return View(studentListingVM);
        }

        // GET: Field/Create
        //public ActionResult Create()
        //{

        //    StudentVM student = new StudentVM();
        //    student.Governorates = governorateService.GetAllGovernorates().Select(a => new SelectListItem
        //    {
        //        Text = a.Name,
        //        Value = a.ID.ToString()
        //    }).ToList();
        //    student.Fields = fieldService.GetAllFields().Select(a => new SelectListItem
        //    {
        //        Text = a.Name,
        //        Value = a.ID.ToString()
        //    }).ToList();
        //    student.Neighborhoods = neighborhoodService.GetAllNeighborhoods().Select(a => new SelectListItem
        //    {
        //        Text = a.Name,
        //        Value = a.ID.ToString()
        //    }).ToList();
        //    return View(student);
        //}

        // POST: Field/Create
        [HttpPost]
        public ActionResult AddStudent(StudentVM student)
        {
            var result = false;
            try
            {
                if (student.ID > 0)
                {
                    var studentEF = studentService.GetStudentById(student.ID);

                    if (studentEF != null)
                    {
                        studentEF.ID = student.ID;
                        studentEF.Name = student.Name;
                        studentEF.GovernorateId = student.GovernorateId;
                        studentEF.NeighborhoodId = student.NeighborhoodId;
                        studentEF.FieldId = student.FieldId;
                        studentService.UpdateStudent(studentEF);

                    }
                }
                else
                {
                    Student studentEF = new Student
                    {
                        ID = student.ID,
                        Name = student.Name,
                        GovernorateId = student.GovernorateId,
                        BirthDate =Convert.ToDateTime( student.BirthDate),
                        FieldId = student.FieldId,
                        NeighborhoodId = student.NeighborhoodId
                    };
                    studentService.InsertStudent(studentEF);
                }
               
                result = true;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public JsonResult GetStudentById(int StudentId)
        //{
        //    var studentEF = studentService.GetByStdId(StudentId);
        //    StudentVM student =new StudentVM
        //    {

        //    }
        //    string value = string.Empty;
        //    value = JsonConvert.SerializeObject(studentEF, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}
        // GET: Field/Edit/5
        public JsonResult GetStudentById(int id)
        {
            var studentEF = studentService.GetByStdId(id);
            StudentVM student = new StudentVM();

            //student.Governorates = governorateService.GetAllGovernorates().Select(a => new SelectListItem
            //{
            //    Text = a.Name,
            //    Value = a.ID.ToString()
            //}).ToList();
            //student.Fields = fieldService.GetAllFields().Select(a => new SelectListItem
            //{
            //    Text = a.Name,
            //    Value = a.ID.ToString()
            //}).ToList();
            //student.Neighborhoods = neighborhoodService.GetAllNeighborhoods().Select(a => new SelectListItem
            //{
            //    Text = a.Name,
            //    Value = a.ID.ToString()
            //}).ToList();
            student.FieldVM = new FieldVM
            {
                Name = studentEF.Field.Name
            };

            student.GovernorateVM = new GovernorateVM
            {
                Name = studentEF.Governorate.Name
            };
            student.NeighborhoodVM = new NeighborhoodVM
            {
                Name = studentEF.Name
            };
            student.ID = studentEF.ID;
            student.Name = studentEF.Name;
            student.BirthDate = studentEF.BirthDate.ToString("dd-MM-yyyy");
            student.FieldId = studentEF.FieldId;
            student.GovernorateId = studentEF.GovernorateId;
            student.NeighborhoodId = studentEF.NeighborhoodId;

            string value = string.Empty;

            value = JsonConvert.SerializeObject(student, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        // POST: Field/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, StudentVM student)
        //{
        //    try
        //    {
        //        var studentEF = studentService.GetStudentById(id);

        //        if (studentEF != null)
        //        {
        //            studentEF.ID = student.ID;
        //            studentEF.Name = student.Name;
        //            studentEF.GovernorateId = student.GovernorateId;

        //            studentService.UpdateStudent(studentEF);

        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        //public ActionResult Delete(int? id)
        //{
        //    if (id < 0)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }


        //    var student = studentService.GetStudentById(id);
        //    StudentListingVM studentListingVM = new StudentListingVM()
        //    {
        //        ID = student.ID,
        //        Name = student.Name,
        //        BirthDate = student.BirthDate,
        //        Field = student.Field.Name,
        //        Governorate = student.Governorate.Name,
        //        Neighborhood = student.Neighborhood.Name
        //    };
        //    return View(studentListingVM);
        //    // return View();
        //}
        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult DeleteStudentRecord(int id)
        {
            bool result = false;
            try
            {
                var student = studentService.GetStudentById(id);
                studentService.DeleteStudent(student);
                 result = true;
                return Json(result, JsonRequestBehavior.AllowGet);
                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
