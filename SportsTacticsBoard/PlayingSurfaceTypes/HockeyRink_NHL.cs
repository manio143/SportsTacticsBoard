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
  /// Implements a standard NHL Ice Hockey rink.
  /// 
  /// Hockey rink dimensions and details taken from: 
  ///   http://en.wikipedia.org/wiki/Hockey_rink
  /// Along with information from the official NHL 
  /// rules (2006 season).
  /// 
  /// Playing surface units are in feet. A few compromises
  /// have been made to simplify drawing:
  ///   - Goals are not not drawn precisely as described in the rules.
  ///   - Face off spots do not have the correct circle with a stripe, 
  ///     instead they are drawn as a solid circle.
  ///   - The centre line is draw solid rather than dashed.
  ///   - Goal crease "tick marks" are missing.
  /// </summary>
  class HockeyRink_NHL : IPlayingSurfaceType
  {
    // NHL hockey rink units are in feet (or inches)
    private const float rinkLength        = 200.0F;
    private const float rinkWidth         = 85.0F;
    private const float margin            = 5.0F;
    private const float boardsPenWidth    = 0.5F;         // 6 inches
    private const float thickLinePenWidth = 1.0F;         // 1 foot
    private const float thinLinePenWidth  = 2.0F / 12.0F; // 2 inches
    private const float cornerRadiusOfBoards = 28.0F;
    private const float centreFaceOffSpotDiameter = 1.0F;
    private const float faceOffSpotDiameter = 2.0F;
    private const float faceOffCircleRadius = 15.0F;
    private const float distanceOfGoalLineFromEndOfRink = 11.0F;
    private const float distanceOfBlueLineFromEndOfRink = distanceOfGoalLineFromEndOfRink + 64.0F;
    private const float distanceOfFaceOffSpotsFromCentreOfRink = 22.0F;
    private const float distanceOfNeutralZoneFaceOffSpotsFromEndOfRink = distanceOfBlueLineFromEndOfRink + 5.0F;
    private const float distanceOfZoneFaceOffAreasFromEndOfRink = distanceOfGoalLineFromEndOfRink + 20.0F;
    private const float innerHashDistanceFromCentreX = 2.0F;
    private const float innerHashDistanceFromCentreY = 0.75F; // (half of 1 foot 6 inches)
    private const float innerHashLengthX  = 4.0F;
    private const float innerHashLengthY  = 3.0F;
    private const float outerHashLengthY  = 2.0F;
    private const float refereesCreaseRadius = 10.0F;
    private const float playerBenchWidth  = 38.0F;
    private const float playerBenchDepth  = 6.25F;
    private const float penaltyBoxWidth   = 12.5F;
    private const float penaltyBoxDepth   = playerBenchDepth;
    private const float goalWidth         = 6.0F;
    private const float goalDepth         = 44.0F / 12.0F; // 44 inches
    private const float trapezoidDistanceFromGoalPosts = 6.0F;
    private const float trapezoidBaseWidth = 28.0F;
    private const float trapezoidOffsetFromCentre = trapezoidDistanceFromGoalPosts + (goalWidth / 2.0F);
    private const float creaseWidth       = goalWidth + (1.0F * 2.0F);
    private const float creaseArcRadius   = 6.0F;
    private const float createEdgeLength  = 4.5F;
    private const float playerSize        = 2.5F;
    private const float puckSize          = 0.7F;
    private const float fieldObjectOutlinePenWidth = 3.0F / 12.0F;
    private const float fieldObjectMovementPenWidth = fieldObjectOutlinePenWidth * 3.0F;

    private const int playersPerTeam = 5;

    public string Tag
    {
      get {
        return "Hockey_NHL";
      }
    }

    public string Name
    { 
      get {
        return Properties.Resources.ResourceManager.GetString("FieldType_" + Tag);
      } 
    }

    public float Length
    {
      get { return rinkLength; }
    }

    public float Width {
      get { return rinkWidth; }
    }

    public float Margin
    {
      get { return margin; }
    }

    public Color SurfaceColor
    {
      get { return Color.LightGray; } 
    }

    private static void CreateTeam(ref List<FieldObject> fieldObjects, FieldObjects.Player.TeamId team) {
      fieldObjects.Add(new FieldObjects.LabelledPlayer("LW", team, playerSize));
      fieldObjects.Add(new FieldObjects.LabelledPlayer("C", team, playerSize));
      fieldObjects.Add(new FieldObjects.LabelledPlayer("RW", team, playerSize));
      fieldObjects.Add(new FieldObjects.LabelledPlayer("LD", team, playerSize));
      fieldObjects.Add(new FieldObjects.LabelledPlayer("RD", team, playerSize));
      fieldObjects.Add(new FieldObjects.LabelledPlayer("G", team, playerSize));
    }

    public Collection<FieldObject> StandardObjects
    {
      get {
        List<FieldObject> fieldObjects = new List<FieldObject>();

        CreateTeam(ref fieldObjects, SportsTacticsBoard.FieldObjects.Player.TeamId.Attacking);
        CreateTeam(ref fieldObjects, SportsTacticsBoard.FieldObjects.Player.TeamId.Defending);

        // Add the puck
        fieldObjects.Add(new FieldObjects.Puck(Length / 2, Width / 2, puckSize));

        // Add the referees
        fieldObjects.Add(new FieldObjects.Referee("R1", "Referee_Hockey_1", distanceOfBlueLineFromEndOfRink - 10.0F, Width - 7.5F, playerSize));
        fieldObjects.Add(new FieldObjects.Referee("R2", "Referee_Hockey_2", Length - distanceOfBlueLineFromEndOfRink + 10.0F, 7.5F, playerSize));
        fieldObjects.Add(new FieldObjects.Referee("L1", "Referee_Hockey_L1", distanceOfBlueLineFromEndOfRink - 3.0F, 2.75F, playerSize));
        fieldObjects.Add(new FieldObjects.Referee("L2", "Referee_Hockey_L2", Length - distanceOfBlueLineFromEndOfRink + 3.0F, Width - 2.75F, playerSize));

        // Adjust various parameters for all the field objects
        foreach (FieldObject fo in fieldObjects) {
          fo.OutlinePenWidth = fieldObjectOutlinePenWidth;
          fo.MovementPenWidth = fieldObjectMovementPenWidth;
          fo.OutlinePenColor = Color.Black;
        }

        return new Collection<FieldObject>(fieldObjects);
      }
    }

    public Layout DefaultLayout
    { 
      get {
        Layout layout = new Layout();
        layout.AddEntry("Player_Attacking_G", distanceOfGoalLineFromEndOfRink + playerSize, Width / 2.0F);
        layout.AddEntry("Player_Attacking_LD", distanceOfBlueLineFromEndOfRink + 3.0F, Width / 3.0F);
        layout.AddEntry("Player_Attacking_RD", distanceOfBlueLineFromEndOfRink + 3.0F, 2.0F * (Width / 3.0F));
        layout.AddEntry("Player_Attacking_LW", (Length / 2.0F) - playerSize, (Width / 2.0F) - faceOffCircleRadius - playerSize);
        layout.AddEntry("Player_Attacking_C", (Length / 2.0F) - playerSize, (Width / 2.0F));
        layout.AddEntry("Player_Attacking_RW", (Length / 2.0F) - playerSize, (Width / 2.0F) + faceOffCircleRadius + playerSize);
        layout.AddEntry("Player_Defending_G", Length - (distanceOfGoalLineFromEndOfRink + playerSize), Width / 2.0F);
        layout.AddEntry("Player_Defending_RD", Length - (distanceOfBlueLineFromEndOfRink + 3.0F), Width / 3.0F);
        layout.AddEntry("Player_Defending_LD", Length - (distanceOfBlueLineFromEndOfRink + 3.0F), 2.0F * (Width / 3.0F));
        layout.AddEntry("Player_Defending_RW", (Length / 2.0F) + playerSize, (Width / 2.0F) - faceOffCircleRadius - playerSize);
        layout.AddEntry("Player_Defending_C", (Length / 2.0F) + playerSize, (Width / 2.0F));
        layout.AddEntry("Player_Defending_LW", (Length / 2.0F) + playerSize, (Width / 2.0F) + faceOffCircleRadius + playerSize);
        return layout;
      } 
    }

    public ReadOnlyCollection<string> GetTeam(FieldObjects.Player.TeamId team)
    {
      List<string> t = new List<string>();
      
      // TODO: Fill in the list of players on the specified team

      return new ReadOnlyCollection<string>(t);
    }

    // NHL rink paint colors are specified as Pantone colors.
    // Pantone colors matched using: http://www.logoorange.com/color/color-codes-chart.php
    private Color pms286 = Color.FromArgb(0xff, 0x00, 0x55, 0xfa); // blue lines
    private Color pms186 = Color.FromArgb(0xff, 0xf5, 0x00, 0x2f); // red lines
    private Color pms298 = Color.FromArgb(0xff, 0x4f, 0xed, 0xff); // goal crease

    private static void DrawFaceOffSpot(Graphics g, PointF position, Brush brush, float diameter, bool solid)
    {
      float radius = diameter / 2.0F;
      if (solid) {
        g.FillEllipse(brush,
                      position.X - radius,
                      position.Y - radius,
                      diameter,
                      diameter);
      } else {
        // TODO: Draw this properly (as per NHL standards - as a circle with a thick vertical line through it)
        g.FillEllipse(brush,
                      position.X - radius,
                      position.Y - radius,
                      diameter,
                      diameter);
      }
    }

    private static void DrawFaceOffArea(Graphics g, PointF position, Brush spotBrush, Pen linePen)
    {
      DrawFaceOffSpot(g, position, spotBrush, faceOffSpotDiameter, false);

      // Draw the hash marks around the spot
      PointF pos = position;
      float halfOfThinLineWidth = thinLinePenWidth / 2.0F;
      float xDistanceFromCentreOnArea = innerHashDistanceFromCentreX + halfOfThinLineWidth;
      float yDistanceFromCentreOnArea = innerHashDistanceFromCentreY + halfOfThinLineWidth;
      float xLength = innerHashLengthX - halfOfThinLineWidth;
      float yLength = innerHashLengthY - halfOfThinLineWidth;
      g.DrawLines(linePen, 
                  new PointF[] { 
                    new PointF(pos.X + xDistanceFromCentreOnArea, 
                               pos.Y + yDistanceFromCentreOnArea + yLength), 
                    new PointF(pos.X + xDistanceFromCentreOnArea, 
                               pos.Y + yDistanceFromCentreOnArea),
                    new PointF(pos.X + xDistanceFromCentreOnArea + xLength, 
                               pos.Y + yDistanceFromCentreOnArea),
                  });
      g.DrawLines(linePen,
                  new PointF[] { 
                    new PointF(pos.X - xDistanceFromCentreOnArea, 
                               pos.Y + yDistanceFromCentreOnArea + yLength), 
                    new PointF(pos.X - xDistanceFromCentreOnArea, 
                               pos.Y + yDistanceFromCentreOnArea),
                    new PointF(pos.X - xDistanceFromCentreOnArea - xLength, 
                               pos.Y + yDistanceFromCentreOnArea),
                  });
      g.DrawLines(linePen,
                  new PointF[] { 
                    new PointF(pos.X + xDistanceFromCentreOnArea, 
                               pos.Y - yDistanceFromCentreOnArea - yLength), 
                    new PointF(pos.X + xDistanceFromCentreOnArea, 
                               pos.Y - yDistanceFromCentreOnArea),
                    new PointF(pos.X + xDistanceFromCentreOnArea + xLength, 
                               pos.Y - yDistanceFromCentreOnArea),
                  });
      g.DrawLines(linePen,
                  new PointF[] { 
                    new PointF(pos.X - xDistanceFromCentreOnArea, 
                               pos.Y - yDistanceFromCentreOnArea - yLength), 
                    new PointF(pos.X - xDistanceFromCentreOnArea, 
                               pos.Y - yDistanceFromCentreOnArea),
                    new PointF(pos.X - xDistanceFromCentreOnArea - xLength, 
                               pos.Y - yDistanceFromCentreOnArea),
                  });

      // Create a path for the circle
      RectangleF circleRectangle =
        new RectangleF(0.0F + position.X - faceOffCircleRadius,
                       0.0F + position.Y - faceOffCircleRadius,
                       faceOffCircleRadius * 2.0F,
                       faceOffCircleRadius * 2.0F);
      System.Drawing.Drawing2D.GraphicsPath circlePath = new System.Drawing.Drawing2D.GraphicsPath();
      circlePath.StartFigure();
      circlePath.AddEllipse(circleRectangle);
      circlePath.CloseFigure();

      // Clip the area of the circle so that we can draw the hash-marks nicely
      Region clipRegion = new Region(circlePath);
      Region oldClip = g.Clip;
      g.ExcludeClip(clipRegion);

      // Draw the hash-marks outside the circle
      float lengthFromCentre = faceOffCircleRadius + outerHashLengthY;
      g.DrawLine(linePen,
                 pos.X - xDistanceFromCentreOnArea,
                 pos.Y - lengthFromCentre,
                 pos.X - xDistanceFromCentreOnArea,
                 pos.Y + lengthFromCentre);
      g.DrawLine(linePen,
                 pos.X + xDistanceFromCentreOnArea,
                 pos.Y - lengthFromCentre,
                 pos.X + xDistanceFromCentreOnArea,
                 pos.Y + lengthFromCentre);

      // Restore the clipping region
      g.Clip = oldClip;

      // Draw the circle
      g.DrawEllipse(linePen, circleRectangle);

      clipRegion.Dispose();
    }

    public void DrawMarkings(Graphics graphics)
    {
      // Create the pens for drawing the lines with
      Pen boardsPen = new Pen(Color.Black, boardsPenWidth);
      Pen blueLinePen = new Pen(pms286, thickLinePenWidth);
      Pen redLinePen = new Pen(pms186, thickLinePenWidth);
      Pen blueThinLinePen = new Pen(pms286, thinLinePenWidth);
      Pen redThinLinePen = new Pen(pms186, thinLinePenWidth);

      // Create the brushes to fill areas on the ice with
      Brush blueBrush = new SolidBrush(pms286);
      Brush redBrush = new SolidBrush(pms186);
      Brush creaseBrush = new SolidBrush(pms298);
      Brush iceBrush = Brushes.White;
      Brush goalBrush = Brushes.LightGray;
      Brush benchBrush = Brushes.DarkGray;

      float cornerDiameter = cornerRadiusOfBoards * 2.0F;

      float distanceOfGoalLinesFromEndOfRinkInPixels = distanceOfGoalLineFromEndOfRink;
      float distanceOfBlueLineFromEndOfRinkInPixels = distanceOfBlueLineFromEndOfRink - (thickLinePenWidth / 2.0F);

      PointF centreOfIce = new PointF(rinkLength / 2.0F, rinkWidth / 2.0F);

      float centreCircleRadiusInPixels = faceOffCircleRadius;
      float centreCircleDiameterInPixels = faceOffCircleRadius * 2.0F;

      float refereesCreaseRadiusInPixels = refereesCreaseRadius;
      float refereesCreaseDiameterInPixels = refereesCreaseRadius * 2.0F;

      float halfGoalWidth = goalWidth / 2.0F;

      // Create the rink path that will be use for drawing the boards
      // and masking the rink for the goal lines
      RectangleF topLeftCorner = 
        new RectangleF(0.0F,
                       0.0F,
                       cornerDiameter,
                       cornerDiameter);
      RectangleF topRightCorner =
        new RectangleF(rinkLength - cornerDiameter,
                       0.0F,
                       cornerDiameter,
                       cornerDiameter);
      RectangleF bottomLeftCorner =
        new RectangleF(0.0F,
                       rinkWidth - cornerDiameter,
                       cornerDiameter,
                       cornerDiameter);
      RectangleF bottomRightCorner =
        new RectangleF(rinkLength - cornerDiameter,
                       rinkWidth - cornerDiameter,
                       cornerDiameter,
                       cornerDiameter);
      System.Drawing.Drawing2D.GraphicsPath rink = new System.Drawing.Drawing2D.GraphicsPath();
      rink.StartFigure();
      rink.AddArc(topLeftCorner, 180.0F, 90.0F);
      rink.AddLine(0.0F + cornerRadiusOfBoards,
                   0.0F,
                   rinkLength - cornerRadiusOfBoards,
                   0.0F);
      rink.AddArc(topRightCorner, 270.0F, 90.0F);
      rink.AddLine(rinkLength,
                   0.0F + cornerRadiusOfBoards,
                   rinkLength,
                   rinkWidth - cornerRadiusOfBoards);
      rink.AddArc(bottomRightCorner, 0.0F, 90.0F);
      rink.AddLine(rinkLength - cornerRadiusOfBoards,
                   rinkWidth,
                   0.0F + cornerRadiusOfBoards,
                   rinkWidth);
      rink.AddArc(bottomLeftCorner, 90.0F, 90.0F);
      rink.AddLine(0.0F,
                   rinkWidth - cornerRadiusOfBoards,
                   0.0F,
                   0.0F + cornerRadiusOfBoards);
      rink.CloseFigure();

      // Clip the drawing area to the rink itself
      Region oldClip = graphics.Clip;
      graphics.SetClip(rink);

      // Draw the ice
      graphics.FillPath(iceBrush, rink);

      // Draw the goal creases
      float halfCreaseWidthInPixels = creaseWidth / 2.0F;
      float creaseWidthInPixels = creaseWidth;
      float creaseClipWidth = creaseArcRadius + 0.5F;
      float creaseArcRadiusInPixels = creaseArcRadius;
      float creaseArcDiameterInPixels = creaseArcRadius * 2.0F;
      float creaseEdgeLengthInPixels = createEdgeLength;
      RectangleF creaseClipRect1 =
        new RectangleF(0.0F + distanceOfGoalLinesFromEndOfRinkInPixels,
                       centreOfIce.Y - halfCreaseWidthInPixels,
                       creaseClipWidth,
                       creaseWidthInPixels);
      Region creaseOldClip = graphics.Clip;
      graphics.SetClip(creaseClipRect1);
      RectangleF crease1ArcRect =
        new RectangleF(0.0F + distanceOfGoalLinesFromEndOfRinkInPixels - creaseArcRadiusInPixels,
                       centreOfIce.Y - creaseArcRadiusInPixels,
                       creaseArcDiameterInPixels,
                       creaseArcDiameterInPixels);
      graphics.FillEllipse(creaseBrush, crease1ArcRect);
      graphics.DrawEllipse(redThinLinePen, crease1ArcRect);
      graphics.Clip = creaseOldClip;
      graphics.DrawLine(redThinLinePen,
                 0.0F + distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIce.Y - halfCreaseWidthInPixels,
                 0.0F + distanceOfGoalLinesFromEndOfRinkInPixels + creaseEdgeLengthInPixels,
                 centreOfIce.Y - halfCreaseWidthInPixels);
      graphics.DrawLine(redThinLinePen,
                 0.0F + distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIce.Y + halfCreaseWidthInPixels,
                 0.0F + distanceOfGoalLinesFromEndOfRinkInPixels + creaseEdgeLengthInPixels,
                 centreOfIce.Y + halfCreaseWidthInPixels);
      RectangleF creaseClipRect2 =
        new RectangleF(rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels - creaseClipWidth,
                       centreOfIce.Y - halfCreaseWidthInPixels,
                       creaseClipWidth,
                       creaseWidthInPixels);
      graphics.SetClip(creaseClipRect2);
      RectangleF crease2ArcRect =
        new RectangleF(rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels - creaseArcRadiusInPixels,
                       centreOfIce.Y - creaseArcRadiusInPixels,
                       creaseArcDiameterInPixels,
                       creaseArcDiameterInPixels);
      graphics.FillEllipse(creaseBrush, crease2ArcRect);
      graphics.DrawEllipse(redThinLinePen, crease2ArcRect);
      graphics.Clip = creaseOldClip;
      graphics.DrawLine(redThinLinePen,
                 rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIce.Y - halfCreaseWidthInPixels,
                 rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels - creaseEdgeLengthInPixels,
                 centreOfIce.Y - halfCreaseWidthInPixels);
      graphics.DrawLine(redThinLinePen,
                 rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIce.Y + halfCreaseWidthInPixels,
                 rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels - creaseEdgeLengthInPixels,
                 centreOfIce.Y + halfCreaseWidthInPixels);

      graphics.Clip = creaseOldClip;

      // Draw the goal lines
      graphics.DrawLine(redThinLinePen,
                 0.0F + distanceOfGoalLinesFromEndOfRinkInPixels,
                 0.0F,
                 0.0F + distanceOfGoalLinesFromEndOfRinkInPixels,
                 rinkWidth);
      graphics.DrawLine(redThinLinePen,
                 rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels,
                 0.0F,
                 rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels,
                 rinkWidth);

      // Draw the blue lines
      graphics.DrawLine(blueLinePen,
                 0.0F + distanceOfBlueLineFromEndOfRinkInPixels,
                 0.0F,
                 0.0F + distanceOfBlueLineFromEndOfRinkInPixels,
                 rinkWidth);
      graphics.DrawLine(blueLinePen,
                 rinkLength - distanceOfBlueLineFromEndOfRinkInPixels,
                 0.0F,
                 rinkLength - distanceOfBlueLineFromEndOfRinkInPixels,
                 rinkWidth);

      // Draw the centre-circle
      graphics.DrawEllipse(blueThinLinePen,
                    centreOfIce.X - centreCircleRadiusInPixels,
                    centreOfIce.Y - centreCircleRadiusInPixels,
                    centreCircleDiameterInPixels,
                    centreCircleDiameterInPixels);

      // Draw the red line
      graphics.DrawLine(redLinePen,
                 centreOfIce.X,
                 0.0F,
                 centreOfIce.X,
                 rinkWidth);

      // Draw the centre face-off spot
      DrawFaceOffSpot(graphics, centreOfIce, blueBrush, centreFaceOffSpotDiameter, true);

      // Draw the "Referee's crease" (a semi-circle zone on one side at centre ice)
      graphics.DrawArc(redThinLinePen,
                centreOfIce.X - refereesCreaseRadiusInPixels,
                rinkWidth - refereesCreaseRadiusInPixels,
                refereesCreaseDiameterInPixels, 
                refereesCreaseDiameterInPixels, 
                180.0F, 
                360.0F);

      // Draw the goals
      // TODO: Make this fancier and rounded - just like the real nets
      RectangleF goal1 =
        new RectangleF(0.0F + distanceOfGoalLinesFromEndOfRinkInPixels - goalDepth,
                       centreOfIce.Y - halfGoalWidth,
                       goalDepth,
                       goalWidth);
      RectangleF goal2 =
        new RectangleF(rinkLength - distanceOfGoalLinesFromEndOfRinkInPixels,
                       centreOfIce.Y - halfGoalWidth,
                       goalDepth,
                       goalWidth);
      RectangleF[] goals = new RectangleF[] {
        goal1,
        goal2
      };
      graphics.FillRectangles(goalBrush, goals);
      graphics.DrawRectangles(redThinLinePen, goals);

      // Draw the trapezoid zone behind the goals
      graphics.DrawLine(redThinLinePen,
                 new PointF(0.0F, (rinkWidth / 2.0F) - (trapezoidBaseWidth / 2.0F)),
                 new PointF(distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) - trapezoidOffsetFromCentre));
      graphics.DrawLine(redThinLinePen,
                 new PointF(0.0F, (rinkWidth / 2.0F) + (trapezoidBaseWidth / 2.0F)),
                 new PointF(distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) + trapezoidOffsetFromCentre));
      graphics.DrawLine(redThinLinePen,
                 new PointF(rinkLength, (rinkWidth / 2.0F) - (trapezoidBaseWidth / 2.0F)),
                 new PointF(rinkLength - distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) - trapezoidOffsetFromCentre));
      graphics.DrawLine(redThinLinePen,
                 new PointF(rinkLength, (rinkWidth / 2.0F) + (trapezoidBaseWidth / 2.0F)),
                 new PointF(rinkLength - distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) + trapezoidOffsetFromCentre));

      // Draw the face-off areas
      PointF[] faceOffAreas = new PointF[] {
        new PointF(distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink)
      };
      foreach (PointF faceOffArea in faceOffAreas) {
        DrawFaceOffArea(graphics, faceOffArea, redBrush, redThinLinePen);
      }

      // Draw the neutral zone face off spots
      PointF[] faceOffSpots = new PointF[] {
        new PointF(distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink)
      };
      foreach (PointF faceOffSpot in faceOffSpots) {
        DrawFaceOffSpot(graphics, faceOffSpot, redBrush, faceOffSpotDiameter, false);
      }

      // Restore clipping region to draw the boards and the stuff outside the boards
      graphics.Clip = oldClip;

      // Create the player benches
      float halfBenchWidth = playerBenchWidth / 2.0F;
      float benchWidth = playerBenchWidth;
      float benchHeight = playerBenchDepth;
      RectangleF bench1 =
        new RectangleF(0.0F + distanceOfBlueLineFromEndOfRinkInPixels - halfBenchWidth,
                       0.0F - benchHeight,
                       benchWidth,
                       benchHeight);
      RectangleF bench2 =
        new RectangleF(rinkLength - distanceOfBlueLineFromEndOfRinkInPixels - halfBenchWidth,
                       0.0F - benchHeight,
                       benchWidth,
                       benchHeight);
      
      // Create the penalty boxes
      RectangleF penaltyBox1 =
        new RectangleF(0.0F + distanceOfBlueLineFromEndOfRinkInPixels,
                       rinkWidth,
                       penaltyBoxWidth,
                       benchHeight);
      RectangleF penaltyBox2 =
        new RectangleF(rinkLength - distanceOfBlueLineFromEndOfRinkInPixels - penaltyBoxWidth,
                       rinkWidth,
                       penaltyBoxWidth,
                       penaltyBoxDepth);

      // Draw all the "benches"
      RectangleF[] benches = new RectangleF[] {
        bench1,
        bench2,
        penaltyBox1,
        penaltyBox2
      };
      graphics.FillRectangles(benchBrush, benches);
      graphics.DrawRectangles(boardsPen, benches);

      // Draw the boards
      graphics.DrawPath(boardsPen, rink);

      // Dispose of resources (note that we don't dispose of 
      // the system brushes otherwise we don't seem to get 
      // them back - i.e. it releases the system brush)
      boardsPen.Dispose();
      blueLinePen.Dispose();
      redLinePen.Dispose();
      blueThinLinePen.Dispose();
      redThinLinePen.Dispose();
      blueBrush.Dispose();
      redBrush.Dispose();
      creaseBrush.Dispose();
      rink.Dispose();
    }

  }
}
