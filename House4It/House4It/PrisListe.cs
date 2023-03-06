using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;


namespace House4It
{

    [Serializable]
    public class PrisListe
    {

        [CsvColumn(Name = "Item", FieldIndex = 1)]
        public string Item { get; set; }

        [CsvColumn(Name = "article description", FieldIndex = 2)]
        public string ArticleDescription { get; set; }

        [CsvColumn(Name = "unit", FieldIndex = 3)]
        public string Unit { get; set; }

        [CsvColumn(Name = "kostpris EUR", FieldIndex = 4)]
        public string KostPrisEur { get; set; }

        [CsvColumn(Name = "price unit", FieldIndex = 5)]
        public string PriceUnit { get; set; }

        [CsvColumn(Name = "price group", FieldIndex = 6)]
        public string PriceGroup { get; set; }

        [CsvColumn(Name = "date of issuance", FieldIndex = 7, OutputFormat = "dd-MM-yyyy HH:mm")]
        public string DateOfIssuance { get; set; }

    }

    public class ResultProduct
    {
        [CsvColumn(Name = "Item", FieldIndex = 1)]
        public string varenummer { get; set; }

        [CsvColumn(Name = "article description", FieldIndex = 2)]
        public string navn { get; set; }

        [CsvColumn(Name = "kostpris i danske kroner", FieldIndex = 3)]
        public string price { get; set; }

        [CsvColumn(Name = "beregnet salgspris i danske kroner.", FieldIndex = 4)]
        public string salesPrice { get; set; }
    }
}
