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
    public abstract string Tag { get; }
    public abstract string Label { get; }

    public PointF Position
    {
      get { return position; }
      set { position = value; }
    }

    private float DisplayRadius
    {
      get { return displayRadius; }
    }

    public virtual string Name {
      get {
        return Properties.Resources.ResourceManager.GetString("FieldObject_" + Tag); 
      }
    }

    public bool ContainsPoint(PointF pt)
    {
      RectangleF rect = GetRectangle();
      return rect.Contains(pt);
    }

    public RectangleF GetRectangle()
    {
      return new RectangleF(position.X - DisplayRadius,
        position.Y - DisplayRadius, DisplayRadius * 2, DisplayRadius * 2);
    }

    public virtual void Draw(Graphics graphics)
    {
      if (null == graphics) {
        throw new ArgumentNullException("graphics");
      }
      RectangleF rect = GetRectangle();
      using (Brush fillBrush = new SolidBrush(FillBrushColor)) {
        graphics.FillEllipse(fillBrush, rect);
      }
      if (OutlinePenWidth > 0.0) {
        using (Pen outlinePen = new Pen(OutlinePenColor, OutlinePenWidth)) {
          graphics.DrawEllipse(outlinePen, rect);
        }
      }
      if (HasLabel) {
        float fontSize = LabelFontSize * (float)rect.Height / 18.0F;
        Font labelFont = new Font("Arial", fontSize, FontStyle.Bold);
        StringFormat strFormat = new StringFormat();
        strFormat.Alignment = StringAlignment.Center;
        strFormat.LineAlignment = StringAlignment.Center;
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        try {
          graphics.DrawString(Label, labelFont, LabelBrush, rect, strFormat);
        }
        catch (System.Runtime.InteropServices.ExternalException) {
          // Sometimes we get a "generic error" from the GDI+ subsystem
          // when resizing the window really small and then slowly larger 
          // again. All the parameters seem correct, so we'll just catch and
          // ignore this exception here.
        }
      }
    }

    public virtual void DrawMovementLine(Graphics graphics, PointF pos)
    {
      if (null == graphics) {
        throw new ArgumentNullException("graphics");
      }
      PointF endPoint = new PointF(pos.X, pos.Y);
      graphics.DrawLine(GetMovementPen(), GetCentre(), endPoint);
    }

    protected FieldObject(float posX, float posY, float dispRadius)
    {
      position.X = posX;
      position.Y = posY;
      displayRadius = dispRadius;
    }

    private Color fillBrushColor = Color.White;
    public Color FillBrushColor {
      get { return fillBrushColor; }
      set { fillBrushColor = value; }
    }

    private Color outlinePenColor = Color.White;
    public Color OutlinePenColor
    {
      get { return outlinePenColor; }
      set { outlinePenColor = value; }
    }

    private Color labelBrushColor = Color.Black;
    public Color LabelBrushColor 
    {
      get { return labelBrushColor; }
      set { labelBrushColor = value; }
    }

    private Brush LabelBrush
    {
      get { return new SolidBrush(LabelBrushColor); }
    }

    protected virtual int LabelFontSize
    {
      get { return 9; }
    }

    private Color movementPenColor = Color.White;
    public Color MovementPenColor
    {
      get { return movementPenColor; }
      set { movementPenColor = value; }
    }

    private float outlinePenWidth = 1.0F;
    public float OutlinePenWidth 
    {
      get { return outlinePenWidth; }
      set { outlinePenWidth = value; }
    }

    private float movementPenWidth = 3.0F;
    public float MovementPenWidth 
    {
      get { return movementPenWidth; }
      set { movementPenWidth = value; }
    }

    protected virtual float[] MovementPenDashPattern
    {
      get { return null; }
    }

    private bool HasLabel
    {
      get { return !String.IsNullOrEmpty(Label); }
    }

    private PointF GetCentre()
    {
      return new PointF(position.X, position.Y);
    }

    private Pen GetMovementPen()
    {
      Pen p = new Pen(MovementPenColor, MovementPenWidth);
      p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
      p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
      float[] dashPattern = MovementPenDashPattern;
      if (null != dashPattern) {
        p.DashPattern = dashPattern;
      }
      return p;
    }

    private PointF position;
    private float displayRadius = 1.0F;
  }
}
