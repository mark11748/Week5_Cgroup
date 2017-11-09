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

        return View();
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

      [HttpPost("/newgame")]
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
        Cell cell5 = new Cell("Cell 1,1", "test description", //exit to room 2
                              new Border(1),new Border(1),
                              new Border(1),new Border(1) );
        Cell cell6 = new Cell("Cell 1,2", "test description",
                              new Border(1),new Border(0),
                              new Border(1),new Border(1) );
        Cell cell7 = new Cell("Cell 2,0", "test description",
                              new Border(0),new Border(1),
                              new Border(0),new Border(1) );
        Cell cell8 = new Cell("Cell 2,1", "test description", //exit to room 1
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
        List<Locale> floor1 = new List<Locale>();
        GAMEBOARD.AddMapToWorld(floor1); //Add a floor
        Lobby.AddRoomToArea(0);     //Add a room(Lobby)     to the floor ; no args because 1st area is default
        StoreRoom.AddRoomToArea(0); //Add a room(StoreRoom) to the floor ; no args because 1st area is default

        Player user = new Player(Request.Form["player-name"]);
        user.SetPosX(0);
        user.SetPosY(1);

        return View("Game",user);
      }

      [HttpPost("/mv_up")]
      public ActionResult MoveN()
      {
       Player user = new Player(GAMEBOARD.playerName);
       user.MoveN();
       return View("Game",user);
      }
      [HttpPost("/mv_dn")]
      public ActionResult MoveS()
      {
       Player user = new Player(GAMEBOARD.playerName);
       user.MoveS();
       return View("Game",user);
      }
      [HttpPost("/mv_rt")]
      public ActionResult MoveE()
      {
       Player user = new Player(GAMEBOARD.playerName);
       user.MoveE();
       return View("Game",user);
      }
      [HttpPost("/mv_lt")]
      public ActionResult MoveW()
      {
       Player user = new Player(GAMEBOARD.playerName);
       user.MoveW();
       return View("Game",user);
      }


      [HttpGet("/save")]
      public ActionResult Save()
      {
        return View();
      }
    }
}
