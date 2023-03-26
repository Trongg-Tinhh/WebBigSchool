using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebBigSchool.DTOs;
using WebBigSchool.Models;
using WebBigSchool.ViewModels;

namespace WebBigSchool.Controllers
{
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendencesController() {
            _dbContext = new ApplicationDbContext();        
        }

        /*[HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var userId = User.Identity.GetUserId();
            if(_dbContext.Attendances.Any(a=> a.AttendeeId== userId && a.CourseId== courseId))
            {
                return BadRequest("the attendance already exists!");
            }
            var attendance = new Attendance
            {
                CourseId = courseId,
                AttendeeId =userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }*/

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
            {
                return BadRequest("The attendance already exists!");
            }
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }

    }
}
