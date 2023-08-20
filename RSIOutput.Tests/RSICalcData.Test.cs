using RSIOutput.Con.Calc;

namespace RSIOutput.Tests
{
    public class RSICalcDataTest
    {
        [Fact]
        public void RSICalc()
        {
            var dayData = new Dictionary<DateTime, int>();
            dayData.Add(new DateTime(2023, 1, 1), 1000);
            dayData.Add(new DateTime(2023, 1, 2), 1020);
            dayData.Add(new DateTime(2023, 1, 3), 1010);
            dayData.Add(new DateTime(2023, 1, 4), 1030);
            dayData.Add(new DateTime(2023, 1, 5), 1040);
            dayData.Add(new DateTime(2023, 1, 6), 1050);
            dayData.Add(new DateTime(2023, 1, 7), 1080);
            dayData.Add(new DateTime(2023, 1, 8), 1070);
            dayData.Add(new DateTime(2023, 1, 9), 1050);
            dayData.Add(new DateTime(2023, 1, 10), 1090);
            dayData.Add(new DateTime(2023, 1, 11), 1100);
            dayData.Add(new DateTime(2023, 1, 12), 1120);
            dayData.Add(new DateTime(2023, 1, 13), 1110);
            dayData.Add(new DateTime(2023, 1, 14), 1120);
            dayData.Add(new DateTime(2023, 1, 15), 1100);

            var datas = new RSICalcData(dayData);
            foreach (var data in datas.ReturnRSIDate())
            {
                if (data.Date == new DateTime(2023, 1, 15))
                {
                    Assert.Equal("2023/01/15,1100,-20.00,70.83", data.ToString());
                }
            }
        }
    }
}
