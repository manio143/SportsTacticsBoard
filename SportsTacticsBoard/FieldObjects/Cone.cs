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
  /// <summary>
  /// Author: Ulrich Jenzer
  /// </summary>
  class Cone : FieldObject
  {
    private string label = string.Empty;
    public override string Label
    {
      get { return label; }
    }

    private string tag;
    public override string Tag
    {
      get { return tag; }
    }

    protected override int LabelFontSize
    {
      get { return 8; }
    }

    public Cone(string label, string tag, float posX, float posY, float dispRadius)
      : base(posX, posY, dispRadius)
    {
      OutlinePenColor = Color.Black;
      FillBrushColor = Color.Orange;
      this.label = label;
      this.tag = tag;
    }

    protected override float[] MovementPenDashPattern
    {
      get { return new float[] { 3.0F, 2.0F }; }
    }

    public override void DrawAt(Graphics graphics, PointF pos)
    {
      base.DrawAt(graphics, pos);

      RectangleF rect = GetRectangleAt(pos);
      if (OutlinePenWidth > 0.0) {
        using (Pen outlinePen = new Pen(OutlinePenColor, OutlinePenWidth)) {
          graphics.DrawRectangle(outlinePen, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }
      }
    }
  }
}
