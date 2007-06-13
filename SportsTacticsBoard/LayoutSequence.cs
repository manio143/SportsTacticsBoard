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
using System.Text;
using System.Xml.Serialization;

namespace SportsTacticsBoard
{
  [XmlType(TypeName = "SportsTacticsBoardDocument")]
  public class LayoutSequence
  {
    [XmlElement(ElementName="fieldType")]
    public string fieldTypeTag;

    [XmlElement(ElementName = "layoutSequence")]
    public Collection<Layout> Sequence
    {
      get
      {
        return sequence;
      }
      set
      {
        sequence = value;
      }
    }
    private Collection<Layout> sequence;

    public LayoutSequence()
    {
      sequence = new Collection<Layout>();
    }

    public LayoutSequence(string _fieldTypeTag)
    {
      sequence = new Collection<Layout>();
      fieldTypeTag = _fieldTypeTag;
    }

    public int NumberOfLayouts
    {
      get { return sequence.Count; }
    }

    public Layout GetLayout(int index)
    {
      if ((index >= 0) && (index < sequence.Count)) {
        return sequence[index];
      } else {
        return null;
      }
    }

    public void SetLayout(int index, Layout layout)
    {
      if ((index >= 0) && (index < sequence.Count)) {
        sequence[index] = layout;
      }
    }

    public int AddNewLayout(int index, Layout layout)
    {
      if (index >= sequence.Count) {
        sequence.Add(layout);
        return sequence.Count - 1;
      } else {
        sequence.Insert(index, layout);
        return index;
      }
    }

    public void RemoveFromSequence(int index)
    {
      if ((index >= 0) && (index < sequence.Count)) {
        sequence.RemoveAt(index);
      }
    }
  }
}
