using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLTE.Modelss;
using AdminLTE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AdminLTE.ClassesFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.Controllers
{
    public class SchoolDBController : Controller
    {
        Classes cls = new Classes();
        public IActionResult Index()
        {
            IList<StudentViewModel> students = null;
            using (var ctx = new SchoolDBContext())
            {
                students = ctx.Student
                            .Select(s => new StudentViewModel()
                            {
                                StudentId = s.StudentId,
                                StudentName = s.StudentName,
                                StandardId = (int)s.StandardId,
                                //Standard = new StandardViewModel()
                                //{
                                //    StandardVMId = s.Standard.StandardId,
                                //    Name = s.Standard.StandardName
                                //},
                                //Address = new AddressViewModel()
                                //{
                                //    Address1 = s.StudentAddress.Address1,
                                //    City = s.StudentAddress.City
                                //}


                            }).ToList<StudentViewModel>();
                return View(students);
            }
        }
        public IActionResult SyncFusionInlineGridGetStudent()
        {
            var students = cls.GetAllStudents();
            //ViewBag.dataSource = students[0].StudentName;
            ViewBag.dataSource = students.ToArray(); ;
            ViewBag.ddDataSource = new string[] { "Top", "Bottom" };
            return View();
            
        }

        public IActionResult Defaultfunctionalities()
        {
            var students = cls.GetAllStudents();
            ViewBag.dataSource = students;           
            return View();

        }
        //JsonResult
        [HttpPost]        
        public IActionResult Update(StudentViewModel value, string action)
        {
            using (var ctx = new SchoolDBContext())
            {
                var data = ctx.Student.Where(st => st.StudentId == value.StudentId).FirstOrDefault();
                if (data != null)
                {
                    data.StudentId = value.StudentId;
                    data.StudentName = value.StudentName;
                    data.StandardId = value.StandardId;
                    ctx.SaveChanges();
                    //
                }
                //ViewBag.JavaScriptFunction = string.Format("ShowGreetings('{0}');", name);
                //td);
                //return;
                return Json(value);
               // RedirectToAction("SyncFusionInlineGridGetStudent","SchoolDB");
                //return View("SyncFusionInlineGridGetStudent");
                //this.RedirectToPage

            }

            //RedirectToAction("SyncFusionInlineGridGetStudent");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Remove(int key)
        {
            using (var ctx = new SchoolDBContext())
            {
                var data = ctx.Student.Where(st => st.StudentId == key).FirstOrDefault();
                if (data != null)
                {
                    ctx.Student.Remove(data);
                    ctx.SaveChanges();
                }
            }
        }

        public IActionResult ChartJs1()
        {
            string[] arrMonth = { "1 month", "2 month", "3 month", "4 month", "5 month", "6 month" };
            
             //C# convert JSON string
             string jsonMonth = Newtonsoft.Json.JsonConvert.SerializeObject(arrMonth);
                         ViewBag.JsonMonth = jsonMonth;

            
            List<Branch> branchs = new List<Branch>
             {
                  new Branch
                 {
                    City = "Taipei",
                    Business = new double[] { 13.1, 10.2, 13.5, 20.9, 25.2, 27.1, 31.8 }
                 },
                 new Branch{
                     City="Kaohsiung",
                     Business = new double[] { 29.1, 28.3, 22.6, 25.4, 27.5, 23.4 }

                 },
                 new Branch{
                     City="Vietnam?",                     
                     Business = new double[] { 16.6, 17.3, 19.2, 23.8, 12.0, 17.6 }
                 }
             };
            
             //C# convert JSON string
             string jsonBusiness = Newtonsoft.Json.JsonConvert.SerializeObject(branchs);
                        ViewBag.JsonBusiness = jsonBusiness;
            
            //Return JSON Format, let all kinds client Installations to AJAX Mode call API
             //return Json(branchs, JsonRequestBehavior.AllowGet);

             return View(branchs);
         }

        
        public IActionResult ChartJs2AJAX()
        {
            //List<object> iData = new List<object>();
            //string[] arrMonth = { "1 month", "2 month", "3 month", "4 month", "5 month", "6 month" };
            //iData.Add(arrMonth);

            ////C# convert JSON string
            //string jsonMonth = Newtonsoft.Json.JsonConvert.SerializeObject(arrMonth);
            ////ViewBag.JsonMonth = jsonMonth;


            //List<Branch> branchs = new List<Branch>
            // {
            //      new Branch
            //     {
            //        City = "Taipei",
            //        Business = new double[] { 13.1, 10.2, 13.5, 20.9, 25.2, 27.1, 31.8 }

            //     },
            //     new Branch{
            //         City="Kaohsiung",
            //         Business = new double[] { 29.1, 28.3, 22.6, 25.4, 27.5, 23.4 }

            //     },
            //     new Branch{
            //         City="Vietnam?",
            //         Business = new double[] { 16.6, 17.3, 19.2, 23.8, 12.0, 17.6 }
            //     }
            // };

            //iData.Add(branchs);

            ////C# convert JSON string
            //string jsoniData = Newtonsoft.Json.JsonConvert.SerializeObject(iData);
            ////ViewBag.JsonBusiness = jsonBusiness;

            ////Return JSON Format, let all kinds client Installations to AJAX Mode call API
            ////return Json(branchs, JsonRequestBehavior.AllowGet);

            //return new JsonResult(iData);
            return View("ChartJs2AJAX");
        }
        //JsonResult
        [HttpPost]
        public JsonResult ChartJs3AJAX()
        {
            List<object> iData = new List<object>();
            string[] arrMonth = { "1 month", "2 month", "3 month", "4 month", "5 month", "6 month" };
            //iData.Add(arrMonth);

            //C# convert JSON string
            string jsonMonth = Newtonsoft.Json.JsonConvert.SerializeObject(arrMonth);
            //ViewBag.JsonMonth = jsonMonth;


            List<Branch> branchs = new List<Branch>
             {
                  new Branch
                 {
                    City = "Taipei",
                    Business = new double[] { 13.1, 10.2, 13.5, 20.9, 25.2, 27.1, 31.8 }

                 },
                 new Branch{
                     City="Kaohsiung",
                     Business = new double[] { 29.1, 28.3, 22.6, 25.4, 27.5, 23.4 }

                 },
                 new Branch{
                     City="Vietnam?",
                     Business = new double[] { 16.6, 17.3, 19.2, 23.8, 12.0, 17.6 }
                 }
             };

            iData.Add(branchs);

            //C# convert JSON string
            string jsoniData = Newtonsoft.Json.JsonConvert.SerializeObject(iData);
            //ViewBag.JsonBusiness = jsonBusiness;

            //Return JSON Format, let all kinds client Installations to AJAX Mode call API
            //return Json(branchs, JsonRequestBehavior.AllowGet);

            //return new JsonResult(iData);
            JsonResult js = Json(iData);
            //return  Json(js);
            //return Json(iData.ToArray());
            //JsonResult js = Json(branchs);
            return Json(iData);
            //return jsoniData;
            //return Json(iData);
        }

        public IActionResult GetStudentView()
        {
            
            return View();
        }

        //[HttpPost]
        public async Task<ActionResult<List<StudentViewModel>>> getStudentAJAX2()
        //public JsonResult getStudentAJAX()
        {

            SchoolDBContext ctx = new SchoolDBContext();
            
              var  students = await ctx.Student
                            .Select(s => new StudentViewModel()
                            {
                                StudentId = s.StudentId,
                                StudentName = s.StudentName,
                                StandardId = (int)s.StandardId
                            }).ToListAsync<StudentViewModel>();
            

                //var students = await cls.GetAllStudents().ToListAsync<StudentViewModel>(); ;
                //return Json(students);
                return students;
        }
       

    }



}
