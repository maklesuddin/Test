using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlinePro.Controllers
{
    public class CourseController : Controller
    {
        CourseManager _courseManager=new CourseManager();
        // GET: Course
        public ActionResult Index(CourseSearchCriteria model)
        {
            /*List<Course> courses =*/
          var courses = _courseManager.GetCourseBySearch(model);
          if (courses == null)
          {
             courses = new List<Course>();
          }
            model.Courses = courses;
            return View(model);
        }


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
                var isAdded = _courseManager.Insert(course);

                if (isAdded)
                {
                    return RedirectToAction("Index");
                    //return View(course);
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
            //return View(course);
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var course = new Course();
            if (id > 0)
            {
              course = _courseManager.GetById(id);
            }
            
              bool isRemove = _courseManager.Delete(course);

              if (isRemove)
              {
                //ViewBag.msc = "Success";
                return RedirectToAction("Index");
              }


                //if (id < 0)
                //{
                //    //course = _courseManager.GetById(id);
                //    return HttpNotFound();
                //}
               //bool isRemove = _courseManager.Delete(course);
                //if (isRemove)
                //{
                //    //ViewBag.msc = "Success";
                //    return RedirectToAction("Index");
                //}
                //else
                //{
                //    ViewBag.msc = "Failed";
                //    return View(course);
                //}

            
            
            return View();
        }

        //[HttpPost]
        //public ActionResult Delete(Course course)
        //{

        //    bool isRemove = _courseManager.Delete(course);
        //    if (isRemove)
        //    {
        //      //ViewBag.msc = "Success";
        //      return RedirectToAction("Index");
        //    }
        //    //else
        //    //{
        //    //    ViewBag.msc = "Failed";
        //    //    return View(course);
        //    //}


        //  return View();
        //}

        public ActionResult Search( CourseSearchCriteria criteria)
        {
            List<Course> courses = _courseManager.GetCourseBySearch(criteria);
            if (courses!= null)
            {
                return View(criteria);
            }

            return View();
        }

    }
}

