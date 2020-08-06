using SRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRMAPI.Data
{
   public interface IStatusRepo
    {
        bool SaveChanges();
        IEnumerable<Status> GetStatus();
        Status GetStatusById(int Id);

        void CreateStatus(Status status);

        void UpdateStatus(Status status);

        void DeleteStatus(Status status);
    }
}
