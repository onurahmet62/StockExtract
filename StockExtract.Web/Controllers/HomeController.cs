using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockExtract.DataAccess.Context;
using StockExtract.DataAccess.Models;
using StockExtract.Web.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StockExtract.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;


        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate, string? productDetail)
        {
            
            int? startDateItem = startDate != null ? Convert.ToInt32(startDate?.ToOADate()) : null;
            int? endDateItem = endDate != null ?  Convert.ToInt32(endDate?.ToOADate()) : null;

            var model = GetStocExtracts(productDetail, startDateItem, endDateItem);

            return View(model);
        }


        private List<StocExtractModel> GetStocExtracts(string? productCode, int? startDate, int? endDate)
        {
            var list = new List<StocExtractModel>();

            try
            {
                string connectionString = @"Server=MSI\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetStockData", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@MalKodu", SqlDbType.VarChar).Value = productCode;
                        cmd.Parameters.Add("@BaslangicTarihi", SqlDbType.Int).Value = startDate;
                        cmd.Parameters.Add("@BitisTarihi", SqlDbType.Int).Value = endDate;

                        connection.Open();

                        SqlDataReader sdr = cmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            list.Add(new StocExtractModel
                            {

                                SiraNo = Convert.ToInt32(sdr["SiraNo"]),
                                IslemTur = sdr["IslemTur"].ToString(),
                                EvrakNo = sdr["EvrakNo"].ToString(),
                                Tarih = sdr["Tarih"].ToString(),
                                GirisMiktar = Convert.ToInt32(sdr["GirisMiktar"]),
                                CikisMiktar = Convert.ToInt32(sdr["CikisMiktar"]),
                                Stok = Convert.ToInt32(sdr["Stok"])
                            });

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            return list;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}