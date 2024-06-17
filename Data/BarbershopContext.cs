using Microsoft.EntityFrameworkCore;
using BarbershopApi.Models;
using System.Collections.Generic;
using System.Threading;

namespace BarbershopApi.Data;

public class BarbershopContext : DbContext
{
    public BarbershopContext(DbContextOptions<BarbershopContext> options)
    : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Barber> Barbers { get; set; }

}
