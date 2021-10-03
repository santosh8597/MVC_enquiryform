using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnquiryForm.Models;
using System.Text.RegularExpressions;

namespace EnquiryForm.Controllers
{
    public class StudentController : Controller
    {
        EnquirydbEntities db;

        public StudentController()
        {
            db = new EnquirydbEntities();
        }
      
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetEnquiryFor()
        {
            List<tblEnquiry> st = db.tblEnquiries.ToList();
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInformation()
        {
            return Json(db.tblInformations.ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTraining()
        {
            return Json(db.tblTrainings.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string AddCandidateDetails(tblCandidateDetail c)
        {
            db.tblCandidateDetails.Add(c);
            db.SaveChanges();
            return "StudentDetails Added Successfully";
        }
        public ActionResult Display()
        {
          return  View();
        }

        public JsonResult GetStudentInfo()
        {
            List<viewDetail> lst = new List<viewDetail>();
            foreach(viewDetail x in db.viewDetails.ToList())
            {
                viewDetail ve = new viewDetail() { Candidate_id = x.Candidate_id, Candidate_name = x.Candidate_name, Address = x.Address, Mobile = x.Mobile, emailId = x.emailId, Enquiry_id = x.Enquiry_id, Enquiry_Date = x.Enquiry_Date, EnquiryFor = x.EnquiryFor, Lead_sources = x.Lead_sources, EnquiryBy = x.EnquiryBy };
                string[] EnqueryName = Regex.Split(x.EnquiryFor, ",");
                string ename = "";
                foreach(string r in EnqueryName)
                {
                    int eid = Convert.ToInt32(r);
                    tblEnquiry e = db.tblEnquiries.Find(eid);
                    ename += "," + e.Enquiry_name;
                }
                ename = ename.Substring(1, ename.Length - 1);
                ve.EnquiryFor = ename;

                string[] leadsource = Regex.Split(x.Lead_sources, ",");

                string lnames = "";
                foreach(string  a in leadsource)
                {
                    int r = Convert.ToInt32(a);
                    tblInformation i = db.tblInformations.Find(r);
                    lnames += "," + i.Information_form;
                }
                lnames = lnames.Substring(1, lnames.Length - 1);
                ve.Lead_sources = lnames;


                string [] traning =Regex.Split(x.EnquiryBy,",");
                string nametraning = "";
                foreach(string a in traning)
                {
                    int r = Convert.ToInt32(a);
                    tblTraining i = db.tblTrainings.Find(r);
                    nametraning += "," + i.Training_course;
                }
                nametraning = nametraning.Substring(1, nametraning.Length - 1);
                ve.EnquiryBy = nametraning;

                lst.Add(ve);
            }
            return Json( lst,JsonRequestBehavior.AllowGet);
        }

	}
}