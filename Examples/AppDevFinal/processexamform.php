<?php
	//Include database
	include("database.php");
    session_start();
	//Check if the form was submitted using POST
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        //date and time variables
        
        //Collect the input data
        $q1 = $_POST["q1"];
        $q2 = $_POST["q2"];
        $q3 = (isset($_POST['q3'])) ? $_POST['q3'] : array();
        $q4 = (isset($_POST['q4'])) ? $_POST['q4'] : array();
        $q5 = $_POST['q5'];
        $id = $_SESSION['user_id'];
        date_default_timezone_set("America/New_York");
        $date = date("Y-m-d");
        $time = date("H:i:s");
        $CORRECT_ANSWERS = 0;
        $WRONG_ANSWERS = 0;
        if ($q1 == "true") {
            $CORRECT_ANSWERS++;
        }
        else{
            $WRONG_ANSWERS++;
        }
        if ($q2 == "true") {
            $CORRECT_ANSWERS++;
        }
        else{
            $WRONG_ANSWERS++;
        }
            if (count($q3) == 1 && $q3[0] == "true") {
            $CORRECT_ANSWERS++;
        }
        else{
            $WRONG_ANSWERS++;
        }
            if (count($q4) == 1 && $q4[0] == "true") {
            $CORRECT_ANSWERS++;
        }
        else{
            $WRONG_ANSWERS++;
        }
            if ($q5 == "true") {
            $CORRECT_ANSWERS++;
        }
        else{
            $WRONG_ANSWERS++;
        }

        $SCORE = $CORRECT_ANSWERS * 20;
    //Send data to database

    mysqli_query($conn, "SET time_zone = 'America/New_York'");
    
    $sql = "INSERT INTO examresults (Student_Id, Date, Time, Score, Correct_Answers, Wrong_Answers) VALUES('$id', '$date', '$time', '$SCORE', '$CORRECT_ANSWERS', '$WRONG_ANSWERS')";

    mysqli_query($conn, $sql);

    mysqli_close($conn);
}
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Process Exam Form</title>
        <link rel="stylesheet" href="stupidstylewiththesauce.css">
    </head>
    <body>
<?php
        echo "<br>", "<a href='result.php'>See Results</a> <br>";
        echo "<br>", "<a href='home.php'>Return to Home</a> <br>";
?>
    </body>
    </html>