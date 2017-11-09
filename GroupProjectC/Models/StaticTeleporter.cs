using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class TeleporterStatic : Item
  {
    private bool _isCollectable;

    private int  _sourceX;
    private int  _sourceY;
    private int  _sourceAreaId;
    private int  _sourceRoomId;

    private int  _targetX;
    private int  _targetY;
    private int  _targetAreaId;
    private int  _targetRoomId;

    public bool GetIsCollectable()                 {return this._isCollectable;}
    public void SetIsCollectable(bool collectable) {this._isCollectable=collectable;}

    public int  GetSourceX ()            {return this._sourceX;}
    public void SetSourceX (int x)       {this._sourceX=x;}
    public int  GetSourceY ()            {return this._sourceY;}
    public void SetSourceY (int y)       {this._sourceY=y;}

    public int  GetSourceArea ()         {return this._sourceAreaId;}
    public void SetSourceArea (int area) {this._sourceAreaId=area;}
    public int  GetSourceRoom ()         {return this._targetRoomId;}
    public void SetSourceRoom (int room) {this._targetAreaId=room;}

    public int  GetTargetX    ()         {return this._targetX;}
    public void SetTargetX    (int x)    {this._targetX=x;}
    public int  GetTargetY    ()         {return this._targetY;}
    public void SetTargetY    (int y)    {this._targetY=y;}

    public int  GetTargetArea ()         {return this._targetAreaId;}
    public void SetTargetArea (int area) {this._targetAreaId=area;}
    public int  GetTargetRoom ()         {return this._targetRoomId;}
    public void SetTargetRoom (int room) {this._targetAreaId=room;}

    // source an target defined in format posX,posY,Map_Id,Room_Id
    public TeleporterStatic(string name,
                            string description,
                            int posX, int posY,
                            int srcX,int srcY,int srcMap,int srcRoom,
                            int tgtX,int tgtY,int tgtMap,int tgtRoom,
                            bool collectable=false)
    {
      this.SetName     (name);
      this.SetDescript (description);
      this.SetX     (posX);
      this.SetY     (posY);
      this._ownedBy = 0;

      this.SetIsCollectable(collectable);

      this.SetSourceX(srcX);
      this.SetSourceY(srcY);
      this.SetSourceArea(srcMap);
      this.SetSourceRoom(srcRoom);
      this.SetTargetX(tgtX);
      this.SetTargetY(tgtY);
      this.SetTargetArea(tgtMap);
      this.SetTargetRoom(tgtRoom);
    }


  }
}
