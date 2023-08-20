using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("RSIOutput.Tests")]

namespace RSIOutput.Con.Calc
{
    internal class RSIData
    {
        public DateTime Date { get; set; }
        public int Price { get; set; }

        public double Diff { get; set; }

        public double RSI { get; set; } = 0;

        public override string ToString()
        {
            var date = Date.ToString("yyyy/MM/dd");
            return $"{date},{Price},{Diff:F2},{RSI:F2}";
        }
    }
}
