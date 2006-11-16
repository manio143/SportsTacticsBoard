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

namespace SportsTacticsBoard.LayoutAlgorithms
{
  internal class BenchLayoutAlgorithm : TeamLayoutAlgorithm
  {
    public BenchLayoutAlgorithm(IFieldType _fieldType)
      :
      base(_fieldType)
    {
    }

    public override ReadOnlyCollection<string> SupportedFieldTypes
    {
      get
      {
        return new ReadOnlyCollection<string>(new string[] { "Soccer" });
      }
    }

    protected override void AppendPlayerPositions(FieldObjectLayout layout, ReadOnlyCollection<string> playersToPosition, bool putOnLeftSide)
    {
      const float spacing = 3.25F;
      const float benchIndent = 5.0F;
      const float benchDistanceFromField = 5.25F;
      float benchY = FieldWidth + benchDistanceFromField;
      float benchStartPos = benchIndent;
      if (!putOnLeftSide)
      {
        benchStartPos += FieldLength / 2.0F;
      }

      foreach (string p in playersToPosition)
      {
        int playerNumber = FieldObjects.Player.ExtractPlayerNumberFromTag(p);
        if (playerNumber >= 0)
        {
          layout.AddEntry(p, benchStartPos + (spacing * playerNumber), benchY);
        }
      }
    }
  }
}
