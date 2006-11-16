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
using System.Drawing;

namespace SportsTacticsBoard
{
  abstract class FieldObject
  {
    private PointF position;
    public PointF Position
    {
      get { return position; }
      set { position = value; }
    }
    
    private float displayRadius = 1.15F;
    public float DisplayRadius
    {
      get { return displayRadius; }
      set { displayRadius = value; }
    }

    public abstract string Tag { get; }
    public virtual string Name {
      get {
        return Properties.Resources.ResourceManager.GetString("FieldObject_" + Tag); 
      }
    }
    public abstract string Label { get; }
    protected abstract Brush FillBrush { get; }
    protected virtual Pen OutlinePen {
      get { return null; }
    }
    protected virtual Brush LabelBrush {
      get { return Brushes.Black; }
    }
    protected virtual int LabelFontSize {
      get { return 9; }
    }
    protected virtual bool HasLabel
    {
      get
      {
        return ((Label != null) && (Label.Length > 0));
      }
    }

    protected virtual Color MovementPenColor
    {
      get { return Color.White; }
    }

    protected virtual Pen MovementPen
    {
      get {
        Pen p = new Pen(MovementPenColor, 4);
        p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        return p; 
      }
    }

    protected FieldObject(float posX, float posY, float dispRadius)
    {
      position.X = posX;
      position.Y = posY;
      displayRadius = dispRadius;
    }

    public bool ContainsPoint(Point pt, FieldUnitToPixelConverter conversionDelegate)
    {
      Rectangle rect = GetRectangle(conversionDelegate);
      return rect.Contains(pt);
    }

    private Point GetCentre(FieldUnitToPixelConverter conversionDelegate)
    {
      return new Point(conversionDelegate(position.X), conversionDelegate(position.Y));
    }

    public Rectangle GetRectangle(FieldUnitToPixelConverter conversionDelegate)
    {
      if (null == conversionDelegate) {
        throw new ArgumentNullException("conversionDelegate");
      }
      int dispRadius = conversionDelegate(DisplayRadius);
      return new Rectangle(conversionDelegate(position.X) - dispRadius,
        conversionDelegate(position.Y) - dispRadius, dispRadius * 2, dispRadius * 2);
    }

    public virtual void Draw(Graphics graphics, FieldUnitToPixelConverter conversionDelegate)
    {
      if (null == conversionDelegate) {
        throw new ArgumentNullException("conversionDelegate");
      }
      if (null == graphics) {
        throw new ArgumentNullException("graphics");
      }
      Rectangle rect = GetRectangle(conversionDelegate);
      graphics.FillEllipse(FillBrush, rect);
      Pen outlinePen = OutlinePen;
      if (outlinePen != null) {
        graphics.DrawEllipse(outlinePen, rect);
      }
      if (HasLabel) {
        float fontSize = LabelFontSize * (float)rect.Height / 18.0F;
        Font labelFont = new Font("Arial", fontSize, FontStyle.Bold);
        StringFormat strFormat = new StringFormat();
        strFormat.Alignment = StringAlignment.Center;
        strFormat.LineAlignment = StringAlignment.Center;
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        graphics.DrawString(Label, labelFont, LabelBrush, rect, strFormat);
      }
    }

    public virtual void DrawMovementLine(Graphics graphics, FieldUnitToPixelConverter conversionDelegate, PointF pos)
    {
      if (null == conversionDelegate) {
        throw new ArgumentNullException("conversionDelegate");
      }
      if (null == graphics) {
        throw new ArgumentNullException("graphics");
      }
      Point endPoint = new Point(conversionDelegate(pos.X), conversionDelegate(pos.Y));
      graphics.DrawLine(MovementPen, GetCentre(conversionDelegate), endPoint);
    }
  }
}
