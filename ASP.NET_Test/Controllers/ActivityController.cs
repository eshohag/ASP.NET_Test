using ASP.NET_Test.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ASP.NET_Test.Controllers
{
    public class ActivityController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Activity
        public ActionResult Index()
        {
            ViewBag.Students = new SelectList(db.Students, "Id", "StudentId");
            ViewBag.Days = new SelectList(db.Dayses.ToList(), "Id", "Day");
            return View();
        }
        [HttpPost]
        public ActionResult Index(Activity activity)
        {
            if (ModelState.IsValid)
            {
                var isExist = db.Activities.FirstOrDefault(a =>
                    a.DaysId == activity.DaysId && a.StudentId == activity.StudentId);
                if (isExist == null)
                {
                    db.Activities.Add(activity);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Success = "Saved Student Activity in a Day";

                }
                else
                {
                    ViewBag.Message = " Exist your Activity";
                }
            }
            ViewBag.Students = new SelectList(db.Students, "Id", "StudentId");
            ViewBag.Days = new SelectList(db.Dayses.ToList(), "Id", "Day");
            return View();
        }


        public ActionResult History()
        {
            return View();
        }
        [HttpPost]
        public ActionResult History(Student student)
        {
            var aStudent = db.Students.FirstOrDefault(a => a.StudentId == student.StudentId);
            if (aStudent != null)
            {
                List<Activity> activities = db.Activities.Where(a => a.StudentId == aStudent.Id).ToList();
                GetDetailsHistory(aStudent, activities);
            }
            else
            {
                ViewBag.Message = " Student ID-" + student.StudentId;
            }
            return View();
        }

        private void GetDetailsHistory(Student aStudent, List<Activity> activities)
        {
            int sl = 1;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] {
                    new DataColumn("SL", typeof(string)),
                    new DataColumn("Day", typeof(string))
            });
            foreach (var activity in activities)
            {
                dt.Rows.Add(sl, activity.Days.Day);
                sl++;
            }

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Header.
                    sb.Append("<br/>");
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2' style='font-family: Calibri; font-size: 8pt;'>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td style='font-size:14pt;'><b> ");
                    sb.Append(aStudent.FullName);
                    sb.Append("</b></td><td align = 'right'> Student ID: ");
                    sb.Append(aStudent.StudentId);
                    sb.Append(" </td></tr>");


                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Contact No: </b>");
                    sb.Append(aStudent.ContactNo);
                    sb.Append("</td><td align = 'right'> Department: ");
                    sb.Append(aStudent.Department.Tittle);



                    sb.Append(" </td></tr>");

                    sb.Append("</table>");

                    sb.Append("<br />");
                    sb.Append("<br />");

                    //Generate Days Grid.
                    sb.Append("<table border = '0' style='font-family: Calibri; font-size: 7pt;'>");
                    sb.Append("<tr style='font-weight: bold; color:red;'>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</tr></table>");
                    sb.Append("<br/>");


                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2' style='font-family: Calibri; font-size: 6pt;'>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td>Total Present Day: ");
                    sb.Append(activities.Count);
                    sb.Append("</td><td align = 'right'>");
                    sb.Append(" </td></tr>");
                    sb.Append("</table>");

                    sb.Append("<br/>");
                    sb.Append("<br/>");
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2' style='font-family: Calibri; font-size: 6pt;'>");

                    sb.Append("<tr><td><span style='font-size:14pt;font-weight:bold; color:red;'>Thank you!</span></td></tr>");

                    sb.Append("<tr><td>Developed by: https://shohag.azurewebsites.net </td>");
                    sb.Append("</table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 40f, 0f);
                    var htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();

                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=StudentID-" + aStudent.StudentId + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
    }
}