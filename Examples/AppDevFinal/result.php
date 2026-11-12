<?php
include("database.php");
// Return the newest exam
$sql = "SELECT * FROM examresults where 1";

// Apply search if used
// Learning .= was a very interesting time. I did not know before this that we could modify our strings like this by adding onto them. This could be useful for a lot of websites like displaying the rank of admin on certain accounts
if (!empty($_GET['student_id'])) {
    $student_id = $_GET['student_id'];
    $sql .= " AND Student_Id = '$student_id'";
}

$result = mysqli_query($conn, $sql);

?>

<html>
	<head>
		<title>Result</title>
		<link rel="stylesheet" href="stupidstylewiththesauce.css">
	</head>
	<body>
        <form method="GET" action="">
            <label>Student ID:</label>
            <!-- Get user ID if checking a specific score -->
            <input type="text" name="student_id" value="<?php echo isset($_GET['student_id']) ? $_GET['student_id'] : ''; ?>">
            <input type="submit" value="Search">
        </form>
        
        <!-- Yes We should probably have cleaned up opening and closing php so many times -->
        <?php 
        if (mysqli_num_rows($result) > 0) {
            echo "<br>Your Results:";
            while ($row = mysqli_fetch_assoc($result)) {
                echo "<p>Student ID: " . $row['Student_Id'] ."</p>";
                echo "<p>Exam Date: " . $row['Date'] ."</p>";
                echo "<p>Exam Time: " . $row['Time'] ." </p>";
                echo "<p>Score: " . $row['Score'] ."</p>";
                echo "<p>Correct Answers: " . $row['Correct_Answers'] ."</p>";
                echo "<p>Wrong Answers: " . $row['Wrong_Answers'] ."</p>";
            }
        } else {
            echo "No exam results found.";
        }

        mysqli_close($conn);
        ?>

	   <?php echo "<br>", "<a href='home.php'>Return to Home</a> <br>";?>
        </form>
	</body>
</html>