using RSIOutput.Con.Calc;

namespace RSIOutput.Con
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("csv Path:");
            var path=Console.ReadLine();
            Console.Write("start line(from 1):");
            var startRow=Console.ReadLine();
            Console.Write("date column(from 1):");
            var dateCol=Console.ReadLine();
            Console.Write("price column(from 1):");
            var priceCol=Console.ReadLine();

            var readDatas = new CSVReadData(path, startRow, dateCol, priceCol);
            var rsiDatas = new RSICalcData(readDatas.CsvRead);
            foreach(var rsi in rsiDatas.ReturnRSIDate())
            {
                Console.WriteLine(rsi.ToString());
            }


        }
    }
    
}

