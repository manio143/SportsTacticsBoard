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
  internal abstract class FourFourTwoLayoutAlgorithm : GenericColumnBasedLayoutAlgorithm
  {
    public FourFourTwoLayoutAlgorithm(IFieldType _fieldType) :
      base(_fieldType)
    {
    }

    protected override int[] PlayerToColumnIndexes {
      get {
        return new int[11] { 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3 };
      }
    }
    
    public override ReadOnlyCollection<string> SupportedFieldTypes
    { 
      get {
        return new ReadOnlyCollection<string>(new string[] { "Soccer" });
      } 
    }
  }
}
