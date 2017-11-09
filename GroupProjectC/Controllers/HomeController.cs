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
      public ActionResult Game_New()
      {
        Cell cell1 = new Cell("Cell 0,0", "test description",
                              new Border(0),new Border(1),
                              new Border(1),new Border(0) );
        Cell cell2 = new Cell("Cell 0,1", "test description", //start cell
                              new Border(1),new Border(1),
                              new Border(1),new Border(0) );
        Cell cell3 = new Cell("Cell 0,2", "test description",
                              new Border(1),new Border(0),
                              new Border(1),new Border(0) );
        Cell cell4 = new Cell("Cell 1,0", "test description",
                              new Border(0),new Border(1),
                              new Border(1),new Border(1) );
        Cell cell5 = new Cell("Cell 1,1", "test description",
                              new Border(1),new Border(1),
                              new Border(1),new Border(1) );
        Cell cell6 = new Cell("Cell 1,2", "test description",
                              new Border(1),new Border(0),
                              new Border(1),new Border(1) );
        Cell cell7 = new Cell("Cell 2,0", "test description",
                              new Border(0),new Border(1),
                              new Border(0),new Border(1) );
        Cell cell8 = new Cell("Cell 2,1", "test description",
                              new Border(1),new Border(1),
                              new Border(0),new Border(1) );
        Cell cell9 = new Cell("Cell 2,2", "test description", //elevator
                              new Border(1),new Border(0),
                              new Border(0),new Border(1) );


        List<List<Cell>> FirstRoom1F  = new List<List<Cell>> {new List<Cell> {cell1,cell2,cell3},
                                                              new List<Cell> {cell4,cell5,cell6}};
        List<List<Cell>> SecondRoom1F = new List<List<Cell>> {new List<Cell> {cell7,cell8,cell9}};

        Locale Lobby = new Locale("Lobby"); //declare a room named "Lobby"
        Lobby.SetCells(FirstRoom1F); //define the room; set its cell grid
        Locale StoreRoom = new Locale("Store_Room");
        StoreRoom.SetCells(SecondRoom1F);

        GAMEBOARD.AddMapToWorld( new List<Locale>() ); //Add a floor
        Lobby.AddRoomToArea();     //Add a room(Lobby)     to the floor ; no args because 1st area is default
        StoreRoom.AddRoomToArea(); //Add a room(StoreRoom) to the floor ; no args because 1st area is default


        return View();
      }

      [HttpPost("/mv_up")]
      public ActionResult MoveN(){return View();}
      [HttpPost("/mv_dn")]
      public ActionResult MoveS(){return View();}
      [HttpPost("/mv_rt")]
      public ActionResult MoveE(){return View();}
      [HttpPost("/mv_lt")]
      public ActionResult MoveW(){return View();}


      [HttpGet("/save")]
      public ActionResult Save()
      {
        return View();
      }
    }
}
