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

      [HttpGet("/game")]
      public ActionResult Game()
      {
        return View();
      }

      [HttpGet("/new")]
      public ActionResult New()
      {
        return View();
      }

      [HttpPost("/game")]
      public ActionResult Game()
      {
        Cell cell1 = new Cell("CellA", "test description",
                              new Border(1),new Border(1),
                              new Border(1),new Border(1) )

        Cell cell2 = cell1.CopyOf();
        Cell cell3 = cell1.CopyOf();
        Cell cell4 = cell1.CopyOf();
        Cell cell5 = cell1.CopyOf();

        List<List<Cell>> FirstRoom = new List<List<Cell>> {{cell2,cell3},
                                                          {cell4,cell5}};
        Locale lobby = new Locale("Lobby"); //declare a room named "Lobby"
        lobby.SetCells(FirstRoom); //define the room; set its cell grid

        GAMEBOARD.AddMapToWorld( new List<List<Locale>>() ) //Add a floor
        lobby.AddToWorld(); //Add a room to the floor

        Locale
        return View();
      }

      [HttpGet("/save")]
      public ActionResult Save()
      {
        return View();
      }
    }
}
