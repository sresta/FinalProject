using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Models
{
    public class OrphanageDbContext:DbContext
    {
        public OrphanageDbContext():base("connString")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Orphan> Orphans { get; set; }
        public DbSet<OrphanBackground> OrphanBackgrounds { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<SponsorDetail> SponsorDetails { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }

    }
}