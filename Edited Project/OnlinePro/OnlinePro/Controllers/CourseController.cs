using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlinePro.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager=new CourseManager();
        // GET: Course
        public ActionResult Entry()
        {
            Course course=new Course();
            List<Organization> organizations = _courseManager.GetAllorganization();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Organization organizationdata in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationdata.Name;
                selectListItem.Value = organizationdata.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            course.SelectListItemsOraganization = selectListItems;
            return View(course);
        }
        [HttpPost]
        public ActionResult Entry(Course course )
        {
           // var course = new Course();
            List<Organization> organizations = _courseManager.GetAllorganization();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Organization organizationdata in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationdata.Name;
                selectListItem.Value = organizationdata.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            course.SelectListItemsOraganization = selectListItems;
            //return View(course);


            if (ModelState.IsValid)
            {
                //ViewBag.Course = course;
                var isAdded=_courseManager.Insert(course);

                if (isAdded)
                {
                    return View(course);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Course course = new Course();
            if (id > 0)
            {
               course = _courseManager.GetById(id);
            }

            List<Organization> organizations = _courseManager.GetAllorganization();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Organization organizationdata in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationdata.Name;
                selectListItem.Value = organizationdata.Id.ToString();
                selectListItems.Add(selectListItem);
            }
            course.SelectListItemsOraganization=new List<SelectListItem>();
            course.SelectListItemsOraganization = selectListItems;
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
             //course = new Course();
             var isupdate = _courseManager.Update(course);
           
            List<Organization> organizations = _courseManager.GetAllorganization();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (Organization organizationdata in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationdata.Name;
                selectListItem.Value = organizationdata.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            course.SelectListItemsOraganization =new List<SelectListItem>() ;
            course.SelectListItemsOraganization = selectListItems;

            if (isupdate)
            {
                ViewBag.msc = "Success";
                return View(course);
            }

            ViewBag.msc = "Fialed";
            return View(course);
        }

    }
}

