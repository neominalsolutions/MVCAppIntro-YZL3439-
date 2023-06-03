

using Microsoft.EntityFrameworkCore;

namespace MVCAppIntro.Data
{
  public class TestDbContext:DbContext
  {

    //  Student sınıfının veri tabanı tarafında bir tablo olması için DbSet propertysi kullanıyoruz
    // Students ismi tabloya bağlanmak için kullanacağımız isim.
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // bu method içerisinde database bağlantısı sağlayacağız
      // Server=(localDB)\\MyLocalDb;Database=TestDb;uid=sa;pwd=1234;MultipleActiveResultSet=true;
      // yukarıda Sql Authentication ile user üzerinden bağlantı var
      // Windows Authentication "Server=(localDB)\\MyLocalDb;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSet=true;"
      // yukarıdaki string ifadeye ConnectionString adını veriyoruz.
      optionsBuilder.UseSqlServer("Server=(localDB)\\MyLocalDb;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=True;");
      base.OnConfiguring(optionsBuilder);
    }
  }
}
