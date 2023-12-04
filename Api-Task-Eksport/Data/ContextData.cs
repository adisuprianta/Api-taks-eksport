using Api_Task_Eksport.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api_Task_Eksport.Data;

public class ContextData : DbContext
{
    public ContextData(DbContextOptions<ContextData> options) : base(options)
    {
    }
    
    public DbSet<Country> Countries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Konfigurasi model atau aturan lainnya di sini jika diperlukan
        modelBuilder.Entity<Country>().HasData(
            new Country() {
                id = 1,
                kd_country = "ID",
                name = "Indonesia"
            },new Country() {
                id = 2,
                kd_country = "SG",
                name = "Singapore"
            }
        );
    }
}