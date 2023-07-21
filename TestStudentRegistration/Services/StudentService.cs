using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestStudentRegistration.Models;
using TestStudentRegistration.Services.AutoMapper;

namespace TestStudentRegistration.Services
{

    public class StudentService
    {
        //private StudentSampleEntities db = new StudentSampleEntities();

        internal async Task<List<StudentMasterDTO>> GetAll()
        {
            try
            {
                using (var db = new StudentSampleEntities())
                {
                    //  not useed server side paginations

                    var studentMaster = await db.StudentMasters.Where(x => x.IsDeleted != true).ToListAsync();
                    var studentList = studentMaster.ToMap<List<StudentMasterDTO>>();

                    return studentList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal async Task<List<StudentMasterDTO>> Search(string searchText)
        {
            try
            {
                using (var db = new StudentSampleEntities())
                {
                    //  not useed server side paginations

                    var studentMaster = await db.StudentMasters.Where(x => 
                    (x.FirstName.Contains(searchText.ToString()) 
                    || x.LastName.Contains(searchText.ToString()) 
                    || x.Mobile.Contains(searchText.ToString())
                    || x.DateOfBirth.ToString().Contains(searchText)
                    || x.NIC.Contains(searchText.ToString())
                    || x.Email.Contains(searchText.ToString()) 
                    || x.Address.Contains(searchText.ToString()) ) && x.IsDeleted != true).ToListAsync();

                    var studentList = studentMaster.ToMap<List<StudentMasterDTO>>();

                    return studentList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal async Task<StudentMasterDTO> GetById(int id)
        {
            try
            {
                using (var db = new StudentSampleEntities())
                {
                    StudentMaster studentMaster = await db.StudentMasters.Where(x => x.IsDeleted != true && x.Id == id).FirstAsync();

                    StudentMasterDTO student = studentMaster.ToMap<StudentMasterDTO>();
                    if (student == null)
                    {
                        throw new Exception("No Record Found");
                    }
                    return student;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal async Task<StudentMasterDTO> Save(StudentMasterAddRequest addRequest)
        {
            try
            {
                using (var db = new StudentSampleEntities())
                {
                    StudentMaster student = addRequest.ToMap<StudentMaster>();

                    byte[] imageToBytes;
                    imageToBytes = imageToBytes = addRequest.Base64Image != null ? Convert.FromBase64String(addRequest.Base64Image) : null;
                    student.Image = imageToBytes;
                    db.StudentMasters.Add(student);
                    var result = await db.SaveChangesAsync();
                    StudentMasterDTO studentResult = result.ToMap<StudentMasterDTO>();
                    return studentResult;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        internal async Task<StudentMasterDTO> Update(StudentMasterUpdateRequest updateRequest)
        {
            try
            {
                using (var db = new StudentSampleEntities())
                {

                    var _current = await db.StudentMasters.FindAsync(updateRequest.Id);


                    byte[] imageToBytes;
                    imageToBytes = updateRequest.Base64Image != null ? Convert.FromBase64String(updateRequest.Base64Image) : null;

                    // couldnt use auto mapper 

                    _current.FirstName = updateRequest.FirstName;
                    _current.LastName = updateRequest.LastName;
                    _current.FirstName = updateRequest.FirstName;
                    _current.DateOfBirth = updateRequest.DateOfBirth;
                    _current.Mobile = updateRequest.Mobile;
                    _current.Email = updateRequest.Email;
                    _current.NIC = updateRequest.NIC;
                    _current.Image = imageToBytes;


                    db.Entry(_current).State = EntityState.Modified;
                    var result = await db.SaveChangesAsync();

                    StudentMasterDTO studentResult = result.ToMap<StudentMasterDTO>();

                    return studentResult;
                }


            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal async Task<StudentMasterDTO> Delete(int id)
        {
            try
            {
                using (var db = new StudentSampleEntities())
                {
                    var _current = await db.StudentMasters.FindAsync(id);
                    _current.IsDeleted = true;

                    var result = await db.SaveChangesAsync();
                    StudentMasterDTO studentResult = result.ToMap<StudentMasterDTO>();

                    return studentResult;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }



        //private bool StudentMasterExists(int id)
        //{
        //    return db.StudentMasters.Count(e => e.Id == id) > 0;
        //}
    }
}