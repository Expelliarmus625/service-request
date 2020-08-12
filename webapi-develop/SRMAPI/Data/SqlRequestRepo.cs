using Microsoft.EntityFrameworkCore;
using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
    public class SqlRequestRepo : IRequestRepo
    {
        private readonly SRMContext _context;
        public SqlRequestRepo(SRMContext context)
        {
            _context = context;
        }
        public void CreateRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _context.Request.Add(request);
             var email1 = context.Employees.FirstOrDefault(e => e.Id == request.CreatedEmpId).EmailId;
            var AdminEmail = context.Employees.FirstOrDefault(e =>  e.RoleId == (context.Roles.FirstOrDefault(r => r.Role1.Equals("Admin")).Id)).EmailId;
            var fromAddress = new MailAddress("anjalikhadake888@gmail.com", "My Name");
            var toAddress = new MailAddress((email1).ToString(),  (AdminEmail).ToString());
            const string fromPassword = "khadake27101998";
            const string subject = "Service Request";
            string body = "Request Created!" +
                            "\nRequest Id: " + request.Id +
                                "\nRequest Created by: " + context.Employees.FirstOrDefault(e => e.Id == request.CreatedEmpId).FirstName +
                                "\nDepartment: " + context.Department.FirstOrDefault(d => d.Id == request.DepartmentId).Name +
                                 "\nCategory: " + context.Category.FirstOrDefault(c => c.Id == request.CategoryId).Name +
                                  "\nSubcategory: " + context.Category.FirstOrDefault(s => s.Id == request.SubCategoryId).Name +
                                  "\nTitle :" + request.Title +
                                  "\nSummary :" + request.Summary;

           

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {

                smtp.Send(message);
            }

        }

        public void DeleteRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _context.Request.Remove(request);
        }

        public IEnumerable<Request> GetRequest()
        {
            return _context.Request
                .Include(stat => stat.Status)
                .Include(dept => dept.Department)
                .Include(cat => cat.Category)
                .Include(cat => cat.SubCategory)
                .ToList();

        }


        public Request GetRequestById(int Id)
        {

            var request = _context.Request
            .Include(stat => stat.Status)
             .Include(dept => dept.Department)
           .Include(cat => cat.Category)
                                     .Where(req => req.Id == Id).FirstOrDefault();
            return request;
        }

        public IEnumerable<Request> GetRequestPreview()
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRequest(Request request)
        {

        }
    }
}
