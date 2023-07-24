using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestStudentRegistration;
using TestStudentRegistration.Models;
using TestStudentRegistration.Services;

namespace TestStudentRegistration.Controllers
{
    public class StudentMasterController : ApiController
    {
        //private StudentSampleEntities db = new StudentSampleEntities();

        private StudentService studentService = new StudentService();
        // GET: api/StudentMaster
        //public IQueryable<StudentMaster> GetStudentMaster()
        //{
        //    return db.StudentMaster;
        //}

        [HttpGet]
        [Route("api/StudentMaster/GetAll")]
        [ResponseType(typeof(StudentMasterDTO))]
        public async Task<IHttpActionResult> GetAll()
        {
            try
            {

                var studentMaster = await studentService.GetAll();
                return Ok(studentMaster);

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }


        [HttpGet]
        [Route("api/StudentMaster/SearchStudent/{searchText}")]
        [ResponseType(typeof(StudentMasterDTO))]
        public async Task<IHttpActionResult> Search(string searchText)
        {
            try
            {
                var studentMaster = await studentService.Search(searchText);
                return Ok(studentMaster);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // GET: api/StudentMaster/5
        [HttpGet]
        [ResponseType(typeof(StudentMasterDTO))]
        public async Task<IHttpActionResult> StudentMaster(int id)
        {
            try
            {
                //using (var studentService = new StudentService())
                //{
                //    error
                //}

                var studentMaster = await studentService.GetById(id);

                if (studentMaster == null)
                {
                    return NotFound();
                }

                return Ok(studentMaster);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // PUT: api/StudentMaster/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudentMaster(StudentMasterUpdateRequest studentMaster)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var studentMasterResult = await studentService.Update(studentMaster);
                return Ok(studentMasterResult);

            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // POST: api/StudentMaster
        [ResponseType(typeof(StudentMaster))]
        public async Task<IHttpActionResult> PostStudentMaster(StudentMasterAddRequest studentMaster)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var studentMasterResult = await studentService.Save(studentMaster);


                return CreatedAtRoute("DefaultApi", new { id = studentMasterResult.Id }, studentMasterResult);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // DELETE: api/StudentMaster/5
        [ResponseType(typeof(StudentMaster))]
        public async Task<IHttpActionResult> DeleteStudentMaster(int id)
        {
            try
            {
                var studentMasterResult = await studentService.Delete(id);

                if (studentMasterResult == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
        }



    }
}
