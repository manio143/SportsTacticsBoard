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
using System.Xml.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace SportsTacticsBoard
{
  [XmlType(TypeName = "SportsTacticsBoardDocument")]
  public class LayoutSequence
  {
    [XmlElement(ElementName="fieldType")]
    public string fieldTypeTag;

    [XmlElement(ElementName = "layoutSequence")]
    [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
    public List<Layout> layoutSequence;

    public LayoutSequence()
    {
      layoutSequence = new List<Layout>();
    }

    public LayoutSequence(string _fieldTypeTag)
    {
      layoutSequence = new List<Layout>();
      fieldTypeTag = _fieldTypeTag;
    }

    public int NumberOfLayouts
    {
      get { return layoutSequence.Count; }
    }

    public Layout GetLayout(int index)
    {
      if ((index >= 0) && (index < layoutSequence.Count)) {
        return layoutSequence[index];
      } else {
        return null;
      }
    }

    public void SetLayout(int index, Layout layout)
    {
      if ((index >= 0) && (index < layoutSequence.Count)) {
        layoutSequence[index] = layout;
      }
    }

    public int AddNewLayout(int index, Layout layout)
    {
      if (index >= layoutSequence.Count) {
        layoutSequence.Add(layout);
        return layoutSequence.Count - 1;
      } else {
        layoutSequence.Insert(index, layout);
        return index;
      }
    }

    public void RemoveFromSequence(int index)
    {
      if ((index >= 0) && (index < layoutSequence.Count)) {
        layoutSequence.RemoveAt(index);
      }
    }
  }
}
