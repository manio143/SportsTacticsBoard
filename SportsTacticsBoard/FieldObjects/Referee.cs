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
  class Referee : Person
  {
    private string label;
    public override string Label
    {
      get { return label; }
    }

    private string tag;
    public override string Tag
    {
      get { return tag; }
    }

    protected override int LabelFontSize
    {
      get {
        if (Label.Length > 1) {
          return 6;
        } else {
          return 9;
        }
      }
    }

    public Referee(string _label, string _tag, float posX, float posY, float dispRadius) :
      base(posX, posY, dispRadius)
    {
      label = _label;
      tag = _tag;
      FillBrushColor = Color.Black;
      MovementPenColor = Color.Black;
      LabelBrushColor = Color.White;
    }
  }
}
