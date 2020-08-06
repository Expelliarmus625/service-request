using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
   public interface IRequestTypeRepo
    {
        bool SaveChanges();
        IEnumerable<RequestType> GetRequestType();
        RequestType GetRequestTypeById(int Id);

        void CreateRequestType(RequestType requestType);

        void UpdateRequestType(RequestType requestType);

        void DeleteRequestType(RequestType requestType);
    }
}
