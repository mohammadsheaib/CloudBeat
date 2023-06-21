using CloudBeat.Entities.Device;
using CloudBeat.Entities;
using CloudBeat.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CloudBeat.Data
{
    public class CloudBeatDBContextClass : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public CloudBeatDBContextClass(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=CloudBeat;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasKey(p => p.Id); // Specify the primary key for the Person entity

            modelBuilder.Entity<Event>()
                .HasKey(e => e.Id); // Specify the primary key for the Event entity

            //    modelBuilder.Entity<Event>()
            //    .HasOne<Patient>() // Specify the one-to-many relationship
            //        .WithMany() // Since the Person entity doesn't have Events property, omit the parameter
            //        .HasForeignKey(e => e.PatientId).HasForeignKey(e=>e.DeviceId); // Specify the foreign key
            //
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Device> Devices { get; set; }
    }
}