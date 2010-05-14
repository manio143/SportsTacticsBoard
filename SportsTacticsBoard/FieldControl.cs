// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006-2010 Robert Turner
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SportsTacticsBoard
{
  partial class FieldControl : UserControl
  {
    private float ratio;
    private Point fieldOriginInDisplayUnits = new Point(0, 0);
    private bool dirty;
    private IPlayingSurfaceType fieldType;
    private bool allowInteraction = true;

    public bool AllowInteraction
    {
      get { return allowInteraction; }
      set { 
        allowInteraction = value;
        this.Cursor = (allowInteraction) ? Cursors.Default : Cursors.No;
      }
    }

    public bool IsDirty
    {
      get { return dirty; }
      set
      {
        dirty = value;
        if (null != IsDirtyChanged) {
          IsDirtyChanged.Invoke(this, null);
        }
      }
    }

    public event EventHandler IsDirtyChanged;

    private bool showMovementLines = true;

    public bool ShowMovementLines
    {
      get
      {
        return showMovementLines;
      }
      set
      {
        showMovementLines = value;
        Invalidate();
      }
    }

    public FieldControl()
    {
      InitializeComponent();
    }

    public IPlayingSurfaceType FieldType
    {
      set
      {
        nextLayout = null;
        fieldObjects = null;

        fieldType = value;
        if (null != fieldType) {
          BackColor = fieldType.SurfaceColor;
          CalculateFieldGeometry(Size);
          fieldObjects = fieldType.StandardObjects;
          SetLayout(fieldType.DefaultLayout);
        }

        Invalidate();
      }
      get { return fieldType; }
    }

    private Collection<FieldObject> fieldObjects;

    static public FieldLayout ConvertFieldObjectsToLayout(ICollection<FieldObject> fieldObjects)
    {
      FieldLayout layout = new FieldLayout();
      foreach (FieldObject fo in fieldObjects) {
        layout.AddEntry(fo.Tag, fo.Position);
      }
      return layout;
    }

    public FieldLayout FieldLayout
    {
      get
      {
        return ConvertFieldObjectsToLayout(fieldObjects);
      }
    }

    public ICollection<FieldObject> FieldLayoutAsFieldObjects
    {
      get
      {
        return fieldObjects;
      }
    }

    public void SetLayout(FieldLayout layout)
    {
      if (null != layout) {
        foreach (FieldObject fo in fieldObjects) {
          if (layout.HasEntry(fo.Tag)) {
            fo.Position = layout.GetEntryPosition(fo.Tag);
            IsDirty = true;
          }
        }
        Invalidate();
      }
    }

    private FieldLayout nextLayout;

    public void SetNextLayout(FieldLayout layout)
    {
      nextLayout = layout;
      Invalidate();
    }

    public void SetLayouts(FieldLayout layout, FieldLayout newNextLayout)
    {
      nextLayout = newNextLayout;
      SetLayout(layout);
    }

    private int FieldUnitsToDisplayUnits(float fieldUnits)
    {
      return (int)Math.Round(fieldUnits * ratio);
    }

    private float DisplayUnitsToFieldUnits(float displayUnits)
    {
      return displayUnits / ratio;
    }

    private PointF ToFieldPoint(Point pt)
    {
      return new PointF(DisplayUnitsToFieldUnits((float)pt.X - fieldOriginInDisplayUnits.X),
                        DisplayUnitsToFieldUnits((float)pt.Y - fieldOriginInDisplayUnits.Y));
    }

    private Rectangle ToDisplayRect(RectangleF fieldRect)
    {
      Rectangle r = 
        new Rectangle(FieldUnitsToDisplayUnits(fieldRect.X),
                      FieldUnitsToDisplayUnits(fieldRect.Y),
                      FieldUnitsToDisplayUnits(fieldRect.Width),
                      FieldUnitsToDisplayUnits(fieldRect.Height));
      r.Offset(fieldOriginInDisplayUnits.X,
               fieldOriginInDisplayUnits.Y);
      return r;
    }

    private FieldObject ObjectAtPoint(Point pt)
    {
      PointF fieldPoint = ToFieldPoint(pt);
      foreach (FieldObject fo in fieldObjects) {
        if (fo.ContainsPoint(fieldPoint)) {
          return fo;
        }
      }
      return null;
    }

    private void CalculateFieldGeometry(Size windowSize)
    {
      IPlayingSurfaceType ft = FieldType;
      if (null != ft) {
        // Calculate the ratio used to scale "yards" into pixels
        float ratioX = windowSize.Width / (ft.Length + (ft.Margin * 2.0F));
        float ratioY = windowSize.Height / (ft.Width + (ft.Margin * 2.0F));
        ratio = (ratioX < ratioY) ? ratioX : ratioY;

        fieldOriginInDisplayUnits = 
          new Point((windowSize.Width - (int)Math.Round(ft.Length * ratio)) / 2,
                    (windowSize.Height - (int)Math.Round(ft.Width * ratio)) / 2);
      } else {
        ratio = 1.0F;
        fieldOriginInDisplayUnits = new Point(0, 0);
      }
    }

    public void DrawIntoImage(Image image, FieldLayout layoutToDraw, FieldLayout nextLayoutData)
    {
      using (Graphics graphics = Graphics.FromImage(image)) {
        if (image.GetType() == typeof(Bitmap)) {
          Brush brush = null;
          try {
            if (null == FieldType) {
              brush = new SolidBrush(Color.White);
            } else {
              brush = new SolidBrush(this.FieldType.SurfaceColor);
            }
            graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
          } finally {
            if (null != brush) {
              brush.Dispose();
            }
          }
        }
        DrawLayoutIntoGraphics(graphics, layoutToDraw, nextLayoutData);
      }
    }

    private void DrawLayoutIntoGraphics(Graphics g, FieldLayout layoutToDraw, FieldLayout nextLayoutData)
    {
      if (null == FieldType) {
        return;
      }
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      // Adjust the transform to scale the "field units" to display units, and to
      // offset the playing surface so that it is centered in the window.
      // NOTE: The order of these transforms is important.
      g.TranslateTransform(fieldOriginInDisplayUnits.X, fieldOriginInDisplayUnits.Y);
      g.ScaleTransform(ratio, ratio);

      FieldType.DrawMarkings(g);

      // Draw the movement lines that show the movement between the current position and
      // the next position in the sequence (these are drawn first so that they appear under
      // the players)
      if (nextLayoutData != null) {
        foreach (FieldObject fieldObject in fieldObjects) {
          if (nextLayoutData.HasEntry(fieldObject.Tag)) {
            if (null != layoutToDraw) {
              fieldObject.DrawMovementLineFrom(g, layoutToDraw.GetEntryPosition(fieldObject.Tag), nextLayoutData.GetEntryPosition(fieldObject.Tag));
            } else {
              fieldObject.DrawMovementLine(g, nextLayoutData.GetEntryPosition(fieldObject.Tag));
            }
          } // endif
        }
      }

      // Draw each of the field objects
      foreach (FieldObject fieldObject in fieldObjects) {
        if (null != layoutToDraw) {
          fieldObject.DrawAt(g, layoutToDraw.GetEntryPosition(fieldObject.Tag));
        } else {
          fieldObject.Draw(g);
        }
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (null == e) {
        return;
      }
      FieldLayout nextLayoutData = null;
      if (showMovementLines) {
        nextLayoutData = nextLayout;
      }
      DrawLayoutIntoGraphics(e.Graphics, null, nextLayoutData);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      if (null != FieldType) {
        CalculateFieldGeometry(Size);
        Invalidate();
      }
    }

    private void InvalidateFieldArea(RectangleF rect)
    {
      Rectangle r = ToDisplayRect(rect);
      // Make the rectangle slightly bigger to ensure that we invalidate the 
      // entire area of the object, including possible anti-aliasing area.
      r.Inflate(3, 3); 
      Invalidate(r);
    }

    private void MoveObjectTo(FieldObject fo, PointF pos)
    {
      if (fo.Position != pos) {
        if (ShowMovementLines && (null != nextLayout)) {
          RectangleF r = RectangleF.Union(fo.GetRectangle(), fo.GetRectangleAt(nextLayout.GetEntryPosition(fo.Tag)));
          InvalidateFieldArea(r);
        } else {
          InvalidateFieldArea(fo.GetRectangle());
        }
        fo.Position = pos;
        IsDirty = true;
        if (ShowMovementLines && (null != nextLayout)) {
          RectangleF r = RectangleF.Union(fo.GetRectangle(), fo.GetRectangleAt(nextLayout.GetEntryPosition(fo.Tag)));
          InvalidateFieldArea(r);
        } else {
          InvalidateFieldArea(fo.GetRectangle());
        }
        Update();
      }
    }

    private FieldObject dragObject;

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (null == e) {
        return;
      }
      if ((AllowInteraction) && (e.Button == MouseButtons.Left)) {
        FieldObject fo = ObjectAtPoint(e.Location);
        if (fo != null) {
          dragObject = fo;
          Capture = true;
        }
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (null == e) {
        return;
      }
      if ((Capture) && (dragObject != null)) {
        PointF pt = ToFieldPoint(new Point(e.X, e.Y));
        MoveObjectTo(dragObject, pt);
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (null == e) {
        return;
      }
      if ((Capture) && (dragObject != null)) {
        PointF pt = ToFieldPoint(new Point(e.X, e.Y));
        MoveObjectTo(dragObject, pt);
        dragObject = null;
        Capture = false;
      }
    }
  }
}
