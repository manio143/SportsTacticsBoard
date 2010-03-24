// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2010 Robert Turner
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
using System.Drawing;

namespace SportsTacticsBoard.FieldObjects
{
  abstract class BaseCone : FieldObject
  {
    public int ConeNumber { get; private set; }

    public override string Label
    {
      get { return string.Format(System.Globalization.CultureInfo.CurrentUICulture, Properties.Resources.FieldObject_BaseCone_Label_Format, ConeNumber); }
    }

    public override string Tag
    {
      get { return string.Format(System.Globalization.CultureInfo.InvariantCulture, "Cone_{0}", ConeNumber); }
    }

    public override string Name
    {
      get { return string.Format(System.Globalization.CultureInfo.CurrentUICulture, Properties.Resources.FieldObject_BaseCone_Name_Format, ConeNumber); }
    }

    protected override int LabelFontSize
    {
      get { return 8; }
    }

    protected BaseCone(int coneNumber, float posX, float posY, float dispRadius) :
      base(posX, posY, dispRadius)
    {
      ConeNumber = coneNumber;
      OutlinePenColor = Color.Black;
      FillBrushColor = Color.Orange;
      MovementPenWidth = 1.5F;
      MovementPenColor = Color.Orange;
    }

    protected override float[] MovementPenDashPattern
    {
      get { return new float[] { 3.0F, 2.0F }; }
    }
  }
}
