using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMAPI.Data;
using SRMAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using AutoMapper;
using SRMAPI.Models;
using System.Data.SqlClient;
using MimeKit;

namespace SRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
       
        private readonly IRequestRepo _repository;
        private readonly object requestItems;



        public RequestsController(IRequestRepo repository)
        {
            _repository = repository;

        }

        // GET: api/Requests
        [HttpGet]
        public ActionResult<IEnumerable<Request>> GetRequest()
        {
          
            var requestItems = _repository.GetRequest();
            return Ok(requestItems);
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public ActionResult<Request> GetRequestById(int Id)
        {
           
            var requestItem = _repository.GetRequestById(Id);


            if (requestItem != null)
            {

                return Ok(requestItem);
            }
            return NotFound();
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateRequest(int Id, Request request)
        {
           
            var updateRequestFromRepo = _repository.GetRequestById(Id);
            if (updateRequestFromRepo == null)
            {
                return NotFound();
            }
            _repository.UpdateRequest(updateRequestFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Request> CreateRequest(Request createRequest)
        {
          
            _repository.CreateRequest(createRequest);
            _repository.SaveChanges();


            //send mail 
            var fromAddress = new MailAddress("fromAddress", "My Name");
            var toAddress =  new MailAddress("toAdress", "Mr Test");
            const string fromPassword = "password";
            const string subject = "Request";
            const string body = "Request Created!";
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

            return createRequest;
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public ActionResult<Request> DeleteRequest(int Id)
        {
           
            var requestFromRepo = _repository.GetRequestById(Id);
            if (requestFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRequest(requestFromRepo);
            _repository.SaveChanges();
            return NoContent();

        }


    }
}
