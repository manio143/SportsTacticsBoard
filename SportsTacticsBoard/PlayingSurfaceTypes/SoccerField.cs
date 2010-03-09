// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2006-2007 Robert Turner
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

namespace SportsTacticsBoard.PlayingSurfaceTypes
{
  /// <summary>
  /// Implements a standard FIFA soccer field.
  /// 
  /// Playing surface units are in yards and the default field 
  /// dimensions are 100 yards by 60 yards. Field is draw to
  /// correct dimensions without any specific compromises.
  /// 
  /// 4 referee field objects are supported for referee training.
  /// </summary>
  class SoccerField : SportsTacticsBoard.IPlayingSurfaceType
  {
    private const float fieldLength = 100.0F;
    private const float fieldWidth = 60.0F;
    private const float margin = 6.5F;
    private const float netDepth = 2.0F;
    private const float linePenWidth = 5.0F / 36.0F;
    private const float goalPenWidth = linePenWidth / 2.0F;
    private const float penaltyMarkRadius = 5.0F / 36.0F;
    private const float penaltyMarkDiameter = penaltyMarkRadius * 2.0F;
    private const float centreTickLength = penaltyMarkRadius;
    private const float playerSize = 1.15F;
    private const float ballSize = 0.75F;
    private const float fieldObjectOutlinePenWidth = 3.0F / 36.0F;
    private const float fieldObjectMovementPenWidth = fieldObjectOutlinePenWidth * 3.0F;
    private const float coneSize = 0.50F;

    private const int playersPerTeam = 11;

    public float Length
    {
      get { return fieldLength; }
    }

    public float Width
    {
      get { return fieldWidth; }
    }

    public float Margin
    {
      get { return margin; }
    }

    public Color SurfaceColor
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

    public Collection<FieldObject> StandardObjects
    {
      get
      {
        List<FieldObject> fieldObjects = new List<FieldObject>();

        // Create the players
        for (int i = 1; i <= playersPerTeam; i++) {
          fieldObjects.Add(new FieldObjects.NumberedPlayer(i, FieldObjects.Player.TeamId.Attacking, playerSize));
          fieldObjects.Add(new FieldObjects.NumberedPlayer(i, FieldObjects.Player.TeamId.Defending, playerSize));
        }

        // Add the ball
        fieldObjects.Add(new FieldObjects.Ball(Length / 2, Width / 2, ballSize));

        // Add the referees
        fieldObjects.Add(new FieldObjects.Referee("CR", "Referee_Soccer_CR", (Length / 2F) + 5.0F, (Width / 2F) + 5.0F, playerSize));
        fieldObjects.Add(new FieldObjects.Referee("AR", "Referee_Soccer_AR1", Length / 4F, -2.0F, playerSize));
        fieldObjects.Add(new FieldObjects.Referee("AR", "Referee_Soccer_AR2", Length * 3.0F / 4.0F, Width + 2.0F, playerSize));
        fieldObjects.Add(new FieldObjects.Referee("4", "Referee_Soccer_4th", Length / 2.0F, Width + 3.0F, playerSize));

        // Add some cones
        const int NumberOfCones = 20;
        var xPosition = (Length / 2) - ((NumberOfCones * coneSize * 3F) / 2F);
        var yPosition = -5.0F;
        for (int coneNumber = 1; (coneNumber <= NumberOfCones); coneNumber++, xPosition += (coneSize * 3)) {
          fieldObjects.Add(new FieldObjects.UnlabelledTriangularCone(coneNumber, xPosition, yPosition, coneSize));
        }

        // Adjust various parameters for all the field objects
        foreach (FieldObject fo in fieldObjects) {
          fo.OutlinePenWidth = fieldObjectOutlinePenWidth;
          fo.MovementPenWidth = fieldObjectMovementPenWidth;
        }

        return new Collection<FieldObject>(fieldObjects);
      }
    }

    private void AppendPlayerPositions(FieldLayout layout, FieldObjects.Player.TeamId teamId, bool putOnLeftSide)
    {
      const float spacing = 3.25F;
      const float benchIndent = 5.0F;
      const float benchDistanceFromField = 5.25F;

      float benchY = Width + benchDistanceFromField;
      float benchStartPos = benchIndent;
      if (!putOnLeftSide) {
        benchStartPos += Length / 2.0F;
      }

      for (int playerNumber = 1; playerNumber <= playersPerTeam; playerNumber++) {
        string playerTag = FieldObjects.NumberedPlayer.ComposeTag(teamId, playerNumber);
        layout.AddEntry(playerTag, benchStartPos + (spacing * playerNumber), benchY);
      }
    }

