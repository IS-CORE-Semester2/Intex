using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class ExhumationDbContext : DbContext
	{
		public ExhumationDbContext(DbContextOptions<ExhumationDbContext> options) : base(options)
		{ }
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(Helpers.GetRDSConnectionString());
		public DbSet<Exhumation> Exhumations { get; set; }
	}
}