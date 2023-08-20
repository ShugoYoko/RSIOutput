using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("RSIOutput.Tests")]

namespace RSIOutput.Con.Calc
{
    internal class RSICalcData
    {
        private Dictionary<DateTime, int> _baseData;

        private List<RSIData> _rsiList;

        public RSICalcData(Dictionary<DateTime, int>? _readData)
        {
            this._baseData = _readData;
            this._rsiList = new List<RSIData>();
            AddDiff();
        }

        private void AddDiff()
        {
            var orderBaseData = _baseData.OrderBy(x => x.Key.Date);
            int prePrice = 0;
            foreach (var item in orderBaseData)
            {
                if (prePrice == 0)
                {
                    _rsiList.Add(new RSIData { Date = item.Key, Price = item.Value, Diff = 0 });

                }
                else
                {
                    _rsiList.Add(new RSIData { Date = item.Key, Price = item.Value, Diff = item.Value - prePrice });

                }
                prePrice = item.Value;

            }

        }

        public IEnumerable<RSIData> ReturnRSIDate()
        {

            foreach (var data in _rsiList)
            {
                var before14Date = data.Date.AddDays(-14);
                var during14 = _rsiList.Where(x => before14Date <= x.Date && x.Date <= data.Date);
                var plusDiff = during14.Where(x => x.Diff > 0).Sum(x => x.Diff);
                var minusDiff = (-1) * during14.Where(x => x.Diff < 0).Sum(x => x.Diff);

                if (plusDiff == 0 && minusDiff == 0)
                {
                    data.RSI = 0;
                }
                else
                {
                    data.RSI = plusDiff / (plusDiff + minusDiff) * 100;
                }
                yield return data;
            }
        }
    }
}
