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

namespace SportsTacticsBoard
{
  public class FieldObjectLayoutSequence
  {
    public string fieldTypeTag;
    public List<FieldObjectLayout> layoutSequences;

    public FieldObjectLayoutSequence(string _fieldTypeTag)
    {
      layoutSequences = new List<FieldObjectLayout>();
      fieldTypeTag = _fieldTypeTag;
    }

    public int NumberOfLayouts
    {
      get { return layoutSequences.Count; }
    }

    public FieldObjectLayout GetLayout(int index)
    {
      if ((index >= 0) && (index < layoutSequences.Count)) {
        return layoutSequences[index];
      } else {
        return null;
      }
    }

    public void SetLayout(int index, FieldObjectLayout layout)
    {
      if ((index >= 0) && (index < layoutSequences.Count)) {
        layoutSequences[index] = layout;
      }
    }

    public int AddNewLayout(int index, FieldObjectLayout layout)
    {
      if (index >= layoutSequences.Count) {
        layoutSequences.Add(layout);
        return layoutSequences.Count - 1;
      } else {
        layoutSequences.Insert(index, layout);
        return index;
      }
    }

    public void RemoveFromSequence(int index)
    {
      if ((index >= 0) && (index < layoutSequences.Count)) {
        layoutSequences.RemoveAt(index);
      }
    }
  }
}
