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
  internal abstract class GenericColumnBasedLayoutAlgorithm : TeamLayoutAlgorithm
  {
    protected abstract float[] PositionIndents { get; }

    protected abstract int[] PlayerToColumnIndexes { get; }

    public GenericColumnBasedLayoutAlgorithm(IFieldType _fieldType) :
      base(_fieldType)
    {
    }

    private int ColumnOfPlayer(string p)
    {
      int playerNumber = FieldObjects.NumberedPlayer.ExtractPlayerNumberFromTag(p);
      int[] ptci = PlayerToColumnIndexes;
      if ((playerNumber <= 0) && (playerNumber > ptci.Length)) {
        return -1;
      }
      return ptci[playerNumber - 1];
    }

    protected override void AppendPlayerPositions(FieldObjectLayout layout, ReadOnlyCollection<string> playersToPosition, bool putOnLeftSide)
    {
      PositionPlayers(layout, playersToPosition, putOnLeftSide, PositionIndents);            
    }

    private void PositionPlayers(FieldObjectLayout layout, ReadOnlyCollection<string> playersToPosition, bool putOnLeftSide, float[] indents)
    {
      // Put the players in "columns"
      List<string>[] columns = new List<string>[indents.Length];
      for (int idx = 0; idx < indents.Length; idx++) {
        columns[idx] = new List<string>();
      }
      foreach (string p in playersToPosition)
      {
        int idx = ColumnOfPlayer(p);
        if ((idx >= 0) && (idx < columns.Length)) {
          columns[idx].Add(p);
        }
      }

      // Now position space all the players out in the columns evenly
      foreach (List<string> column in columns)
      {
        float spacing = FieldWidth / (column.Count + 1.0F);
        float posY = spacing;
        if (column.Count > 2) {
          // If we have more than 2 players on a line, space them out
          // so that they push out closer to the line
          float removeMargin = spacing / (float)(column.Count - 2);
          spacing = (FieldWidth + (2.0F * removeMargin)) / (column.Count + 1.0F);
          posY = spacing - removeMargin;
        }
        foreach (string p in column)
        {
          layout.AddEntry(p, FlipToSide(indents[ColumnOfPlayer(p)], putOnLeftSide), posY);
          posY += spacing;
        }
      }
    }
  }
}
