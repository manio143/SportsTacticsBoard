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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SportsTacticsBoard.FieldTypes
{
  /// <summary>
  /// Hockey rink dimensions and details taken from: 
  ///   http://en.wikipedia.org/wiki/Hockey_rink
  /// </summary>
  class HockeyRink_NHL : IFieldType
  {
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
    private const float innerHashLengthX = 4.0F;
    private const float innerHashLengthY = 3.0F;
    private const float outerHashLengthY = 2.0F;
    private const float refereesCreaseRadius = 10.0F;
    private const float playerBenchWidth = 24.0F;
    private const float playerBenchDepth = 4.5F;
    private const float penaltyBoxWidth = 10.0F;
    private const float penaltyBoxDepth = playerBenchDepth;
    private const float goalWidth = 6.0F;
    private const float goalDepth = 44.0F / 12.0F; // 44 inches
    private const float trapezoidDistanceFromGoalPosts = 6.0F;
    private const float trapezoidBaseWidth = 28.0F;
    private const float trapezoidOffsetFromCentre = trapezoidDistanceFromGoalPosts + (goalWidth / 2.0F);
    private const float creaseWidth = goalWidth + (1.0F * 2.0F);
    private const float creaseArcRadius = 6.0F;
    private const float createEdgeLength = 4.5F;

    private const int minimumThinLineWidthInPixels = 1;
    private const int minimumThickLineWidthInPixels = 2;
    private const int minimumFaceOffCircleRadiusInPixels = minimumThickLineWidthInPixels / 2;

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

    public float FieldLength
    {
      get { return rinkLength; }
    }

    public float FieldWidth {
      get { return rinkWidth; }
    }

    public float Margin
    {
      get { return margin; }
    }

    public Color FieldSurfaceColour
    {
      get { return Color.LightGray; } 
    }

    public List<FieldObject> StandardFieldObjects
    {
      get {
        const float personSize = 2.5F;

        List<FieldObject> fieldObjects = new List<FieldObject>();

        // Create the outfield players
        for (int i = 1; i <= playersPerTeam; i++) {
          FieldObjects.Player attackingPlayer = new FieldObjects.Player(i, FieldObjects.Player.TeamId.Attacking, 0.0F, 0.0F);
          attackingPlayer.DisplayRadius = personSize;
          FieldObjects.Player defendingPlayer = new FieldObjects.Player(i, FieldObjects.Player.TeamId.Defending, 0.0F, 0.0F);
          defendingPlayer.DisplayRadius = personSize;
          fieldObjects.Add(attackingPlayer);
          fieldObjects.Add(defendingPlayer);
        }

        // Create the goalies
        FieldObjects.Player goalie1 = new FieldObjects.Player(0, FieldObjects.Player.TeamId.Attacking, 0.0F, 0.0F);
        goalie1.DisplayRadius = personSize;
        fieldObjects.Add(goalie1);
        FieldObjects.Player goalie2 = new FieldObjects.Player(0, FieldObjects.Player.TeamId.Defending, 0.0F, 0.0F);
        goalie2.DisplayRadius = personSize;
        fieldObjects.Add(goalie2);

        // Add the puck
        fieldObjects.Add(new FieldObjects.Puck(FieldLength / 2, FieldWidth / 2));

        // Add the referees
        FieldObjects.Referee ref1 = new FieldObjects.Referee("R1", "Referee_Hockey_1", distanceOfBlueLineFromEndOfRink - 10.0F, FieldWidth - 7.5F);
        ref1.DisplayRadius = personSize;
        fieldObjects.Add(ref1);
        FieldObjects.Referee ref2 = new FieldObjects.Referee("R2", "Referee_Hockey_2", FieldLength - distanceOfBlueLineFromEndOfRink + 10.0F, 7.5F);
        ref2.DisplayRadius = personSize;
        fieldObjects.Add(ref2);

        FieldObjects.Referee line1 = new FieldObjects.Referee("L1", "Referee_Hockey_L1", distanceOfBlueLineFromEndOfRink - 3.0F, 2.75F);
        line1.DisplayRadius = personSize;
        fieldObjects.Add(line1);
        FieldObjects.Referee line2 = new FieldObjects.Referee("L2", "Referee_Hockey_L2", FieldLength - distanceOfBlueLineFromEndOfRink + 3.0F, FieldWidth - 2.75F);
        line2.DisplayRadius = personSize;
        fieldObjects.Add(line2);

        return fieldObjects;
      }
    }

    public FieldObjectLayout DefaultLayout
    { 
      get {
        return null;
      } 
    }

    public List<string> GetTeam(FieldObjects.Player.TeamId team)
    {
      List<string> t = new List<string>();
      
      // Fill in the list of players on the specified team

      return t;
    }


    // Pantone colours matched using: http://www.logoorange.com/color/color-codes-chart.php
    private Color pms286 = Color.FromArgb(0xff, 0x00, 0x55, 0xfa); // blue lines
    private Color pms186 = Color.FromArgb(0xff, 0xf5, 0x00, 0x2f); // red lines
    private Color pms298 = Color.FromArgb(0xff, 0x4f, 0xed, 0xff); // goal crease

    private int GetSizeInPixelsEnforcingMinimum(float fieldUnits, int minimumPixels, FieldUnitToPixelConversionDelegate cd)
    {
      int sizeInPixels = cd(fieldUnits);
      if (sizeInPixels < minimumPixels) {
        sizeInPixels = minimumPixels;
      }
      return sizeInPixels;
    }

    private int getBoardLineSizeInPixels(FieldUnitToPixelConversionDelegate cd)
    {
      return GetSizeInPixelsEnforcingMinimum(boardsPenWidth, minimumThickLineWidthInPixels, cd);
    }

    private int getThickLineSizeInPixels(FieldUnitToPixelConversionDelegate cd)
    {
      return GetSizeInPixelsEnforcingMinimum(thickLinePenWidth, minimumThickLineWidthInPixels, cd);
    }

    private int getThinLineSizeInPixels(FieldUnitToPixelConversionDelegate cd)
    {
      return GetSizeInPixelsEnforcingMinimum(thinLinePenWidth, minimumThinLineWidthInPixels, cd);
    }

    private Point InPixelsOnScreen(PointF fieldUnitPoint, Rectangle fieldRectangle, FieldUnitToPixelConversionDelegate cd)
    {
      Point pt = new Point(cd(fieldUnitPoint.X), cd(fieldUnitPoint.Y));
      pt.Offset(fieldRectangle.Location);
      return pt;
    }

    private void DrawFaceOffSpot(Graphics g, PointF position, Brush brush, float diameter, Rectangle fieldRectangle, FieldUnitToPixelConversionDelegate cd)
    {
      int faceOffSpotRadiusInPixels =
        GetSizeInPixelsEnforcingMinimum(diameter / 2.0F, minimumFaceOffCircleRadiusInPixels, cd);
      int faceOffSpotDiameterInPixels =
        GetSizeInPixelsEnforcingMinimum(diameter, minimumFaceOffCircleRadiusInPixels * 2, cd);

      Point pt = InPixelsOnScreen(position, fieldRectangle, cd);

      g.FillEllipse(brush,
                    pt.X - faceOffSpotRadiusInPixels,
                    pt.Y - faceOffSpotRadiusInPixels,
                    faceOffSpotDiameterInPixels,
                    faceOffSpotDiameterInPixels);
    }

    private void DrawFaceOffArea(Graphics g, PointF position, Brush spotBrush, Pen linePen, Rectangle fieldRectangle, FieldUnitToPixelConversionDelegate cd)
    {
      DrawFaceOffSpot(g, position, spotBrush, faceOffSpotDiameter, fieldRectangle, cd);

      // Draw the hash marks around the spot
      Point pos = InPixelsOnScreen(position, fieldRectangle, cd);
      float halfOfThinLineWidth = thinLinePenWidth / 2.0F;
      int xDistanceFromCentreOnArea = cd(innerHashDistanceFromCentreX + halfOfThinLineWidth);
      int yDistanceFromCentreOnArea = cd(innerHashDistanceFromCentreY + halfOfThinLineWidth);
      int xLength = cd(innerHashLengthX - halfOfThinLineWidth);
      int yLength = cd(innerHashLengthY - halfOfThinLineWidth);
      g.DrawLines(linePen, 
                  new Point[] { 
                    new Point(pos.X + xDistanceFromCentreOnArea, 
                              pos.Y + yDistanceFromCentreOnArea + yLength), 
                    new Point(pos.X + xDistanceFromCentreOnArea, 
                              pos.Y + yDistanceFromCentreOnArea),
                    new Point(pos.X + xDistanceFromCentreOnArea + xLength, 
                              pos.Y + yDistanceFromCentreOnArea),
                  });
      g.DrawLines(linePen,
                  new Point[] { 
                    new Point(pos.X - xDistanceFromCentreOnArea, 
                              pos.Y + yDistanceFromCentreOnArea + yLength), 
                    new Point(pos.X - xDistanceFromCentreOnArea, 
                              pos.Y + yDistanceFromCentreOnArea),
                    new Point(pos.X - xDistanceFromCentreOnArea - xLength, 
                              pos.Y + yDistanceFromCentreOnArea),
                  });
      g.DrawLines(linePen,
                  new Point[] { 
                    new Point(pos.X + xDistanceFromCentreOnArea, 
                              pos.Y - yDistanceFromCentreOnArea - yLength), 
                    new Point(pos.X + xDistanceFromCentreOnArea, 
                              pos.Y - yDistanceFromCentreOnArea),
                    new Point(pos.X + xDistanceFromCentreOnArea + xLength, 
                              pos.Y - yDistanceFromCentreOnArea),
                  });
      g.DrawLines(linePen,
                  new Point[] { 
                    new Point(pos.X - xDistanceFromCentreOnArea, 
                              pos.Y - yDistanceFromCentreOnArea - yLength), 
                    new Point(pos.X - xDistanceFromCentreOnArea, 
                              pos.Y - yDistanceFromCentreOnArea),
                    new Point(pos.X - xDistanceFromCentreOnArea - xLength, 
                              pos.Y - yDistanceFromCentreOnArea),
                  });

      // Create a path for the circle
      Rectangle circleRectangle =
        new Rectangle(fieldRectangle.Left + cd(position.X - faceOffCircleRadius),
                      fieldRectangle.Top + cd(position.Y - faceOffCircleRadius),
                      cd(faceOffCircleRadius * 2.0F),
                      cd(faceOffCircleRadius * 2.0F));
      System.Drawing.Drawing2D.GraphicsPath circlePath = new System.Drawing.Drawing2D.GraphicsPath();
      circlePath.StartFigure();
      circlePath.AddEllipse(circleRectangle);
      circlePath.CloseFigure();

      // Clip the area of the circle so that we can draw the hash-marks nicely
      Region oldClip = g.Clip;
      g.ExcludeClip(new Region(circlePath));

      // Draw the hash-marks outside the circle
      int lengthFromCentre = cd(faceOffCircleRadius + outerHashLengthY);
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
    }

    public void DrawFieldMarkings(Graphics g, Rectangle fieldRectangle, FieldUnitToPixelConversionDelegate conversionDelegateWithNoOffset)
    {
      // Create the pens for drawing the lines with
      Pen boardsPen = new Pen(Color.Black, getBoardLineSizeInPixels(conversionDelegateWithNoOffset));
      Pen blueLinePen = new Pen(pms286, getThickLineSizeInPixels(conversionDelegateWithNoOffset));
      Pen redLinePen = new Pen(pms186, getThickLineSizeInPixels(conversionDelegateWithNoOffset));
      Pen blueThinLinePen = new Pen(pms286, getThinLineSizeInPixels(conversionDelegateWithNoOffset));
      Pen redThinLinePen = new Pen(pms186, getThinLineSizeInPixels(conversionDelegateWithNoOffset));

      // Create the brushes to fill areas on the ice with
      Brush blueBrush = new SolidBrush(pms286);
      Brush redBrush = new SolidBrush(pms186);
      Brush creaseBrush = new SolidBrush(pms298);
      Brush iceBrush = Brushes.White;
      Brush goalBrush = Brushes.LightGray;
      Brush benchBrush = Brushes.DarkGray;

      int cornerDiameterInPixels = conversionDelegateWithNoOffset(cornerRadiusOfBoards * 2.0F);
      int cornerRadiusInPixels = conversionDelegateWithNoOffset(cornerRadiusOfBoards);

      int distanceOfGoalLinesFromEndOfRinkInPixels = conversionDelegateWithNoOffset(distanceOfGoalLineFromEndOfRink);
      int distanceOfBlueLineFromEndOfRinkInPixels = conversionDelegateWithNoOffset(distanceOfBlueLineFromEndOfRink - (thickLinePenWidth / 2.0F));

      PointF centreOfIce = new PointF(rinkLength / 2.0F, rinkWidth / 2.0F);
      Point centreOfIceInPixels = InPixelsOnScreen(centreOfIce, fieldRectangle, conversionDelegateWithNoOffset);

      int centreCircleRadiusInPixels = conversionDelegateWithNoOffset(faceOffCircleRadius);
      int centreCircleDiameterInPixels = conversionDelegateWithNoOffset(faceOffCircleRadius * 2.0F);

      int refereesCreaseRadiusInPixels = conversionDelegateWithNoOffset(refereesCreaseRadius);
      int refereesCreaseDiameterInPixels = conversionDelegateWithNoOffset(refereesCreaseRadius * 2.0F);

      int goalDepthInPixels = conversionDelegateWithNoOffset(goalDepth);
      int halfGoalWidthInPixels = conversionDelegateWithNoOffset(goalWidth / 2.0F);
      int goalWidthInPixels = conversionDelegateWithNoOffset(goalWidth);

      // Create the rink path that will be use for drawing the boards
      // and masking the rink for the goal lines
      Rectangle topLeftCorner = 
        new Rectangle(fieldRectangle.Left, 
                      fieldRectangle.Top,
                      cornerDiameterInPixels,
                      cornerDiameterInPixels);
      Rectangle topRightCorner =
        new Rectangle(fieldRectangle.Right - cornerDiameterInPixels,
                      fieldRectangle.Top,
                      cornerDiameterInPixels,
                      cornerDiameterInPixels);
      Rectangle bottomLeftCorner =
        new Rectangle(fieldRectangle.Left,
                      fieldRectangle.Bottom - cornerDiameterInPixels,
                      cornerDiameterInPixels,
                      cornerDiameterInPixels);
      Rectangle bottomRightCorner =
        new Rectangle(fieldRectangle.Right - cornerDiameterInPixels,
                      fieldRectangle.Bottom - cornerDiameterInPixels,
                      cornerDiameterInPixels,
                      cornerDiameterInPixels);
      System.Drawing.Drawing2D.GraphicsPath rink = new System.Drawing.Drawing2D.GraphicsPath();
      rink.StartFigure();
      rink.AddArc(topLeftCorner, 180.0F, 90.0F);
      rink.AddLine(fieldRectangle.Left + cornerRadiusInPixels,
                   fieldRectangle.Top,
                   fieldRectangle.Right - cornerRadiusInPixels,
                   fieldRectangle.Top);
      rink.AddArc(topRightCorner, 270.0F, 90.0F);
      rink.AddLine(fieldRectangle.Right,
                   fieldRectangle.Top + cornerRadiusInPixels,
                   fieldRectangle.Right,
                   fieldRectangle.Bottom - cornerRadiusInPixels);
      rink.AddArc(bottomRightCorner, 0.0F, 90.0F);
      rink.AddLine(fieldRectangle.Right - cornerRadiusInPixels,
                   fieldRectangle.Bottom,
                   fieldRectangle.Left + cornerRadiusInPixels,
                   fieldRectangle.Bottom);
      rink.AddArc(bottomLeftCorner, 90.0F, 90.0F);
      rink.AddLine(fieldRectangle.Left,
                   fieldRectangle.Bottom - cornerRadiusInPixels,
                   fieldRectangle.Left,
                   fieldRectangle.Top + cornerRadiusInPixels);
      rink.CloseFigure();

      // Clip the drawing area to the rink itself
      Region oldClip = g.Clip;
      g.SetClip(rink);

      // Draw the ice
      g.FillPath(iceBrush, rink);

      // Draw the goal creases
      int halfCreaseWidthInPixels = conversionDelegateWithNoOffset(creaseWidth / 2.0F);
      int creaseWidthInPixels = conversionDelegateWithNoOffset(creaseWidth);
      int creaseClipWidth = conversionDelegateWithNoOffset(creaseArcRadius + 0.5F);
      int creaseArcRadiusInPixels = conversionDelegateWithNoOffset(creaseArcRadius);
      int creaseArcDiameterInPixels = conversionDelegateWithNoOffset(creaseArcRadius * 2.0F);
      int creaseEdgeLengthInPixels = conversionDelegateWithNoOffset(createEdgeLength);
      Rectangle creaseClipRect1 =
        new Rectangle(fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels,
                      centreOfIceInPixels.Y - halfCreaseWidthInPixels,
                      creaseClipWidth,
                      creaseWidthInPixels);
      Region creaseOldClip = g.Clip;
      g.SetClip(creaseClipRect1);
      Rectangle crease1ArcRect =
        new Rectangle(fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels - creaseArcRadiusInPixels,
                      centreOfIceInPixels.Y - creaseArcRadiusInPixels,
                      creaseArcDiameterInPixels,
                      creaseArcDiameterInPixels);
      g.FillEllipse(creaseBrush, crease1ArcRect);
      g.DrawEllipse(redThinLinePen, crease1ArcRect);
      g.Clip = creaseOldClip;
      g.DrawLine(redThinLinePen,
                 fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIceInPixels.Y - halfCreaseWidthInPixels,
                 fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels + creaseEdgeLengthInPixels,
                 centreOfIceInPixels.Y - halfCreaseWidthInPixels);
      g.DrawLine(redThinLinePen,
                 fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIceInPixels.Y + halfCreaseWidthInPixels,
                 fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels + creaseEdgeLengthInPixels,
                 centreOfIceInPixels.Y + halfCreaseWidthInPixels);
      Rectangle creaseClipRect2 =
        new Rectangle(fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels - creaseClipWidth,
                      centreOfIceInPixels.Y - halfCreaseWidthInPixels,
                      creaseClipWidth,
                      creaseWidthInPixels);
      g.SetClip(creaseClipRect2);
      Rectangle crease2ArcRect =
        new Rectangle(fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels - creaseArcRadiusInPixels,
                      centreOfIceInPixels.Y - creaseArcRadiusInPixels,
                      creaseArcDiameterInPixels,
                      creaseArcDiameterInPixels);
      g.FillEllipse(creaseBrush, crease2ArcRect);
      g.DrawEllipse(redThinLinePen, crease2ArcRect);
      g.Clip = creaseOldClip;
      g.DrawLine(redThinLinePen,
                 fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIceInPixels.Y - halfCreaseWidthInPixels,
                 fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels - creaseEdgeLengthInPixels,
                 centreOfIceInPixels.Y - halfCreaseWidthInPixels);
      g.DrawLine(redThinLinePen,
                 fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels,
                 centreOfIceInPixels.Y + halfCreaseWidthInPixels,
                 fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels - creaseEdgeLengthInPixels,
                 centreOfIceInPixels.Y + halfCreaseWidthInPixels);

      g.Clip = creaseOldClip;

      // Draw the goal lines
      g.DrawLine(redThinLinePen,
                 fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels,
                 fieldRectangle.Top,
                 fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels,
                 fieldRectangle.Bottom);
      g.DrawLine(redThinLinePen,
                 fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels,
                 fieldRectangle.Top,
                 fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels,
                 fieldRectangle.Bottom);

      // Draw the blue lines
      g.DrawLine(blueLinePen,
                 fieldRectangle.Left + distanceOfBlueLineFromEndOfRinkInPixels,
                 fieldRectangle.Top,
                 fieldRectangle.Left + distanceOfBlueLineFromEndOfRinkInPixels,
                 fieldRectangle.Bottom);
      g.DrawLine(blueLinePen,
                 fieldRectangle.Right - distanceOfBlueLineFromEndOfRinkInPixels,
                 fieldRectangle.Top,
                 fieldRectangle.Right - distanceOfBlueLineFromEndOfRinkInPixels,
                 fieldRectangle.Bottom);

      // Draw the centre-circle
      g.DrawEllipse(blueThinLinePen,
                    centreOfIceInPixels.X - centreCircleRadiusInPixels,
                    centreOfIceInPixels.Y - centreCircleRadiusInPixels,
                    centreCircleDiameterInPixels,
                    centreCircleDiameterInPixels);

      // Draw the red line
      g.DrawLine(redLinePen,
                 centreOfIceInPixels.X,
                 fieldRectangle.Top,
                 centreOfIceInPixels.X,
                 fieldRectangle.Bottom);

      // Draw the centre face-off spot
      DrawFaceOffSpot(g, centreOfIce, blueBrush, centreFaceOffSpotDiameter, fieldRectangle, conversionDelegateWithNoOffset);

      // Draw the "Referee's crease" (a semi-circle zone on one side at centre ice)
      g.DrawArc(redThinLinePen,
                centreOfIceInPixels.X - refereesCreaseRadiusInPixels,
                fieldRectangle.Bottom - refereesCreaseRadiusInPixels,
                refereesCreaseDiameterInPixels, 
                refereesCreaseDiameterInPixels, 
                180.0F, 
                360.0F);

      // Draw the goals
      // TODO: Make this fancier and rounded - just like the real nets
      Rectangle goal1 =
        new Rectangle(fieldRectangle.Left + distanceOfGoalLinesFromEndOfRinkInPixels - goalDepthInPixels,
                      centreOfIceInPixels.Y - halfGoalWidthInPixels,
                      goalDepthInPixels,
                      goalWidthInPixels);
      Rectangle goal2 =
        new Rectangle(fieldRectangle.Right - distanceOfGoalLinesFromEndOfRinkInPixels,
                      centreOfIceInPixels.Y - halfGoalWidthInPixels,
                      goalDepthInPixels,
                      goalWidthInPixels);
      Rectangle[] goals = new Rectangle[] {
        goal1,
        goal2
      };
      g.FillRectangles(goalBrush, goals);
      g.DrawRectangles(redThinLinePen, goals);

      // Draw the trapezoid zone behind the goals
      g.DrawLine(redThinLinePen,
                 InPixelsOnScreen(new PointF(0.0F, (rinkWidth / 2.0F) - (trapezoidBaseWidth / 2.0F)), fieldRectangle, conversionDelegateWithNoOffset),
                 InPixelsOnScreen(new PointF(distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) - trapezoidOffsetFromCentre), fieldRectangle, conversionDelegateWithNoOffset));
      g.DrawLine(redThinLinePen,
                 InPixelsOnScreen(new PointF(0.0F, (rinkWidth / 2.0F) + (trapezoidBaseWidth / 2.0F)), fieldRectangle, conversionDelegateWithNoOffset),
                 InPixelsOnScreen(new PointF(distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) + trapezoidOffsetFromCentre), fieldRectangle, conversionDelegateWithNoOffset));
      g.DrawLine(redThinLinePen,
                 InPixelsOnScreen(new PointF(rinkLength, (rinkWidth / 2.0F) - (trapezoidBaseWidth / 2.0F)), fieldRectangle, conversionDelegateWithNoOffset),
                 InPixelsOnScreen(new PointF(rinkLength - distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) - trapezoidOffsetFromCentre), fieldRectangle, conversionDelegateWithNoOffset));
      g.DrawLine(redThinLinePen,
                 InPixelsOnScreen(new PointF(rinkLength, (rinkWidth / 2.0F) + (trapezoidBaseWidth / 2.0F)), fieldRectangle, conversionDelegateWithNoOffset),
                 InPixelsOnScreen(new PointF(rinkLength - distanceOfGoalLineFromEndOfRink, (rinkWidth / 2.0F) + trapezoidOffsetFromCentre), fieldRectangle, conversionDelegateWithNoOffset));

      // Draw the face-off areas
      PointF[] faceOffAreas = new PointF[] {
        new PointF(distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfZoneFaceOffAreasFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink)
      };
      foreach (PointF faceOffArea in faceOffAreas) {
        DrawFaceOffArea(g, faceOffArea, redBrush, redThinLinePen, fieldRectangle, conversionDelegateWithNoOffset);
      }

      // Draw the neutral zone face off spots
      PointF[] faceOffSpots = new PointF[] {
        new PointF(distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) - distanceOfFaceOffSpotsFromCentreOfRink),
        new PointF(rinkLength - distanceOfNeutralZoneFaceOffSpotsFromEndOfRink, (rinkWidth / 2.0F) + distanceOfFaceOffSpotsFromCentreOfRink)
      };
      foreach (PointF faceOffSpot in faceOffSpots) {
        DrawFaceOffSpot(g, faceOffSpot, redBrush, faceOffSpotDiameter, fieldRectangle, conversionDelegateWithNoOffset);
      }

      // Restore clipping region to draw the boards and the stuff outside the boards
      g.Clip = oldClip;

      // Create the player benches
      int halfBenchWidth = conversionDelegateWithNoOffset(playerBenchWidth / 2.0F);
      int benchWidth = conversionDelegateWithNoOffset(playerBenchWidth);
      int benchHeight = conversionDelegateWithNoOffset(playerBenchDepth);
      Rectangle bench1 =
        new Rectangle(fieldRectangle.Left + distanceOfBlueLineFromEndOfRinkInPixels - halfBenchWidth,
                      fieldRectangle.Top - benchHeight,
                      benchWidth,
                      benchHeight);
      Rectangle bench2 =
        new Rectangle(fieldRectangle.Right - distanceOfBlueLineFromEndOfRinkInPixels - halfBenchWidth,
                      fieldRectangle.Top - benchHeight,
                      benchWidth,
                      benchHeight);
      
      // Create the penalty boxes
      int penaltyBoxW = conversionDelegateWithNoOffset(penaltyBoxWidth);
      int penaltyBoxD = conversionDelegateWithNoOffset(penaltyBoxDepth);
      Rectangle penaltyBox1 =
        new Rectangle(fieldRectangle.Left + distanceOfBlueLineFromEndOfRinkInPixels,
                      fieldRectangle.Bottom,
                      penaltyBoxW,
                      benchHeight);
      Rectangle penaltyBox2 =
        new Rectangle(fieldRectangle.Right - distanceOfBlueLineFromEndOfRinkInPixels - penaltyBoxW,
                      fieldRectangle.Bottom,
                      penaltyBoxW,
                      penaltyBoxD);

      // Draw all the "benches"
      Rectangle[] benches = new Rectangle[] {
        bench1,
        bench2,
        penaltyBox1,
        penaltyBox2
      };
      g.FillRectangles(benchBrush, benches);
      g.DrawRectangles(boardsPen, benches);

      // Draw the boards
      g.DrawPath(boardsPen, rink);
    }

  }
}
