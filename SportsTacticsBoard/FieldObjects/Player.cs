// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006-2007 Robert Turner
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
using System.Globalization;

namespace SportsTacticsBoard.FieldObjects
{
  abstract class Player : Person
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

    public override string Tag
    {
      get { return ComposeTag(Team, Label); }
    }

    public override string Name
    {
      get { return ComposeName(Team, Label); }
    }

    public static string ComposeName(TeamId team, string playerLabel)
    {
      string nameFormat = Properties.Resources.ResourceManager.GetString("FieldObject_Player_Name_Format");
      string teamName = Properties.Resources.ResourceManager.GetString("TeamName_" + team.ToString());
      return String.Format(CultureInfo.CurrentUICulture, nameFormat, teamName, playerLabel);
    }

    public static string ComposeTag(TeamId team, string playerLabel)
    {
      return "Player_" + team.ToString() + "_" + playerLabel;
    }

    private static Color GetTeamColor(TeamId team)
    {
      switch (team) {
        case TeamId.Defending:
          return Color.Red;
        case TeamId.Attacking:
        default:
          return Color.Yellow;
      }
    }

    public Player(TeamId _team, float dispRadius) :
      base(0.0F, 0.0F, dispRadius)
    {
      team = _team;
      OutlinePenColor = Color.White;
      MovementPenColor = GetTeamColor(team);
      FillBrushColor = GetTeamColor(team);
    }
  }
}
