using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppCar.Data
{
    public class BlazorAppCarContext : DbContext
    {
        public BlazorAppCarContext (DbContextOptions<BlazorAppCarContext> options)
            : base(options)
        {
        }

        public DbSet<Engine> Engine { get; set; } = default!;
        public DbSet<Car> Car { get; set; } = default!;
    }
}
