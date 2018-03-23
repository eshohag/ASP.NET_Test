using ASP.NET_Test.Models;
using CaptchaMvc.HtmlHelpers;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Test.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList().OrderBy(a => a.StudentId));
        }



        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "Tittle");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student model, HttpPostedFileBase image1)
        {
            if (this.IsCaptchaValid(""))
            {
                var studentIdIsExist = db.Students.Where(a => a.StudentId.Equals(model.StudentId));
                var contactNo = db.Students.FirstOrDefault(a => a.ContactNo == model.ContactNo);
                if (studentIdIsExist.Any())
                {
                    ViewBag.Message = "Already, Exist your Student ID-" + model.StudentId;
                }
                else if (contactNo != null)
                {
                    ViewBag.Message = "Already, Exist your Contact No-" + model.ContactNo;
                }
                else
                {
                    if (image1 != null)
                    {
                        model.BinaryDataImage = new byte[image1.ContentLength];
                        image1.InputStream.Read(model.BinaryDataImage, 0, image1.ContentLength);
                        string fileName = image1.FileName;
                        model.FileName = fileName;
                        string fileType = image1.ContentType;
                        model.FileType = fileType;
                        if (image1.ContentLength < 1024 * 1024)
                        {
                            if (fileType.ToLower() == "image/jpeg" || fileType.ToLower() == "image/png")
                            {
                                db.Students.Add(model);
                                db.SaveChanges();
                                ModelState.Clear();
                                ViewBag.Success = "Saved Student Basic Information";
                            }
                            else
                            {
                                ViewBag.Message = "Invalid Image Formate";
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Please make sure the file size is less than or equal to 1MB.";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Please Select Your Image File";
                    }
                }
            }
            else
            {
                ViewBag.Message = "Invalid Captcha!";
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "Id", "Tittle");
            return View();
        }


        // GET: Departments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var students = await db.Students.FindAsync(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Student student)
        {
            try
            {
                Student aStudent = db.Students.FirstOrDefault(a => a.Id == student.Id);
                aStudent.FullName = student.FullName;
                db.Students.AddOrUpdate(aStudent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                //Error
                Console.WriteLine(e.Message);
            }
            return View(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}