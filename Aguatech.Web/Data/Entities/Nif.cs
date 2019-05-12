namespace Aguatech.Web.Data.Entities
{
    using System.Collections.Generic;

    public class Contacts
    {
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string fax { get; set; }
    }

    public class Structure
    {
        public string nature { get; set; }
        public string capital { get; set; }
        public string capital_currency { get; set; }
    }

    public class Geo
    {
        public string region { get; set; }
        public string county { get; set; }
        public string parish { get; set; }
    }

    public class Place
    {
        public string address { get; set; }
        public string pc4 { get; set; }
        public string pc3 { get; set; }
        public string city { get; set; }
    }

    public class Nif
    {
        public int nif { get; set; }
        public string seo_url { get; set; }
        public string title { get; set; }
        public string address { get; set; }
        public string pc4 { get; set; }
        public string pc3 { get; set; }
        public string city { get; set; }
        public string activity { get; set; }
        public string status { get; set; }
        public string cae { get; set; }
        public Contacts contacts { get; set; }
        public Structure structure { get; set; }
        public Geo geo { get; set; }
        public Place place { get; set; }
        public string racius { get; set; }
        public string alias { get; set; }
        public string portugalio { get; set; }
    }

    public class Records
    {
        public Nif nif { get; set; }
    }

    public class Credits
    {
        public string used { get; set; }
        public List<object> left { get; set; }
    }

    public class RootObject
    {
        public string result { get; set; }
        public Records records { get; set; }
        public bool nif_validation { get; set; }
        public bool is_nif { get; set; }
        public Credits credits { get; set; }
    }
}
