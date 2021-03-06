// Sports Tactics Board
//
// http://github.com/manio143/SportsTacticsBoard
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2016 Marian Dziubiak
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
using System.Linq;
using Eto.Drawing;
using SportsTacticsBoard.Resources;

namespace SportsTacticsBoard
{
    public interface ICustomLabelProvider
    {
        string GetCustomLabel(string tag);
        void UpdateCustomLabel(string tag, string label);
        void RemoveCustomLabel(string tag);
    }

    public abstract class FieldObject
    {
        public static ResourceManager ResourceManager;

        public abstract string Tag { get; }
        public abstract string Label { get; }

        public ICustomLabelProvider CustomLabelProvider { get; set; }

        public PointF Position { get; set; }
        private float DisplayRadius { get; }
        public Color FillBrushColor { get; set; } = Colors.White;
        public Color LabelBrushColor { get; set; } = Colors.Black;
        public Color OutlinePenColor { get; set; } = Colors.White;
        public Color MovementPenColor { get; set; } = Colors.White;
        public float OutlinePenWidth { get; set; } = 1.0F;
        public float MovementPenWidth { get; set; } = 3.0F;

        protected virtual float[] MovementPenDashPattern
        {
            get { return null; }
        }

        private SolidBrush LabelBrush
        {
            get { return new SolidBrush(LabelBrushColor); }
        }

        protected virtual int LabelFontSize
        {
            get { return 9; }
        }

        public virtual bool ShowsLabel
        {
            get { return true; }
        }

        private bool HasLabel
        {
            get { return !string.IsNullOrEmpty(LabelText); }
        }

        public virtual string Name
        {
            get
            {
                var propertyName = "FieldObject" + Tag;
                return (string)
                    typeof(LocalizationResource).GetProperties()
                        .First(p => p.Name == propertyName)
                        .GetGetMethod()
                        .Invoke(ResourceManager.LocalizationResource, new object[0]);
            }
        }

        protected FieldObject(float posX, float posY, float dispRadius)
        {
            Position = new PointF(posX, posY);
            DisplayRadius = dispRadius;
        }

        public bool ContainsPoint(PointF pt)
        {
            RectangleF rect = GetRectangle();
            return rect.Contains(pt);
        }

        public RectangleF GetRectangle()
        {
            return GetRectangleAt(Position);
        }

        public RectangleF GetRectangleAt(PointF pos)
        {
            return new RectangleF(pos.X - DisplayRadius,
              pos.Y - DisplayRadius, DisplayRadius * 2, DisplayRadius * 2);
        }

        public void Draw(Graphics graphics)
        {
            DrawAt(graphics, Position);
        }

        protected string LabelText
        {
            get
            {
                if (null == CustomLabelProvider) return Label;
                var customLabel = CustomLabelProvider.GetCustomLabel(Tag);
                return customLabel ?? Label;
            }
        }

        public virtual void DrawAt(Graphics graphics, PointF pos)
        {
            if (null == graphics)
                throw new ArgumentNullException("graphics");

            var rectangle = GetRectangleAt(pos);
            using (var fillBrush = new SolidBrush(FillBrushColor))
                graphics.FillEllipse(fillBrush, rectangle);

            if (OutlinePenWidth > 0.0)
                using (var outlinePen = new Pen(OutlinePenColor, OutlinePenWidth))
                    graphics.DrawEllipse(outlinePen, rectangle);

            if (!HasLabel) return;

            var fontSize = LabelFontSize * rectangle.Height / 18.0F;

            using (var labelFont = new Font("Arial", fontSize, FontStyle.Bold))
            {
                graphics.AntiAlias = true;
                graphics.DrawText(labelFont, LabelBrush, rectangle.Location, LabelText);
            }
        }

        public void DrawMovementLine(Graphics graphics, PointF endPoint)
        {
            DrawMovementLineFrom(graphics, Position, endPoint);
        }

        public void DrawMovementLineFrom(Graphics graphics, PointF startPoint, PointF endPoint)
        {
            if (null == graphics)
                throw new ArgumentNullException("graphics");

            using (Pen movementPen = GetMovementPen())
                graphics.DrawLine(movementPen, startPoint, endPoint);
        }

        private Pen GetMovementPen()
        {
            return new Pen(MovementPenColor, MovementPenWidth)
            {
                DashStyle = new DashStyle(0.1f, MovementPenDashPattern),
                LineCap = PenLineCap.Butt
            };
        }
    }
}
