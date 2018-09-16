using DataBase;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   
    public class CourseRepository
    {
        DBContextS db = new DBContextS();

        public bool Insert(Course course)
        {
            db.Courses.Add(course);
            bool isSave= db.SaveChanges() > 0;
            return isSave;
        }

        public bool Update(Course course)
        {
            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Modified;
            bool isUpdated= db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Course course)
        {
            course.IsDelete = true;
            bool isUpdate= Update(course);
            return isUpdate;
        }

        public List<Course> GetAll()
        {
            List<Course> courses = db.Courses.Where(c=>c.IsDelete==false).ToList();
            return courses;
        }

        public List<Organization> GetAllorganization()
        {
            List<Organization> organizations = db.Organizations.ToList();
            return organizations;
        }
        public Course GetById(int id)
        {   var  course= db.Courses.FirstOrDefault(c => c.Id == id);
            return course;
        }

        public List<Course> GetCourseBySearch(CourseSearchCriteria criteria)
        {
            IQueryable<Course> courses = db.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(criteria.Name))
            {
                courses = courses.Where(c => c.Name.ToLower().Contains(criteria.Name.ToLower()));
            }
            if (criteria.OrganizationId > 0)
            {
                    courses = courses
                    .Where(c =>c.OrganizationId.ToString()
                    .ToLower().Contains(criteria.OrganizationId.ToString()));
            }

            if (!string.IsNullOrEmpty(criteria.Code))
            {
                courses = courses.Where(c => c.Duration.ToLower().Contains(criteria.Duration));
            }

            if ((criteria.Credit)>0)
            {
                courses = courses.Where(c => c.Outline.ToLower().Contains(criteria.Outline));
            }

            if (!string.IsNullOrEmpty(criteria.Tags))
            {
                courses = courses.Where(c => c.Tags.ToLower().Contains(criteria.Tags));
            }

            return courses.ToList();
        }
    }
}
