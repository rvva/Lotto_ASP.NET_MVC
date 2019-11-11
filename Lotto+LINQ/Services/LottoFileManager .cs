using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Hosting;
using Lotto_LINQ.Models;


namespace Lotto_LINQ.Services
{
    public class LottoFileManager 
    {
        public FileStream file { get; set; }
        public StreamReader reader { get; set; }
        public List<LotteryDraw> losowania { get; set; } = new List<LotteryDraw>();

        public LottoFileManager(string fileName)
        {
            try
            {
                file = new FileStream(HostingEnvironment.
                    MapPath(@"~\Content\" + fileName), FileMode.Open);
            }
            catch (FileNotFoundException ex)
            {
                file.Close();
                Debug.WriteLine(ex.ToString());
            }

            reader = new StreamReader(file);
        }

        public List<LotteryDraw> ToDraws()
        {
            string[] rows = new string[3];
            LotteryDraw losowanie;
            while (!reader.EndOfStream)
            {
                List<int> liczby = new List<int>();

                rows = reader.ReadLine().Split(' ');
                var liczbyTemp = rows[2].Split(',');

                foreach (var item in liczbyTemp)
                {
                    liczby.Add(int.Parse(item));
                }

                string[] daty = rows[1].Split('.');
                string poprawnaData = daty[2] + "-" + daty[1] + "-" + daty[0];

                losowanie = new LotteryDraw
                {
                    Index = int.Parse(rows[0].Trim('.')),
                    DrawnNumbers = liczby,
                    Date = DateTime.Parse(poprawnaData)
            };

                losowania.Add(losowanie);
            }

            file.Close();
            reader.Close();

            return losowania;
        }
    }
}