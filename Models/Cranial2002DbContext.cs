using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
	//DBContext class to facilitate interactions with the DB
	public class Cranial2002DbContext : DbContext
	{
		public Cranial2002DbContext(DbContextOptions<Cranial2002DbContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(Helpers.GetRDSConnectionString());
		public DbSet<Cranial2002> Cranial2002 { get; set; }
	}
}