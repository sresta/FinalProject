using OrphanageFinalEntity.Controllers;
using OrphanageFinalEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Repository
{
    public interface ISupervisorRepository
    {
        List<Models.Supervisor> GetAll();
    }
    public class SupervisorRepository : DatabaseController,ISupervisorRepository
    {
        public List<Models.Supervisor> GetAll()
        {
            return db.Supervisors.ToList();
        }
    }
}