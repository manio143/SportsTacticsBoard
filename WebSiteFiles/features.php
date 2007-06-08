<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Sports Tactics Board - Features</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
<?php include("header.php"); ?>


      <h2>Features (Release 0.2.0)</h2>
      <ul>
        <li>Supports more than one sport (currently Soccer and Hockey), more to be added.</li>
        <li>Records sequences of positions for documenting tactical strategies or plays.</li>
        <li>Save and loads tactical sequences from files - allows building a library of plays or drills.</li>
	<li>Supports pre-defined layouts that position players, ball/puck and officials.</li>
	<li>Supports exporting images and image sequences to files or clipboard.</li>
      </ul>
      <p>See the <a href="changelog.txt">change log</a> for more details. This documents all changes committed to source control, which may include additional functionality after the release above.</p>
      
      <br />
      
      <h2>Release Plan</h2>

      <p>The following are descriptions of the planned content of upcoming releases. Projected dates for these
      releases are not possible at this time due to limited programming resources. They will be released when the 
      features are complete.</p>

      <h3>Release 0.3</h3>
      <ul>
        <li>Support for Volleyball court. <i>Done - Courtesy of Lukas Kawalec (kadeon)</i></li>
        <li>Improve drawing of fields, players and movement lines.</li>
        <li>Support for &quot;views&quot; of sections of the playing field, including rotation.</li>
        <li>Support for predefined &quot;Field Views&quot; for limited views of areas of the playing field.</li>
        <li>Support NFL football or NBA basketball.</li>
        <li>Movement line types, allowing for passing, carrying, dribbling, heading, etc to be distinguished more easily.</li>
      </ul>

      <h2>Other Planned Features Not Yet Scheduled</h2>
      <ul>
        <li>Support for additional sports.</li>
        <li>More configurable and flexible movements lines.</li>
        <li>Support for marker lines associated with field objects (easily show offside line in soccer, etc.).</li>
        <li>Support for annotated descriptions and labels placed on the field of play.</li>
        <li>Pre-defined library of tactical sequences built by user community.</li>
      </ul>



<?php include("footer.php"); ?>
</body>
</html>
