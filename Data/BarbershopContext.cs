using Microsoft.EntityFrameworkCore;
using BarbershopApi.Models;
using System.Collections.Generic;

namespace BarbershopApi.Data;

public class BarbershopContext : DbContext
{
    public BarbershopContext(DbContextOptions<BarbershopContext> options)
    : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}
