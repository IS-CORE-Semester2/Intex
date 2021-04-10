using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class BioSamplesDbContext : DbContext
	{
		public BioSamplesDbContext(DbContextOptions<BioSamplesDbContext> options) : base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(Helpers.GetRDSConnectionString());
		public DbSet<BioSamples> BioSamples { get; set; }
	}
}