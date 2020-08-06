using Microsoft.EntityFrameworkCore;
using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
    public class SqlRequestTypeRepo : IRequestTypeRepo
    {
        private readonly SRMContext _context;
        public SqlRequestTypeRepo(SRMContext context)
        {
            _context = context;
        }
        public void CreateRequestType(RequestType requestType)
        {
            if (requestType == null)
            {
                throw new ArgumentNullException(nameof(requestType));
            }
            _context.RequestType.Add(requestType);
        }

        public void DeleteRequestType(RequestType requestType)
        {
            if (requestType == null)
            {
                throw new ArgumentNullException(nameof(requestType));
            }
            _context.RequestType.Remove(requestType);
        }

        public IEnumerable<RequestType> GetRequestType()
        {
            return _context.RequestType.ToList();
        }

        public RequestType GetRequestTypeById(int Id)
        {
          
            var requestType = _context.RequestType.Include(req => req.Request).Where(reqt => reqt.Id == Id).FirstOrDefault();
            return requestType;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateRequestType(RequestType requestType)
        {
           
        }
    }
}
