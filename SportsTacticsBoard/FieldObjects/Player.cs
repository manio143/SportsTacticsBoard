// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006 Robert Turner
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SportsTacticsBoard.FieldObjects
{
  public class Player : Person
  {
    public enum TeamId {
      Attacking,
      Defending
    }

    private TeamId team;
    public TeamId Team
    {
      get { return team; }
    }

    private int number;
    public int Number
    {
      get { return number; }
    }

    public override string Label
    {
      get { return number.ToString(); }
    }

    public override string Tag
    {
      get { return ComposeTag(Team, Number); }
    }

    public override string Name
    {
      get { return ComposeName(Team, Number); }
    }

    public static string ComposeName(TeamId team, int playerNumber)
    {
      string nameFormat = Properties.Resources.ResourceManager.GetString("FieldObject_Player_Name_Format");
      string teamName = Properties.Resources.ResourceManager.GetString("TeamName_" + team.ToString());
      return String.Format(nameFormat, teamName, playerNumber);
    }

    public static string ComposeTag(TeamId team, int playerNumber)
    {
      return "Player_" + team.ToString() + "_" + playerNumber.ToString();
    }

    public static int ExtractPlayerNumberFromTag(string playerTag)
    {
      int hashIndex = playerTag.LastIndexOf('_');
      if (hashIndex < 0)
      {
        return -1;
      }
      return int.Parse(playerTag.Substring(hashIndex + 1));
    }

    protected override Brush FillBrush
    {
      get {
        switch (team) {
          case TeamId.Defending:
            return Brushes.Red;
          case TeamId.Attacking:
          default:
            return Brushes.Yellow;
        }
      }
    }

    protected override Color MovementPenColor
    {
      get {
        switch (team) {
          case TeamId.Defending:
            return Color.Red;
          case TeamId.Attacking:
          default:
            return Color.Yellow;
        }
      }
    }

    protected override Pen OutlinePen
    {
      get { return Pens.White; }
    }

    public Player(int _number, TeamId _team, float posX, float posY) :
      base(posX, posY)
    {
      team = _team;
      number = _number;
    }
  }
}
