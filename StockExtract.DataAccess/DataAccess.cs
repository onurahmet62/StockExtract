using Microsoft.Extensions.Logging;
using StockExtract.DataAccess.Context;
using StockExtract.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExtract.DataAccess
{
    public class DataAccess
    {

        private readonly AppDbContext _context;
        public DataAccess(AppDbContext context)
        {
            _context = context;
        }


        //public static List<Sti> GetStockExtract()
        //{

        //    //var stis = _context.Stis.ToList();

        //    //ViewBag.Stock = _context.Stis.FromSql($"GetStockData {MalKodu},{BaslangicTarihi}, {BitisTarihi}").ToList();


        //    return GetStis();
        //}

        //private List<Sti> GetStis()
        //{
        //    return _context.Stis.ToList();
        //}
            
    }
}
