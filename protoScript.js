  //For defining specific items <-- may be redundant since cell constructor already has items property, which is an empty array
  //item types:0=key item, 1=sensor
  function Item (name="UNSET", description="PLACEHOLDER_ITEM_DESC", owner="UNSET", posX="UNSET", posY="UNSET",hidden=false) {
    this.name        = name.toString();
    this.description = description.toString();
    this.owner       = owner; //this is either the room it is in or a reference to the player
    this.posX        = posX;
    this.posY        = posY;
    this.hidden      = hidden;
  }
  Item.prototype.setOwner = function(owner) {
    if (owner instanceof Locale || owner instanceof Player) {
      this.owner=owner;
    }
  }
  Item.prototype.setPos   = function(x=null,y=null) {
      if (Number.isInteger(x)){this.posX = x;}
      if (Number.isInteger(y)){this.posY = y;}
  }

  function KeyItem (name,description) {
    this.info  = new Item (name,description);
    this.lockID = -1;
  }
  KeyItem.prototype.setLockID = function(id=-1) {
    if (Number.isInteger(id)){this.lockID=id;}
    else {alert("Invalid key id, enter a number");}
  }
  KeyItem.prototype.setToOwner = function(owner=this.info.owner,x=this.info.posX,y=this.info.posY) {
    if (owner instanceof Locale) {
      if (this.info.owner.cells[x][y]!==undefined && this.info.owner.cells[x][y] instanceof Cell){
      this.info.owner.cells[x][y].items.push(this);
      }
    if (owner instanceof Player) {
      this.info.owner.items.push(this);
      this.info.owner.checkInventory();
    }
    if (!(owner instanceof Locale) && !(owner instanceof Player)) {alert("ERROR: THERE WAS AN ISSUE PLACING: "+this.info.name);}
    }
  }
  KeyItem.prototype.useKey = function () {
    $("div.well p#actionInfo").empty();
    if(this.lockID !== -1){
      if (this.info.owner.cell.n.isLocked===false &&
          this.info.owner.cell.s.isLocked===false &&
          this.info.owner.cell.e.isLocked===false &&
          this.info.owner.cell.w.isLocked===false) {
        $("p#actionInfo").append("You can't use that here.");
        return 0;
      }
      if (this.info.owner.cell.n.isLocked && this.info.owner.cell.n.lockID === this.lockID){
        this.info.owner.cell.n.isLocked=false;
        $("p#actionInfo").append("You unlocked the door to your north.");
      }
      if (this.info.owner.cell.s.isLocked && this.cell.s.lockID === this.lockID){
        this.info.owner.cell.s.isLocked=false;
        $("p#actionInfo").append("You unlocked the door to your south.");
      }
      if (this.info.owner.cell.e.isLocked && this.cell.e.lockID === this.lockID){
        this.info.owner.cell.e.isLocked=false;
        $("p#actionInfo").append("You unlocked the door to your east.");
      }
      if (this.info.owner.cell.w.isLocked && this.cell.w.lockID === this.lockID){
        this.info.owner.cell.w.isLocked=false;
        $("p#actionInfo").append("You unlocked the door to your west.");
      }
    }
    else {
      $("p#actionInfo").append("You can't use that here.");
      return 0;
    }
  };

  function Player (name="UNSET",loc="UNSET",posX=0,posY=0) {
    this.name  = name;
    this.loc   = loc;
    this.cell  = loc.cells[posX][posY];
    this.id    = [posX,posY];
    this.items = [];
  }
  //the setter methods for the player are as follows
  Player.prototype.setName = function(name) {
      this.name=name;
  }
  Player.prototype.setLoc = function(loc) {
      this.loc=loc;
  }
  Player.prototype.setPosX = function(posX) {
      if (Number.isInteger(posX))
        {this.id[0]=posX;}
  }
  Player.prototype.setPosY = function(posY) {
    if (Number.isInteger(posY))
      {this.id[1]=posY;}
  }

  //player item actions
  Player.prototype.checkCell = function() {
    //clear item display for current cell
    $("#pcLocation").empty();
    $("div.well p#cellItems").hide();
    $("div.well ul#cellItems").empty();
    //var playerVar = this;
    $('#cellInfo .panel-body .well span#pcLocation').text(" "+this.loc.name+" - "+this.cell.name);
    $("#pcLocation").append(this.cell.description);
    //if player's current cell has items
    if (this.cell.items.length) {
      $("div.well p#cellItems").show();
      this.cell.items.forEach(function(item){
        $("div.well ul#cellItems").append("<li class=\"item\">" + item.info.name + "</li>");
      });
        //once all items displayed-IF there are items- set listeners to act on them
        //listener: player.inventoryAdd
        $("#cellItems li.item").click(function() {
          var itemIndex=$("ul#cellItems li.item").index(this);
          player1.inventoryAdd(itemIndex);
          $("div.well#heldItems ul").append("<li class=\"item\">" + player1.items[(player1.items.length-1)].info.name + "</li>");   //add to inventory display
          $("ul#cellItems li:nth-child("+(itemIndex+1).toString()+")").remove();                                         //remove from cell display
          player1.checkCell();
          player1.checkInventory();
      })
    }
  };
  Player.prototype.checkInventory = function() {
    //clear item display for inventory div
    $("div.well ul#heldItems").empty();
    //if player's current cell has items
    if (this.items.length) {
      this.items.forEach(function(item){
        $("div.well ul#heldItems").append("<li class=\"item\">" + item.info.name + "</li>");
      });
      //once all items displayed-IF there are items- set listeners to act on them
      //listener: Player.inventoryAdd
      $("ul#heldItems li.item").click(function(){
        var itemIndex=$("#heldItems li.item").index(this);
        if (player1.items[itemIndex] instanceof KeyItem){
          player1.items[itemIndex].useKey();
        }
      });
      //listener: KeyItem.useKey
      $("div.well ul#heldItems li.item").click(function(){
        var itemIndex=$("div.well ul#heldItems li.item").index(this);
        if (player1.items[itemIndex] instanceof KeyItem){
          player1.items[itemIndex].useKey();
          player1.checkInventory();
        }
      });
    }
  };
  //User collects an item
  Player.prototype.inventoryAdd = function(index) {
    if (!this.cell.items) {alert("ERROR: These are no items in the current cell.");}
    var pIndex = parseInt(this.items.length);
    if (this.cell.items) {                                                    //if this cell has items
      this.items.push(this.cell.items[index]);                                //add item to player inventory
      this.cell.items.splice(index,1);                                        //removes item from cell
      this.items[pIndex].info.setOwner(this);                                 //set owner to player MAY BE REMOVED
    }
  }


  //player traversal methods
  Player.prototype.setCell = function() {
    if (Number.isInteger(this.id[0]) && Number.isInteger(this.id[1])) {
      this.cell = this.loc.cells[this.id[0]][this.id[1]];
    }
    else {
      alert("Sorry, an error has occurred: Player coordinates were set to an invalid value.");
    }
  }
  Player.prototype.switchRoom = function (exitBorder) {
    var x = this.id[0];
    var y = this.id[1];
    if (exitBorder.nextRoom.length) {
      this.setPosX(exitBorder.nextRoom[0]);
      this.setPosY(exitBorder.nextRoom[1]);
      this.setLoc (exitBorder.nextRoom[2]);
      this.setCell();
    }
    if (!exitBorder.nextRoom.length) {
      return "ERROR: There is no exit here";
    }
  }
  Player.prototype.mvUp = function(){
    if (this.cell.n.isExit) {
      this.switchRoom(this.loc.cells[this.id[0]][this.id[1]].n);
      return "You enter "+this.loc.name+".";
    }
    else {
      if ((this.id[1]-1)>=0 && this.loc.cells[this.id[0]][this.id[1]-1] !== undefined){
        if (this.cell.n.type > 0){
          if (this.cell.n.isLocked !== true){
              this.id[1]--;
              this.setCell();
              return "You walk north.";
          }
          else {return "You are stopped by an obstacle. Maybe there's an item nearby to help you get passed it.";}
        }
        else {return "You are stopped by a wall.";}
      }
      else {return "You are unable to go any further in that direction.";}
    }
  }
  Player.prototype.mvDown = function(){
    if (this.cell.s.isExit) {
      this.switchRoom(this.loc.cells[this.id[0]][this.id[1]].s);
      return "You enter "+this.loc.name+".";
    }
    else {
      if ((this.id[1]+1) <= this.loc.cells[this.id[0]].length-1 && this.loc.cells[this.id[0]][this.id[1]+1] !== undefined){
        if (this.cell.s.type > 0){
          if (this.cell.s.isLocked !== true){
              this.id[1]++;
              this.setCell();
              return "You walk south.";
          }
          else {return "You are stopped by an obstacle. Maybe there's an item nearby to help you get passed it.";}
        }
        else {return "You are stopped by a wall.";}
      }
      else {return "You are unable to go any further in that direction.";}
    }
  }
  Player.prototype.mvRight = function(){
    if (this.cell.e.isExit) {
      this.switchRoom(this.loc.cells[this.id[0]][this.id[1]].e);
      return "You enter "+this.loc.name+".";
    }
    else {
    if ((this.id[0]+1) <= this.loc.cells.length-1 && this.loc.cells[this.id[0]+1][this.id[1]] != undefined){
      if (this.cell.e.type > 0){
        if (this.cell.e.isLocked !== true){
            this.id[0]++;
            this.setCell();
            return "You walk east.";
              }
              else {return "You are stopped by an obstacle. Maybe there's an item nearby to help you get passed it.";}
          }
          else {return "You are stopped by a wall.";}
      }
      else {return "You are unable to go any further in that direction.";}
    }
  }
  Player.prototype.mvLeft = function(){
    if (this.cell.w.isExit) {
      this.switchRoom(this.loc.cells[this.id[0]][this.id[1]].w);
      return "You enter "+this.loc.name+".";
    }
    else {
      if ((this.id[0]-1) >= 0 && this.loc.cells[this.id[0]-1][this.id[1]] != undefined){
        if (this.cell.w.type > 0){
          if (this.cell.w.isLocked !== true){
              this.id[0]--;
              this.setCell();
              return "You walk west.";
          }
          else {return "You are stopped by an obstacle. Maybe there's an item nearby to help you get passed it.";}
        }
        else {return "You are stopped by a wall.";}
      }
      else {return "You are unable to go any further in that direction.";}
    }
  }


  //!THE BELLOW CODE REGARDING: Locale,Cell,Border AND DECLARED INSTANCES SUCCESSFULLY CREATES A WORKING GAMEBOARD!

  function Locale (name="[PLACEHOLDER_Rm_NAME]",cells=[]) {
    this.name   = name;
    this.cells  = cells;
    //this.events = events;
  }
  //WORKS BUT BE CAREFUL OF OBJECTS ASSIGNED BY REF. RATHER THAN VAL. :: use .copyOf() if avalible
  Locale.prototype.cellDebug = function(){
    //If room has been defined/not empty
    if (this.cells.length>0) {
      //this moves through the outter (x-axis) array of arrays
      this.cells.forEach(function(cell_X,x) {
        //this moves through the inner (y-axis) arrays
        cell_X.forEach(function(cell_Y,y) {
          //if array cell contains a Cell object
          if (typeof cell_Y === "object") {
            //if cell has coordinates already
            if (cell_Y.name.search("\\[") !== -1) {
              cell_Y.name = cell_Y.name.substring(0,cell_Y.name.search("\\["));
            }
            cell_Y.name = cell_Y.name + "[" + x.toString() + "," + y.toString() + "]";
          }
        })
      })
    }
  }
  Locale.prototype.addNorthRow = function () {
    //for each X position add a space to the start of the corresponding Y array
    this.cells.forEach(function (cell){cell.unshift(undefined);})
  };
  Locale.prototype.addSouthRow = function () {
    //for each X position add a space to the end of the corresponding Y array
    this.cells.forEach(function (cell){cell.push(undefined);})
  };
  Locale.prototype.addWestRow = function () {
    var width  = this.cells[0].length;
    //the x array grows from the left;
    this.cells.unshift(new Array (width));
    this.cells[0].forEach(function(cell){cell=undefined;});
  };
  Locale.prototype.addEastRow = function () {
    var width  = this.cells[0].length;
    var newMax = this.cells.length;
    //the x array grows from the right;
    this.cells.push(new Array (width));
    this.cells[newMax].forEach(function(cell){cell=undefined;});
  };

  function Cell (name        = "[PLACEHOLDER_Cl_NAME]",
                 description = "[PLACEHOLDER_DESC]",
                 rm          = "[PLACEHOLDER_Rm_NAME]",
                 n,s,e,w,
                 items       = [])
  {
    //what's it's name?
    this.name=name;
    //room description goes bellow:
    this.description=description;
    this.rmName=rm;
    //is the direction passable? uses border object
    this.n=n;
    this.s=s;
    this.e=e;
    this.w=w;
    //does it have items?
    this.items=items;
  }
  //TESTED COPY FUNCTION
  Cell.prototype.copyOf = function(){
    var newCell = new Cell (this.name,this.description,this.rmName,
                            this.n.copyOf(),this.s.copyOf(),this.e.copyOf(),this.w.copyOf(),[]);
    return newCell;
  }
  //NEED TO TEST COPY FUNCTION
  Cell.prototype.copyOfItems = function(){
    var newCell = new Cell (this.name,this.description,this.rmName,
                            this.n.copyOf(),this.s.copyOf(),this.e.copyOf(),this.w.copyOf(),[]);
    //if old cell has items push them onto the items array of new cell
    if (this.items.length) {
      this.items.forEach(function(item){newCell.items.push(item.copyOf())});
    }
    return newCell;
  }

  function Border(edgeType) {
    this.type = edgeType;  //CAN BE: wall(0)/open(1)/door(2)
    //this.isOpen   = false; OUT OF SCOPE -- too much work
    this.isLocked = false;
    this.isExit   = false;
    this.nextRoom = [];
    this.lockID   = -1;
  }
  //TESTED COPY FUNCTION
  Border.prototype.copyOf  = function () {return new Border(this.type);} //TEST COPY FUNCTION
  Border.prototype.setExit = function (newX,newY,roomIndex) {
    this.isExit=true;
    this.nextRoom[0]=newX;
    this.nextRoom[1]=newY;
    this.nextRoom[2]=roomList[roomIndex];
  }
  Border.prototype.setLockID  = function (id) {
    if(typeof id == "number" && id < -1) {
      this.lockID=id;
    }
  }

  //BUILD TESTROOM
  var cell_Empty = new Cell("EMPTY CELL","An empty cell","TestRm",new Border(1),new Border(1),new Border(1),new Border(1),[]);
  // !WARNING! : create()'s arg acts as PROTOTYPE. in console cells will be unset. -- Object.create(cell_Empty); --
  var testCell_0_0 = cell_Empty.copyOf();
  var testCell_0_1 = cell_Empty.copyOf();
  var testCell_0_2 = cell_Empty.copyOf();
  var testCell_1_0 = cell_Empty.copyOf();
  var testCell_1_1 = cell_Empty.copyOf();
  var testCell_1_2 = cell_Empty.copyOf();
  var testCell_2_0 = cell_Empty.copyOf();
  var testCell_2_1 = cell_Empty.copyOf();
  var testCell_2_2 = cell_Empty.copyOf();

  var testRoom1    = new Locale("TestRm1",
                                [[testCell_0_0,testCell_0_1,testCell_0_2],
                                 [testCell_1_0,testCell_1_1,testCell_1_2],
                                 [testCell_2_0,testCell_2_1,testCell_2_2]]);
  var testRoom2    = new Locale("TestRm2",
                                [[cell_Empty.copyOf(),cell_Empty.copyOf(),cell_Empty.copyOf()],
                                 [cell_Empty.copyOf(),cell_Empty.copyOf(),cell_Empty.copyOf()],
                                 [cell_Empty.copyOf(),cell_Empty.copyOf(),cell_Empty.copyOf()]]);
  // Give rooms descriptions

  testRoom1.cells[2][0].description = "<br>A slight breeze blows thick dust into your nostrils and you feel the cold damp stone floor as to wake to a darkened room, but where is it?  And how did you get here?  What is the last thing you remember? Do you remember anything?  The air is dense and you are struggling to breathe.  You can make out one door to the west? But why do you know it's the west?";
  testRoom1.cells[2][0].n.type = 0;
  testRoom1.cells[2][0].s.type = 0;
  testRoom1.cells[2][0].e.type = 0;
  testRoom1.cells[2][0].w.type = 2;

  testRoom1.cells[1][0].description = "<br>As you walk through the door, you knock over a box and examining the contents strewn across the floor, you find a working flash light that illuminates another door to the west.";
  testRoom1.cells[1][0].n.type = 0;
  testRoom1.cells[1][0].s.type = 0;
  testRoom1.cells[1][0].e.type = 2;
  testRoom1.cells[1][0].w.type = 2;

  testRoom1.cells[0][0].description = "<br>This is just another empty chamber, but as you scan the room, your light frames a strange photo, blown up and pasted to the West wall.  Hundreds of people stare masked into the camera.  Uniformed children and adults waiting for the gas to fall. To the south, an open passage is obscured by a neatly stacked pile of ammo crates with a thick layer of dust.";
  testRoom1.cells[0][0].n.type = 0;
  testRoom1.cells[0][0].s.type = 2;
  testRoom1.cells[0][0].e.type = 2;
  testRoom1.cells[0][0].w.type = 1;

  testRoom1.cells[0][1].description = "<br>This room is empty, save for two surveillance cameras perched over two doors. The first leads further South and the second to the East.  What's behind these doors?";
  testRoom1.cells[0][1].n.type = 2;
  testRoom1.cells[0][1].s.type = 2;
  testRoom1.cells[0][1].e.type = 2;
  testRoom1.cells[0][1].w.type = 0;


  testRoom1.cells[1][1].description = "<br>The desks that line this room are loaded down with ancient terminals and on the edge of the farthest from the door, you find a rusty key.";
  testRoom1.cells[1][1].n.type = 0;
  testRoom1.cells[1][1].s.type = 0;
  testRoom1.cells[1][1].e.type = 0;
  testRoom1.cells[1][1].w.type = 2;

  testRoom1.cells[0][2].description = "<br>Sloping to the south, pooling water stands stagnant, and black mold crawls up the walls.  This bunker was compromised by something, but the air is still thick and stale... you struggle to breathe... you need to find your way out now.  Run for the door on the East wall.";
  testRoom1.cells[0][2].n.type = 2;
  testRoom1.cells[0][2].s.type = 0;
  testRoom1.cells[0][2].e.type = 2;
  testRoom1.cells[0][2].w.type = 0;

  testRoom1.cells[1][2].description = "<br>As you shine your light to the North wall, you see a grizzly sight.  Decomposed bodies, their heads hanging off to the side, and dry pool of blood slowly peeling from the floor leading to the south wall, flooded blood red.  The last body grips a shotgun in it's maggot infested hand.  Will you take the shotgun into the room to the East?";
  testRoom1.cells[1][2].n.type = 0;
  testRoom1.cells[1][2].s.type = 0;
  testRoom1.cells[1][2].e.type = 2;
  testRoom1.cells[1][2].w.type = 2;

  testRoom1.cells[2][2].description = "<br>Lockers line the South and East walls, hazmat suits and gas masks... but are they for heading back West or out through the door to the North.";
  testRoom1.cells[2][2].n.type = 2;
  testRoom1.cells[2][2].s.type = 0;
  testRoom1.cells[2][2].e.type = 0;
  testRoom1.cells[2][2].w.type = 2;

  testRoom1.cells[2][1].description = "<br>Light! This door to the East leads to the outside world, but what is that outside world, you remember nothing... Better get out there before you choke on the stale air.";
  testRoom1.cells[2][1].n.type = 0;
  testRoom1.cells[2][1].s.type = 2;
  testRoom1.cells[2][1].e.type = 2;
  testRoom1.cells[2][1].w.type = 0;


  //this is the global list containing all rooms
  var roomList = [testRoom1,testRoom2];
  var player1  = new Player("Bob",testRoom1,2,0);
  var rustyKey = new KeyItem("rustyKey","An old key.");
  var shotgun  = new KeyItem("shotgun" ,"Congratulations! You found a shotgun...You can't use it for anything...but you have one.");

  //THE FOLLOWING SETS TWO EXITS TO ALLOW BI-DIRECTIONAL TRAVEL FROM ROOM1 AT 2,1 AND TO ROOM2 AT 0,1
  roomList[0].cells[2][1].e.setExit(0,1,1);
  roomList[1].cells[0][1].w.setExit(2,1,0);
  //THE FOLLOWING PLACES A KEY IN GRID-SPACE 1,1 INSIDE ROOM1
  rustyKey.info.setOwner(testRoom1);
  rustyKey.info.setPos(1,1);
  rustyKey.setToOwner();
  rustyKey.setLockID(777);

  shotgun.info.setOwner(testRoom1);
  shotgun.info.setPos(1,0);
  shotgun.setToOwner();

  //THE FOLLOWING SETS THE DOOR(S) ABOVE TO A LOCKED STATE
  testRoom1.cells[0][0].n.isLocked=true;
  testRoom1.cells[0][0].n.setLockID(777);
  testRoom2.cells[0][2].s.isLocked=true;
  testRoom2.cells[0][2].s.setLockID(777);
