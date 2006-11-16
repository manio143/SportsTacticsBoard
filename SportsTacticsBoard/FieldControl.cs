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
    private Rectangle fieldRectangle;
    private bool dirty;
    private IFieldType fieldType;

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
        Refresh();
      }
    }

    public FieldControl()
    {
      InitializeComponent();
    }

    public IFieldType FieldType
    {
      set
      {
        nextLayout = null;
        fieldObjects = null;

        fieldType = value;
        if (null != fieldType) {
          BackColor = fieldType.FieldSurfaceColor;
          CalculateFieldGeometry(Size);
          fieldObjects = fieldType.StandardFieldObjects;
          SetLayout(fieldType.DefaultLayout);
        }

        Invalidate();
        Refresh();
      }
      get { return fieldType; }
    }

    private Collection<FieldObject> fieldObjects;

    public FieldObjectLayout FieldLayout
    {
      get
      {
        FieldObjectLayout layout = new FieldObjectLayout();
        foreach (FieldObject fo in fieldObjects) {
          layout.AddEntry(fo.Tag, fo.Position);
        }
        return layout;
      }
    }

    public void SetLayout(FieldObjectLayout layout)
    {
      if (null != layout) {
        foreach (FieldObject fo in fieldObjects) {
          if (layout.HasEntry(fo.Tag)) {
            fo.Position = layout.GetEntryPosition(fo.Tag);
            IsDirty = true;
          }
        }
        Invalidate();
        Refresh();
      }
    }

    private FieldObjectLayout nextLayout;

    public void SetNextLayout(FieldObjectLayout layout)
    {
      nextLayout = layout;
      Invalidate();
      Refresh();
    }

    public void SetLayouts(FieldObjectLayout layout, FieldObjectLayout newNextLayout)
    {
      nextLayout = newNextLayout;
      SetLayout(layout);
    }

    internal void ApplyLayoutAlgorithm(ILayoutAlgorithm layoutAlgorithm)
    {
      if (null != FieldType) {
        SetLayout(layoutAlgorithm.GetLayout(FieldType));
      }
    }

    private int YardsToPixelsNoOffset(float yards)
    {
      return (int)(yards * ratio);
    }

    private float PixelsToYardsNoOffset(int pixels)
    {
      return (float)pixels / ratio;
    }

    private Point ToFieldPoint(Point pt)
    {
      return new Point(pt.X - fieldRectangle.Left, pt.Y - fieldRectangle.Top);
    }

    private FieldObject ObjectAtPoint(Point pt)
    {
      Point fieldPoint = ToFieldPoint(pt);
      FieldUnitToPixelConverter cd = new FieldUnitToPixelConverter(YardsToPixelsNoOffset);
      foreach (FieldObject fo in fieldObjects) {
        if (fo.ContainsPoint(fieldPoint, cd)) {
          return fo;
        }
      }
      return null;
    }

    private void CalculateFieldGeometry(Size windowSize)
    {
      IFieldType ft = FieldType;
      if (null != ft) {
        // Calculate the ratio used to scale "yards" into pixels
        float ratioX = windowSize.Width / (ft.FieldLength + (ft.Margin * 2.0F));
        float ratioY = windowSize.Height / (ft.FieldWidth + (ft.Margin * 2.0F));
        ratio = (ratioX < ratioY) ? ratioX : ratioY;

        // Calculate the rectangle for the field
        int fieldLengthInPixels = YardsToPixelsNoOffset(ft.FieldLength);
        int fieldWidthInPixels = YardsToPixelsNoOffset(ft.FieldWidth);
        fieldRectangle =
          new Rectangle((windowSize.Width - (fieldLengthInPixels)) / 2,
                        (windowSize.Height - (fieldWidthInPixels)) / 2,
                        fieldLengthInPixels,
                        fieldWidthInPixels);
      } else {
        ratio = 1.0F;
        fieldRectangle = new Rectangle(0, 0, 0, 0);
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (null == FieldType) {
        return;
      }

      e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      FieldType.DrawFieldMarkings(e.Graphics, fieldRectangle, new FieldUnitToPixelConverter(YardsToPixelsNoOffset));

      // Adjust the origin so that all field objects are drawn with respect to the topleft of the field
      e.Graphics.TranslateTransform(fieldRectangle.X, fieldRectangle.Y);

      // Draw the movement lines that show the movement between the current position and
      // the next position in the sequence (these are drawn first so that they appear under
      // the players)
      if ((showMovementLines) && (nextLayout != null)) {
        foreach (FieldObject fieldObject in fieldObjects) {
          if (nextLayout.HasEntry(fieldObject.Tag)) {
            fieldObject.DrawMovementLine(e.Graphics, 
                                         new FieldUnitToPixelConverter(YardsToPixelsNoOffset), 
                                         nextLayout.GetEntryPosition(fieldObject.Tag));
          } // endif
        }
      }

      // Draw each of the field objects
      foreach (FieldObject fieldObject in fieldObjects) {
        fieldObject.Draw(e.Graphics, new FieldUnitToPixelConverter(YardsToPixelsNoOffset));
      }
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      if (null != FieldType) {
        CalculateFieldGeometry(Size);
        Invalidate();
      }
    }

    private void MoveObjectTo(FieldObject fo, PointF pos)
    {
      if (fo.Position != pos) {
        FieldUnitToPixelConverter cd = new FieldUnitToPixelConverter(YardsToPixelsNoOffset);
        Rectangle oldRect = fo.GetRectangle(cd);
        fo.Position = pos;
        IsDirty = true;
        Rectangle newRect = fo.GetRectangle(cd);
        Invalidate(oldRect);
        Invalidate(newRect);
        Refresh();
      }
    }

    private FieldObject dragObject;

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left) {
        FieldObject fo = ObjectAtPoint(e.Location);
        if (fo != null) {
          dragObject = fo;
          Capture = true;
        }
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if ((Capture) && (dragObject != null)) {
        PointF pt = new PointF(PixelsToYardsNoOffset(e.X - fieldRectangle.Left), PixelsToYardsNoOffset(e.Y - fieldRectangle.Top));
        MoveObjectTo(dragObject, pt);
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if ((Capture) && (dragObject != null)) {
        PointF pt = new PointF(PixelsToYardsNoOffset(e.X - fieldRectangle.Left), PixelsToYardsNoOffset(e.Y - fieldRectangle.Top));
        MoveObjectTo(dragObject, pt);
        dragObject = null;
        Capture = false;
      }
    }
  }
}
