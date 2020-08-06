using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRMAPI.Data;
using SRMAPI.Models;

namespace SRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestTypesController : ControllerBase
    {
       
        private readonly IRequestTypeRepo _repository;
        private readonly object requestTypeItems;

      
        public RequestTypesController(IRequestTypeRepo repository)
        {
            _repository = repository;

        }

        // GET: api/RequestTypes
        [HttpGet]
        public ActionResult<IEnumerable<RequestType>> GetRequestType()
        {
           
            var requestTypeItems = _repository.GetRequestType();
            return Ok(requestTypeItems);
        }

        // GET: api/RequestTypes/5
        [HttpGet("{id}")]
        public ActionResult<RequestType> GetRequestTypeById(int Id)
        {
           
            var requestTypeItem = _repository.GetRequestTypeById(Id);


            if (requestTypeItem != null)
            {

                return Ok(requestTypeItem);
            }
            return NotFound();
        }

        // PUT: api/RequestTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateRequestType(int Id, RequestType requestType)
        {

            var updateRequestTypeFromRepo = _repository.GetRequestTypeById(Id);
            if (updateRequestTypeFromRepo == null)
            {
                return NotFound();
            }
            _repository.UpdateRequestType(updateRequestTypeFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // POST: api/RequestTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<RequestType> CreateRequestType(RequestType createRequestType)
        {

            _repository.CreateRequestType(createRequestType);
            _repository.SaveChanges();
            return createRequestType;
        }

        // DELETE: api/RequestTypes/5
        [HttpDelete("{id}")]
        public ActionResult<RequestType> DeleteRequestType(int Id)
        {
           
            var requestTypeFromRepo = _repository.GetRequestTypeById(Id);
            if (requestTypeFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteRequestType(requestTypeFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

   
    }
}
