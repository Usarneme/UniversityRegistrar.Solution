using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace University.Models
{
  public class UniversityContextFactory : IDesignTimeDbContextFactory<UniversityContext>
  {

    UniversityContext IDesignTimeDbContextFactory<UniversityContext>.CreateDbContext(string[] args)
    {
      IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var builder = new DbContextOptionsBuilder<UniversityContext>();
        builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["connectionStrings:DefaultConnection"]));
        return new UniversityContext(builder.Options);
    }
  }
}
