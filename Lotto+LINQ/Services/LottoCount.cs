using Lotto_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotto_LINQ.Services
{
    public class LottoCount
    {
        private LottoFileManager fileManager;
        public Dictionary<int, int> dictionaryOfCounts  = new Dictionary<int, int>();
        public Dictionary<int, double> dictonaryOfAverages = new Dictionary<int, double>();
        public int mostPopularNumber;
        public int [] leastPopularNumbers  = new int [6];
        public long sumOfAllDraws;
        public List<LotteryDraw> results= new List<LotteryDraw>();
        

        public LottoCount()
        {
            fileManager = new LottoFileManager("dl.txt");
            results = fileManager.ToDraws();
            List<int> numbers = results.SelectMany(t => t.DrawnNumbers).ToList();
            countNumbers();
            mostPopularNumber = dictionaryOfCounts.OrderByDescending(t => t.Value).First().Key;

            for (int i=0; i<6; i++)
            {
                leastPopularNumbers[i] = dictionaryOfCounts.OrderBy(t => t.Value).Skip(i).First().Key;
            }

            sumOfAllDraws = numbers.Sum();

            dictonaryOfAverages = results.ToDictionary(t => t.Index, t => Math.Round(t.DrawnNumbers.Average(), 2)); 
        }

        public void countNumbers()
        {
            List<int> numbers = results.SelectMany(t => t.DrawnNumbers).ToList();
            for (int i = 1; i < 50; i++)
            {
                dictionaryOfCounts.Add(i, numbers.Count(t => t.Equals(i)));
            }
        }

        
    }
}