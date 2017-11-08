using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using GroupProjectC.Models;

namespace GroupProjectC.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        Locale room = new Locale("lobby");
        List<List<Cell>> cells = new List<List<Cell>>()
        {
          new List<Cell>(){new Cell("A1"),new Cell("A2")},
          new List<Cell>(){new Cell("B1"),new Cell("B2")}
        };

        int x=0;
        int y=0;
        Interface gameDisplay = new Interface()
        {
          room=room,
          cells=cells,
          playerX=x,
          playerY=y
        };
        return View("Interface", gameDisplay);
      }
    }
}
