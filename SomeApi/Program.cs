using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Npgsql;

namespace SomeApi
{
  public static class Program
  {
    public static void Main(string[] args) {
      var connString = "Host=localhost;Username=peter;Database=peter";

      using (var conn = new NpgsqlConnection(connString)) {
        conn.Open();

        using (var cmd = new NpgsqlCommand("SELECT now()", conn)) {
          // cmd.Parameters.AddWithValue("p", "Hello world");
          cmd.ExecuteNonQuery();
        }
      }

      CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
             .UseStartup<Startup>();
  }
}