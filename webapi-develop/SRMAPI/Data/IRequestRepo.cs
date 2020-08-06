using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
   public interface IRequestRepo
    {
        bool SaveChanges();
        IEnumerable<Request> GetRequest();
        Request GetRequestById(int Id);

        void CreateRequest(Request request);

        void UpdateRequest(Request request);

        void DeleteRequest(Request request);
    }
}
