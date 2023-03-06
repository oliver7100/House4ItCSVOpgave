using House4It;
using LINQtoCSV;

internal class Program
{
    static void Main(string[] args)
    {
       ReadCsvFile();

        Console.ReadKey();

    }



    private static void ReadCsvFile()
    {
        var csvFileDescription = new CsvFileDescription
        {
            FirstLineHasColumnNames = true,
            IgnoreUnknownColumns = true,
            SeparatorChar = ';',
            UseFieldIndexForReadingData = false
        };

        var csvContext = new CsvContext();
        var priceLists = csvContext.Read<PrisListe>("Prisliste.csv", csvFileDescription);


        var newResult = new List<ResultProduct>();

        foreach (var priceListe in priceLists)
        {
            var result = new ResultProduct();

            //Vi Cutter stringen, da den indeholder euro tegn.
            string Cut = priceListe.KostPrisEur.Substring(0, priceListe.KostPrisEur.Length - 2);
            //Vi replacer her da C# læser komma anderledes. 
            Cut = Cut.Replace(',', '.');
            

            //Parser string til double og regner det om til DK
            double Euro = double.Parse(Cut);
            double dk = Euro * 7.44;

            double Round = Math.Round(dk);

            result.price = Round.ToString() + " DK";

            //Replacer alle med både stort B og lille b til sort
            var Name = priceListe.ArticleDescription.Replace("Black", "sort");
            var nName = Name.Replace("black", "sort");

            result.navn = nName;

            result.varenummer = priceListe.Item;


            
            //Fortjensten udregning
            double Percentage = dk / 100;

            if (priceListe.PriceGroup == "21") 
            {
                Percentage = Percentage * 30;
                Percentage = Math.Round(Percentage);
            }
            else if (priceListe.PriceGroup == "23" || priceListe.PriceGroup == "24") 
            {
                Percentage = Percentage * 40;
                Percentage = Math.Round(Percentage);

            }
            else if (priceListe.PriceGroup == "22" || priceListe.PriceGroup == "25") 
            {
                Percentage = Percentage * 50;
                Percentage = Math.Round(Percentage);

            }

            result.salesPrice = Percentage.ToString() + " DK";


            //Tilføjer de ny koloner til en ny oprettet CSV fil.
            newResult.Add(result);
            
         

            Console.WriteLine($"{priceListe.Item} | {priceListe.ArticleDescription} |  {priceListe.KostPrisEur} ");
            Console.WriteLine(" ");
        }



        CsvFileDescription outputFileDescription = new CsvFileDescription
        {
            SeparatorChar = ';',
            FileCultureName = "da-DK"
        };

        CsvContext cc = new CsvContext();
        cc.Write(
            newResult.ToArray(),
            "./result.csv",
            outputFileDescription);
    }
}