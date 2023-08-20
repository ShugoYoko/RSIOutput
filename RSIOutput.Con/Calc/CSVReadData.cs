using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("RSIOutput.Tests")]

namespace RSIOutput.Con.Calc
{
    internal class CSVReadData
    {
        public Dictionary<DateTime, int>? CsvRead { get; set; }
        private bool isFile = false;
        private bool canChange = false;
        public CSVReadData(string? path, string? header, string? strDateCol, string? strPriceCol)
        {

            isFile = File.Exists(path);

            //指定された行、列が数字に変換可能か
            int startRow = 0, dateCol = 0, priceCol = 0;
            if (int.TryParse(header, out startRow) && int.TryParse(strDateCol, out dateCol)
                && int.TryParse(strPriceCol, out priceCol))
            {
                canChange = true;
            }

            if (isFile && canChange)
            {
                StreamReader sr = new StreamReader(@path);
                CsvRead = new Dictionary<DateTime, int>();

                int start = 0;

                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();

                    //開始行までskip
                    if (start < startRow - 1)
                    {
                        start++;
                        continue;
                    }

                    Regex.Unescape(line);
                    string[] cols = line.Replace("\"", "").Split(",");
                    DateTime dateTime;

                    //指定行は1から始まるため1を引く
                    if (!DateTime.TryParse(cols[dateCol - 1], out dateTime))
                    {
                        CsvRead = null;
                        break;
                    }

                    int price;
                    if (!int.TryParse(cols[priceCol - 1], out price))
                    {
                        CsvRead = null;
                        break;
                    }

                    CsvRead.Add(dateTime, price);
                }
            }
            else
            {
                CsvRead = null;
            }
        }
    }
}
