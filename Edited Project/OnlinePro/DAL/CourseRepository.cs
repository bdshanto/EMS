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
            return Update(course);
        }

        //public List<Course> GetAll()
        //{
        //    List<Course> courses= db.Courses.ToList();
        //    return courses;
        //}

        public List<Organization> GetAllorganization()
        {
            List<Organization> organizations = db.Organizations.ToList();
            return organizations;
        }
        public Course GetById(int id)
        {   var  course= db.Courses.FirstOrDefault(c => c.Id == id);
            return course;
        }
    }
}
