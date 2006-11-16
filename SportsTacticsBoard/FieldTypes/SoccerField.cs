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
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SportsTacticsBoard.FieldTypes
{
  class SoccerField : SportsTacticsBoard.IFieldType
  {
    private const float fieldLength = 100.0F;
    private const float fieldWidth = 60.0F;
    private const float margin = 6.5F;
    private const float netDepth = 2.0F;
    private const int linePenWidth = 2;
    private const int goalPenWidth = 1;
    private const int playersPerTeam = 11;

    public float FieldLength
    {
      get { return fieldLength; }
    }

    public float FieldWidth
    {
      get { return fieldWidth; }
    }

    public float Margin
    {
      get { return margin; }
    }

    public Color FieldSurfaceColor
    {
      get { return Color.Green; }
    }

    public string Tag
    {
      get { return "Soccer"; }
    }

    public string Name
    {
      get {
        return Properties.Resources.ResourceManager.GetString("FieldType_" + Tag);
      }
    }

    public Collection<FieldObject> StandardFieldObjects
    {
      get
      {
        List<FieldObject> fieldObjects = new List<FieldObject>();

        // Create the players
        for (int i = 1; i <= playersPerTeam; i++) {
          fieldObjects.Add(new FieldObjects.Player(i, FieldObjects.Player.TeamId.Attacking, 0.0F, 0.0F));
          fieldObjects.Add(new FieldObjects.Player(i, FieldObjects.Player.TeamId.Defending, 0.0F, 0.0F));
        }

        // Add the ball
        fieldObjects.Add(new FieldObjects.Ball(FieldLength / 2, FieldWidth / 2));

        // Add the referees
        fieldObjects.Add(new FieldObjects.Referee("CR", "Referee_Soccer_CR", (FieldLength / 2F) + 5.0F, (FieldWidth / 2F) + 5.0F));
        fieldObjects.Add(new FieldObjects.Referee("AR", "Referee_Soccer_AR1", FieldLength / 4F, -2.0F));
        fieldObjects.Add(new FieldObjects.Referee("AR", "Referee_Soccer_AR2", FieldLength * 3.0F / 4.0F, FieldWidth + 2.0F));
        fieldObjects.Add(new FieldObjects.Referee("4", "Referee_Soccer_4th", FieldLength / 2.0F, FieldWidth + 3.0F));

        return new Collection<FieldObject>(fieldObjects);
      }
    }

    public FieldObjectLayout DefaultLayout
    {
      get
      {
        LayoutAlgorithms.BenchLayoutAlgorithm defaultLayoutAlgorithm = new LayoutAlgorithms.BenchLayoutAlgorithm(this);
        return defaultLayoutAlgorithm.GetLayout(this);
      }
    }

    public ReadOnlyCollection<string> GetTeam(FieldObjects.Player.TeamId team)
    {
      List<string> playersOnTeam = new List<string>();
      for (int i = 1; i <= playersPerTeam; i++) {
        playersOnTeam.Add(FieldObjects.Player.ComposeTag(team, i));
      }
      return new ReadOnlyCollection<string>(playersOnTeam);
    }

    public virtual void DrawFieldMarkings(Graphics graphics, Rectangle fieldRectangle, FieldUnitToPixelConverter conversionDelegateWithNoOffset)
    {
      // Create the pens for drawing the field lines with
      Pen linePen = new Pen(Color.White, linePenWidth);
      Pen goalPen = new Pen(Color.White, goalPenWidth);

      // Draw the lines on the field

      // ... The goal and touch lines
      graphics.DrawRectangle(linePen, fieldRectangle);

      // ... The centre line
      Point fieldCentre = new Point(fieldRectangle.Left + (fieldRectangle.Width / 2),
        fieldRectangle.Top + (fieldRectangle.Height / 2));
      Point centreLineTop = new Point(fieldCentre.X, fieldRectangle.Top);
      Point centreLineBottom = new Point(fieldCentre.X, fieldRectangle.Bottom);
      graphics.DrawLine(linePen, centreLineTop, centreLineBottom);
      graphics.DrawLine(linePen, fieldCentre.X - 3, fieldCentre.Y, fieldCentre.X + 3, fieldCentre.Y);

      // ... The centre circle
      int centreCircleDiameter = conversionDelegateWithNoOffset(20.0F);
      Rectangle centreCircleRect = new Rectangle(fieldCentre.X - (centreCircleDiameter / 2), fieldCentre.Y - (centreCircleDiameter / 2), centreCircleDiameter, centreCircleDiameter);
      graphics.DrawEllipse(linePen, centreCircleRect);

      // ... The goals
      int goalWidthInPixels = conversionDelegateWithNoOffset(netDepth);
      int goalHeightInPixels = conversionDelegateWithNoOffset(8.0F);
      Rectangle leftGoal = new Rectangle(fieldRectangle.Left - goalWidthInPixels, fieldCentre.Y - (goalHeightInPixels / 2),
        goalWidthInPixels, goalHeightInPixels);
      Rectangle rightGoal = new Rectangle(fieldRectangle.Right, fieldCentre.Y - (goalHeightInPixels / 2),
        goalWidthInPixels, goalHeightInPixels);
      graphics.DrawRectangle(goalPen, leftGoal);
      graphics.DrawRectangle(goalPen, rightGoal);

      // ... The 6 yard boxes
      int widthOf6YardBoxInPixels = conversionDelegateWithNoOffset(6.0F);
      int heightOf6YardBoxInPixels = conversionDelegateWithNoOffset(6.0F * 2.0F + 8.0F);
      int halfHeightOf6YardBoxInPixels = conversionDelegateWithNoOffset(6.0F + 4.0F);
      Rectangle leftSide6YardBox = new Rectangle(fieldRectangle.Left, fieldCentre.Y - halfHeightOf6YardBoxInPixels,
        widthOf6YardBoxInPixels, heightOf6YardBoxInPixels);
      Rectangle rightSide6YardBox = new Rectangle(fieldRectangle.Right - widthOf6YardBoxInPixels, fieldCentre.Y - halfHeightOf6YardBoxInPixels,
        widthOf6YardBoxInPixels, heightOf6YardBoxInPixels);
      graphics.DrawRectangle(linePen, leftSide6YardBox);
      graphics.DrawRectangle(linePen, rightSide6YardBox);

      // ... The 18 yard boxes
      int widthOf18YardBoxInPixels = conversionDelegateWithNoOffset(18.0F);
      int heightOf18YardBoxInPixels = conversionDelegateWithNoOffset(18.0F * 2.0F + 8.0F);
      int halfHeightOf18YardBoxInPixels = conversionDelegateWithNoOffset(18.0F + 4.0F);
      Rectangle leftSide18YardBox = new Rectangle(fieldRectangle.Left, fieldCentre.Y - halfHeightOf18YardBoxInPixels,
        widthOf18YardBoxInPixels, heightOf18YardBoxInPixels);
      Rectangle rightSide18YardBox = new Rectangle(fieldRectangle.Right - widthOf18YardBoxInPixels, fieldCentre.Y - halfHeightOf18YardBoxInPixels,
        widthOf18YardBoxInPixels, heightOf18YardBoxInPixels);
      graphics.DrawRectangle(linePen, leftSide18YardBox);
      graphics.DrawRectangle(linePen, rightSide18YardBox);

      // ... The penalty marks
      Rectangle leftPenaltyMark = new Rectangle(fieldRectangle.Left + conversionDelegateWithNoOffset(12.0F), fieldCentre.Y, 1, 1);
      Rectangle rightPenaltyMark = new Rectangle(fieldRectangle.Right - conversionDelegateWithNoOffset(12.0F), fieldCentre.Y, 1, 1);
      graphics.DrawEllipse(linePen, leftPenaltyMark);
      graphics.DrawEllipse(linePen, rightPenaltyMark);

      // ... The D's
      Region oldClip = graphics.Clip;
      graphics.ExcludeClip(leftSide18YardBox);
      graphics.ExcludeClip(rightSide18YardBox);
      int dRadiusInPixels = conversionDelegateWithNoOffset(10.0F);
      int dDiameterInPixels = conversionDelegateWithNoOffset(20.0F);
      Rectangle leftDRectangle = new Rectangle(leftPenaltyMark.Left - dRadiusInPixels,
        leftPenaltyMark.Top - dRadiusInPixels, dDiameterInPixels, dDiameterInPixels);
      Rectangle rightDRectangle = new Rectangle(rightPenaltyMark.Left - dRadiusInPixels,
        rightPenaltyMark.Top - dRadiusInPixels, dDiameterInPixels, dDiameterInPixels);
      graphics.DrawEllipse(linePen, leftDRectangle);
      graphics.DrawEllipse(linePen, rightDRectangle);
      graphics.Clip = oldClip;

      // ... The corner arcs
      int cornerArcDiameterInPixels = conversionDelegateWithNoOffset(2.0F);
      int cornerArcRadiusInPixels = conversionDelegateWithNoOffset(1.0F);
      Rectangle topLeftCornerArc = new Rectangle(fieldRectangle.Left - cornerArcRadiusInPixels,
        fieldRectangle.Top - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      Rectangle topRightCornerArc = new Rectangle(fieldRectangle.Right - cornerArcRadiusInPixels,
        fieldRectangle.Top - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      Rectangle bottomLeftCornerArc = new Rectangle(fieldRectangle.Left - cornerArcRadiusInPixels,
        fieldRectangle.Bottom - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      Rectangle bottomRightCornerArc = new Rectangle(fieldRectangle.Right - cornerArcRadiusInPixels,
        fieldRectangle.Bottom - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      graphics.DrawArc(linePen, topLeftCornerArc, 0.0F, 90.0F);
      graphics.DrawArc(linePen, topRightCornerArc, 90.0F, 90.0F);
      graphics.DrawArc(linePen, bottomLeftCornerArc, 270.0F, 90.0F);
      graphics.DrawArc(linePen, bottomRightCornerArc, 180.0F, 90.0F);
    }
  }
}
