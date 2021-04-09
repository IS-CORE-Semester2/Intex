﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex.Models
{
    public class BurialsDbContext: DbContext
	{
		public BurialsDbContext(DbContextOptions<BurialsDbContext> options) : base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
	=> options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Intex-C4A61F9C-725E-4DA0-8587-C5B9B4225680;Trusted_Connection=True;MultipleActiveResultSets=true");
		public DbSet<Burials> Burials { get; set; }
	}
}