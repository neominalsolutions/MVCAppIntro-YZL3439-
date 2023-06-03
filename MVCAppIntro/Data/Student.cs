namespace MVCAppIntro.Data
{
  // DB Student Tablosu açılsın ve Id,Name,SurName,PhoneNumber sutunları olsun.
  // Ad,Soyad,Telefon,SicilNo,Id
  // Add-Migration Celal
  // Update-Database
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }

    public string PhoneNumber { get; set; }

  }
}
