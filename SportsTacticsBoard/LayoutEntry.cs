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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace SportsTacticsBoard
{
  [XmlType(TypeName = "LayoutEntry")]
  public class LayoutEntry
  {
    public LayoutEntry() {
      tag = "";
    }

    public LayoutEntry(string _tag, float posX, float posY) {
      tag = _tag;
      positionX = posX;
      positionY = posY;
    }

    public LayoutEntry(string _tag, PointF pt) {
      tag = _tag;
      positionX = pt.X;
      positionY = pt.Y;
    }

    [XmlAttribute(AttributeName = "tag")]
    public string Tag {
      get { return tag; }
      set { tag = value; }
    }

    [XmlAttribute(AttributeName = "x")]
    public float PositionX {
      get { return positionX; }
      set { positionX = value; }
    }

    [XmlAttribute(AttributeName = "y")]
    public float PositionY {
      get { return positionY; }
      set { positionY = value; }
    }

    private string tag;
    private float positionX;
    private float positionY;
  }
}
