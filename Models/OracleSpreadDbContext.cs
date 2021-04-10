using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class OracleSpreadDbContext : DbContext
	{
		public OracleSpreadDbContext(DbContextOptions<OracleSpreadDbContext> options) : base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(Helpers.GetRDSConnectionString());
		public DbSet<OracleSpread> OracleSpread { get; set; }
	}
}