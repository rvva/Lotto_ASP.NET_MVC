using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lotto_LINQ.Services;

namespace Lotto_LINQ.Controllers
{
    public class LottoController : Controller
    {
        // GET: Lotto
        public ActionResult Lotto(string sortOrder)
        {
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            LottoFileManager lottoFileManager = new LottoFileManager("dl.txt");

            if (sortOrder == "Date")
                return View(lottoFileManager.ToDraws());
            else
                return View(lottoFileManager.ToDraws().OrderByDescending(t => t.Date).ToList());
        }

        // GET: Lotto
        public ActionResult LottoCount()
        {
            LottoCount lottoCount = new LottoCount();
            return View(lottoCount);
        }
    }
}