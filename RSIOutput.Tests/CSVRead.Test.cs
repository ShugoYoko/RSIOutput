using RSIOutput.Con.Calc;

namespace RSIOutput.Tests
{

    public class CSVReadTest
    {
        [Fact]
        public void CSVRead()
        {
            var path = @"C:\Users\yokot\Desktop\C_Sharp_app\RSIOutput\Testdata\04314233.csv";
            var startRow = "9";
            var dateCol = "1";
            var priceCol = "2";

            var testTime = new DateTime(2023, 8, 17);

            var data = new CSVReadData(path, startRow, dateCol, priceCol);
            Assert.Equal(12089, data.CsvRead[testTime]);
        }
    }
}