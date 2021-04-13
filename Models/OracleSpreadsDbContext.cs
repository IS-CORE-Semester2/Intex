using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
	//DBContext class to facilitate interactions with the DB
	public class OracleSpreadsDbContext : DbContext
	{
		public OracleSpreadsDbContext(DbContextOptions<OracleSpreadsDbContext> options) : base(options)
		{ }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(Helpers.GetRDSConnectionString());
		public DbSet<OracleSpreads> OracleSpread { get; set; }
	}
}