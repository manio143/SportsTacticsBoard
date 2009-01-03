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
    private string fieldTypeTag;

    [XmlElement(ElementName = "fieldType")]
    public string FieldTypeTag
    {
      get { return fieldTypeTag; }
      set { fieldTypeTag = value; }
    }

    [XmlElement(ElementName = "layoutSequence")]
    public Collection<FieldLayout> Sequence
    {
      get
      {
        return sequence;
      }
    }
    private Collection<FieldLayout> sequence;

    public LayoutSequence()
    {
      sequence = new Collection<FieldLayout>();
    }

    public LayoutSequence(string fieldTypeTag)
    {
      sequence = new Collection<FieldLayout>();
      this.fieldTypeTag = fieldTypeTag;
    }

    public int NumberOfLayouts
    {
      get { return sequence.Count; }
    }

    public FieldLayout GetLayout(int index)
    {
      if ((index >= 0) && (index < sequence.Count)) {
        return sequence[index];
      } else {
        return null;
      }
    }

    public void SetLayout(int index, FieldLayout layout)
    {
      if ((index >= 0) && (index < sequence.Count)) {
        sequence[index] = layout;
      }
    }

    public int AddNewLayout(int index, FieldLayout layout)
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