    public FieldLayout DefaultLayout
    {
      get
      {
        FieldLayout layout = new FieldLayout();
        AppendPlayerPositions(layout, SportsTacticsBoard.FieldObjects.Player.TeamId.Attacking, true);
        AppendPlayerPositions(layout, SportsTacticsBoard.FieldObjects.Player.TeamId.Defending, false);
        return layout;
      }
    }

    public ReadOnlyCollection<string> GetTeam(FieldObjects.Player.TeamId team)
    {
      List<string> playersOnTeam = new List<string>();
      for (int i = 1; i <= playersPerTeam; i++) {
        playersOnTeam.Add(FieldObjects.NumberedPlayer.ComposeTag(team, i));
      }
      return new ReadOnlyCollection<string>(playersOnTeam);
    }

    public virtual void DrawMarkings(Graphics graphics)
    {
      // Create the pens for drawing the field lines with
      Pen linePen = new Pen(Color.White, linePenWidth);
      Pen goalPen = new Pen(Color.White, goalPenWidth);

      // Draw the lines on the field

      // ... The goal and touch lines
      graphics.DrawRectangle(linePen, 0.0F, 0.0F, Length, Width);

      #region Draw the centre line
      // ... The centre line
      PointF fieldCentre = new PointF(Length / 2, Width / 2);
      PointF centreLineTop = new PointF(fieldCentre.X, 0.0F);
      PointF centreLineBottom = new PointF(fieldCentre.X, Width);
      graphics.DrawLine(linePen, centreLineTop, centreLineBottom);
      // ......The 'tick' across the centre line for the kick-off spot
      graphics.DrawLine(linePen, fieldCentre.X - centreTickLength, fieldCentre.Y, fieldCentre.X + centreTickLength, fieldCentre.Y);
      #endregion

      #region Draw the centre circle
      // ... The centre circle
      float centreCircleDiameter = 20.0F;
      RectangleF centreCircleRect = new RectangleF(fieldCentre.X - (centreCircleDiameter / 2), fieldCentre.Y - (centreCircleDiameter / 2), centreCircleDiameter, centreCircleDiameter);
      graphics.DrawEllipse(linePen, centreCircleRect);
      #endregion

      #region Draw the goals
      // ... The goals
      float goalWidthInPixels = netDepth;
      float goalHeightInPixels = 8.0F;
      RectangleF leftGoal = new RectangleF(0.0F - goalWidthInPixels, fieldCentre.Y - (goalHeightInPixels / 2),
        goalWidthInPixels, goalHeightInPixels);
      RectangleF rightGoal = new RectangleF(Length, fieldCentre.Y - (goalHeightInPixels / 2),
        goalWidthInPixels, goalHeightInPixels);
      graphics.DrawRectangle(goalPen, leftGoal.X, leftGoal.Y, leftGoal.Width, leftGoal.Height);
      graphics.DrawRectangle(goalPen, rightGoal.X, rightGoal.Y, rightGoal.Width, rightGoal.Height);
      #endregion

      #region Draw the goal areas (6-yard boxes)
      // ... The 6 yard boxes
      float widthOf6YardBoxInPixels = 6.0F;
      float heightOf6YardBoxInPixels = 6.0F * 2.0F + 8.0F;
      float halfHeightOf6YardBoxInPixels = 6.0F + 4.0F;
      RectangleF leftSide6YardBox = new RectangleF(0.0F, fieldCentre.Y - halfHeightOf6YardBoxInPixels,
        widthOf6YardBoxInPixels, heightOf6YardBoxInPixels);
      RectangleF rightSide6YardBox = new RectangleF(Length - widthOf6YardBoxInPixels, fieldCentre.Y - halfHeightOf6YardBoxInPixels,
        widthOf6YardBoxInPixels, heightOf6YardBoxInPixels);
      graphics.DrawRectangle(linePen, leftSide6YardBox.X, leftSide6YardBox.Y, leftSide6YardBox.Width, leftSide6YardBox.Height);
      graphics.DrawRectangle(linePen, rightSide6YardBox.X, rightSide6YardBox.Y, rightSide6YardBox.Width, rightSide6YardBox.Height);
      #endregion

      #region Draw the penalty areas (18-yard boxes)
      // ... The 18 yard boxes
      float widthOf18YardBoxInPixels = 18.0F;
      float heightOf18YardBoxInPixels = 18.0F * 2.0F + 8.0F;
      float halfHeightOf18YardBoxInPixels = 18.0F + 4.0F;
      RectangleF leftSide18YardBox = new RectangleF(0.0F, fieldCentre.Y - halfHeightOf18YardBoxInPixels,
        widthOf18YardBoxInPixels, heightOf18YardBoxInPixels);
      RectangleF rightSide18YardBox = new RectangleF(Length - widthOf18YardBoxInPixels, fieldCentre.Y - halfHeightOf18YardBoxInPixels,
        widthOf18YardBoxInPixels, heightOf18YardBoxInPixels);
      graphics.DrawRectangle(linePen, leftSide18YardBox.X, leftSide18YardBox.Y, leftSide18YardBox.Width, leftSide18YardBox.Height);
      graphics.DrawRectangle(linePen, rightSide18YardBox.X, rightSide18YardBox.Y, rightSide18YardBox.Width, rightSide18YardBox.Height);
      #endregion

      #region Draw penalty marks
      // ... The penalty marks
      RectangleF leftPenaltyMark = new RectangleF(0.0F + 12.0F - penaltyMarkRadius, fieldCentre.Y - penaltyMarkRadius, penaltyMarkDiameter, penaltyMarkDiameter);
      RectangleF rightPenaltyMark = new RectangleF(Length - 12.0F - penaltyMarkRadius, fieldCentre.Y - penaltyMarkRadius, penaltyMarkDiameter, penaltyMarkDiameter);
      graphics.DrawEllipse(linePen, leftPenaltyMark);
      graphics.DrawEllipse(linePen, rightPenaltyMark);
      #endregion

      #region Draw the "Ds" at the top of the penalty boxes
      // ... The Ds
      Region oldClip = graphics.Clip;
      Region penaltyBoxExcludeRegion = new Region(leftSide18YardBox);
      penaltyBoxExcludeRegion.Union(rightSide18YardBox);
      graphics.ExcludeClip(penaltyBoxExcludeRegion);
      float dRadiusInPixels = 10.0F;
      float dDiameterInPixels = 20.0F;
      RectangleF leftDRectangle = new RectangleF(leftPenaltyMark.Left - dRadiusInPixels,
        leftPenaltyMark.Top - dRadiusInPixels, dDiameterInPixels, dDiameterInPixels);
      RectangleF rightDRectangle = new RectangleF(rightPenaltyMark.Left - dRadiusInPixels,
        rightPenaltyMark.Top - dRadiusInPixels, dDiameterInPixels, dDiameterInPixels);
      graphics.DrawEllipse(linePen, leftDRectangle);
      graphics.DrawEllipse(linePen, rightDRectangle);
      graphics.Clip = oldClip;
      #endregion

      #region Draw the corner arcs
      // ... The corner arcs
      float cornerArcDiameterInPixels = 2.0F;
      float cornerArcRadiusInPixels = 1.0F;
      RectangleF topLeftCornerArc = new RectangleF(0.0F - cornerArcRadiusInPixels,
        0.0F - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      RectangleF topRightCornerArc = new RectangleF(Length - cornerArcRadiusInPixels,
        0.0F - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      RectangleF bottomLeftCornerArc = new RectangleF(0.0F - cornerArcRadiusInPixels,
        Width - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      RectangleF bottomRightCornerArc = new RectangleF(Length - cornerArcRadiusInPixels,
        Width - cornerArcRadiusInPixels, cornerArcDiameterInPixels, cornerArcDiameterInPixels);
      graphics.DrawArc(linePen, topLeftCornerArc, 0.0F, 90.0F);
      graphics.DrawArc(linePen, topRightCornerArc, 90.0F, 90.0F);
      graphics.DrawArc(linePen, bottomLeftCornerArc, 270.0F, 90.0F);
      graphics.DrawArc(linePen, bottomRightCornerArc, 180.0F, 90.0F);
      #endregion

      // Release resources
      linePen.Dispose();
      goalPen.Dispose();
      penaltyBoxExcludeRegion.Dispose();
    }
  }
}
