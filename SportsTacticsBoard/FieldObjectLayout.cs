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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace SportsTacticsBoard
{
  public class FieldObjectLayout
  {
    [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields")]
    [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
    public List<FieldObjectLayoutEntry> entries;

    public FieldObjectLayout()
    {
      entries = new List<FieldObjectLayoutEntry>();
    }

    public void AddEntry(string tag, PointF pos)
    {
      entries.Add(new FieldObjectLayoutEntry(tag, pos));
    }

    public void AddEntry(string tag, float posX, float posY)
    {
      entries.Add(new FieldObjectLayoutEntry(tag, posX, posY));
    }

    private FieldObjectLayoutEntry FindEntry(string tag)
    {
      return entries.Find(delegate(FieldObjectLayoutEntry entry) { return (entry.Tag == tag); });
    }

    public bool HasEntry(string tag)
    {
      return (FindEntry(tag) != null);
    }

    public PointF GetEntryPosition(string tag)
    {
      FieldObjectLayoutEntry e = FindEntry(tag);
      return new PointF(e.PositionX, e.PositionY);
    }

    public void RemoveEntry(string tag)
    {
      // Not particularily efficient, but works
      entries.Remove(FindEntry(tag));
    }

    [XmlIgnore]
    public ICollection<string> Tags
    {
      get {
        List<string> l = new List<string>();
        foreach (FieldObjectLayoutEntry e in entries) {
          l.Add(e.Tag);
        }
        return l;
      }
    }
  }
}
