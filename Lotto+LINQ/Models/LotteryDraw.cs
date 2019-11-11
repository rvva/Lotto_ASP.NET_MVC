using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotto_LINQ.Models
{
        public class LotteryDraw
        {
            public int Index { get; set; }

            public DateTime Date { get; set; }

            public List<int> DrawnNumbers { get; set; } = new List<int>();
        }
}
