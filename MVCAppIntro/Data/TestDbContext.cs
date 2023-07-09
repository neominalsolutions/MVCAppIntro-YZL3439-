

using Microsoft.EntityFrameworkCore;
using MVCAppIntro.Data.Config;

namespace MVCAppIntro.Data
{
  public class TestDbContext:DbContext
  {

    //  Student sınıfının veri tabanı tarafında bir tablo olması için DbSet propertysi kullanıyoruz
    // Students ismi tabloya bağlanmak için kullanacağımız isim.
    public DbSet<Student> Students { get; set; } // Öğrenciler
    public DbSet<Teacher> Teachers { get; set; } // Öğremenler

    public DbSet<Course> Courses { get; set; } // Kurslar
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Yöntem FLUENT API
      modelBuilder.Entity<User>().HasIndex(x => x.UserName).IsUnique(); // unique olsun
      modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique(); // email unque olsun
      modelBuilder.Entity<User>().Property(x => x.UserName).HasMaxLength(12); // En fazla 12 karakter olabilir. 
      modelBuilder.Entity<User>().HasKey(x => x.Id); // PK alanı belirttik.
      // db de tablo ismini değiştiridik.
      //modelBuilder.Entity<User>().ToTable("Kullanıcılar");
      // sütün ismini db de değiştiridik.
      //modelBuilder.Entity<User>().Property(x => x.UserName).HasColumnName("KullanıcıAdı");

      // Kodu burada yazmak yerine klasörden getirme yöntemide var. Büyük projelerde burasının okunması zorlaştığı için bu durumda buradaki kodlara class'lara geçiririz.

      // config dosyasından oku.
      modelBuilder.ApplyConfiguration(new RoleConfig());



      base.OnModelCreating(modelBuilder);
    }

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
