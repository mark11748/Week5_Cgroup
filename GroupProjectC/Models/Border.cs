using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GroupProjectC.Models
{
  public class Border
  {
    //bool isOpen   = false; OUT OF SCOPE -- too much work
    private bool _isLocked = false;
    private bool _isExit   = false;
    //CAN BE: wall(0)/open(1)/door(2)
    private int  _edgeType;
    private int  _lockId;
    private int  _exitId;

    public Border(int type=0, int exitId=-1, int lockId=-1)
    {
      _edgeType = type;
      if (exitId>-1) {this.SetIsExit(true);}
      if (lockId>-1) {this.SetIsLocked(true);}

      if (type<0 || type>2)
      {this._edgeType=0;}
      if (type==0)
      {/*is a wall*/}
      if (type==1)
      {/*is a open*/}
      if (type==2)
      {/*is a door*/}
    }

    public bool GetIsLocked()              {return this._isLocked;}
    public void SetIsLocked(bool isLocked) {this._isLocked=isLocked;}
    public bool GetIsExit  ()              {return this._isExit;}
    public void SetIsExit  (bool isExit)   {this._isExit=isExit;}
    public int  GetEdgeType()              {return this._edgeType;}
    public void SetEdgeType(int edge)      {this._edgeType=edge;}
    public int  GetLockId  ()              {return this._lockId;}
    public void SetLockId  (int lockNumber){this._lockId=lockNumber;}
    public int  GetExitId  ()              {return this._exitId;}
    public void SetExitId  (int exitNumber){this._exitId=exitNumber;}

    public Border CopyOf()
    {
      return new Border(this.GetEdgeType(),
                        this.GetExitId(),
                        this.GetLockId());
    }
  }
}
