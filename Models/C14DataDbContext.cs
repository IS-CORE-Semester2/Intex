using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
	//DBContext class to facilitate interactions with the DB
	public class C14DataDbContext : DbContext
	{
		public C14DataDbContext(DbContextOptions<C14DataDbContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlServer(Helpers.GetRDSConnectionString());
		public DbSet<C14Data> C14Data { get; set; }
	}
}