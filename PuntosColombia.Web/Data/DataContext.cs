using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuntosColombia.Web.Data.Entities;

namespace PuntosColombia.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<MissingNumber> MissingNumbers { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
