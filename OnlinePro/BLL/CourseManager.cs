using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CourseManager
    {
        CourseRepository _courseRepository = new CourseRepository();
        public bool Insert(Course course)
        {
            bool issave = _courseRepository.Insert(course);
            return issave;
        }

        public bool Update(Course course)
        {
            bool isUpdate= _courseRepository.Update(course);
            return isUpdate;
        }

        public bool Delete(Course course)
        {
            return _courseRepository.Delete(course);
        }
        public List<Course> GetAll()
        {
            List<Course> courses = _courseRepository.GetAll();
            return courses;
        }
        public List<Organization> GetAllorganization()
        {
            List<Organization> organizations = _courseRepository.GetAllorganization();
            return organizations;
        }

        public Course GetById(int id)
        {
           var course= _courseRepository.GetById(id);
            return course;
        }

        public List<Course> GetCourseBySearch(CourseSearchCriteria criteria)
        {
          List<Course> courses = _courseRepository.GetCourseBySearch(criteria);
            return courses;
        }

    
    }
}
