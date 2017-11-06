using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroupProjectC.Models;

namespace GroupProjectC.Models.Tests
{
  [TestClass]
  public class PlayerTests : IDisposable
  {
    public PlayerTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=university_registrar_test;";
    }
    public void Dispose()
    {
      Course.ClearAll();
      Student.ClearAll();
    }
    // [TestMethod]
    // public void ClearAll_ClearsAllCoursesFromDatabase_0()
    // {
    //   List<Player> testList = new List<Player>();
    //   Player PlayerA = new Player("History of Snakes", "HST100");
    //   PlayerA.Save();
    //   Player PlayerB = new Player("History of Tacos", "HST101");
    //   PlayerB.Save();
    //   Player PlayerC = new Player("History of History", "HST102");
    //   PlayerC.Save();
    //
    //   testList.Add(PlayerA);
    //   testList.Add(PlayerB);
    //   testList.Add(PlayerC);
    //
    //   Player.ClearAll();
    //   List<Player> resultList = Player.GetAll();
    //
    //   Assert.AreEqual(0,resultList.Count);
    // }
    // [TestMethod]
    // public void Save_SavePlayer_()
    // {
    // Player testPlayer = new Player("test-Playername", "test-Playernumber");
    // testPlayer.Save();
    // Assert.AreEqual(true,Player.GetAll().Count==1);
    // }
    //
    // [TestMethod]
    // public void Find_FindsPlayerInDatabase_Player()
    // {
    //   Player testPlayer = new Player("History", "HIST101");
    //   testPlayer.Save();
    //
    //   Player foundPlayer = Player.Find(1);
    //   Assert.AreEqual(testPlayer, foundPlayer);
    // }
    //
    // [TestMethod]
    // public void Update_UpdatePlayerInDatabase_Player()
    // {
    //   Player testPlayer = new Player("History", "HIST101");
    //   testPlayer.Save();
    //
    //   string newPlayerName = "Math";
    //   string newPlayerNumber = "MATH101";
    //
    //   Player newPlayer = new Player(newPlayerName, newPlayerNumber);
    //   testPlayer.Update(newPlayerName, newPlayerNumber);
    //
    //   Assert.AreEqual(testPlayer.PlayerName, newPlayer.PlayerName);
    //   Assert.AreEqual(testPlayer.PlayerNumber, newPlayer.PlayerNumber);
    // }
    //
    // [TestMethod]
    // public void GetClassRoster_FindStudentsTakingPlayer()
    // {
    //   Player PlayerA = new Player("History of Snakes", "HST100");
    //   PlayerA.Save();
    //   Player PlayerB = new Player("History of Tacos", "HST101");
    //   PlayerB.Save();
    //   Player PlayerC = new Player("History of History", "HST102");
    //   PlayerC.Save();
    //   Student studentA = new Student("Alex","test");
    //   studentA.Save();
    //   studentA.Register(PlayerA.Id);
    //   studentA.Register(PlayerC.Id);
    //   Student studentB = new Student("Bob","test");
    //   studentB.Save();
    //   studentB.Register(PlayerA.Id);
    //   studentB.Register(PlayerB.Id);
    //   Student studentC = new Student("Charlie","test");
    //   studentC.Save();
    //
    //   foreach (Player  c in Player.GetAll())
    //   {
    //     foreach (Student s in c.GetRoster())
    //     {Console.WriteLine(s.Name +" : "+ c.PlayerName);}
    //   }
    //   Assert.AreEqual(studentA.IsRegistered(),studentB.IsRegistered());
    //   Assert.AreEqual(false,studentC.IsRegistered());
    //   Assert.AreEqual(2,PlayerA.GetRoster().Count);
    // }
    //

  }
}
