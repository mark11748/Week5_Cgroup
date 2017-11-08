using System;
using System.Collections.Generic;

namespace GroupProjectC.Models
{
  public class Interface
  {
    public Locale room {get; set;}
    public List<List<Cell>> cells {get; set;}
    public int playerX {get; set;}
    public int playerY {get; set;}
  }
}
