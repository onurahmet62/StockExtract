namespace StockExtract.Web.Models
{
    public class StocExtractModel
    {
        public int SiraNo { get; set; }
        public string IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public string Tarih { get; set; }
        public int GirisMiktar { get; set; }
        public int CikisMiktar { get; set; }
        public int Stok { get; set; }
    }
}
