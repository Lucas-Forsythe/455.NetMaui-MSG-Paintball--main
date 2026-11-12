<?php
	// Include database
	include("database.php");

	// Check if the form was submitted using POST
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        
        // Collect the input data
        $first_name = $_POST["user_first_name"];
        $last_name = $_POST["user_last_name"];
        $email = $_POST["user_email"];
        $password = $_POST['user_password'];
        $id = $_POST['user_id'];

        // Create a varaible that is checking all IDs in database
        $checkId = mysqli_query($conn, "SELECT STUDENTID FROM account WHERE STUDENTID = '$id'");

        // Compare what user gives and what is already stored
        if (mysqli_num_rows($checkId) > 0) {
            echo "Error: This ID is already registered.";
            echo '<button type="button" onclick="history.go(-1)">Go Back</button>';
            exit();
        }

        // Check for empty
        if(empty($first_name) || empty($last_name) || empty($email) || empty($password) || empty($id)) {
            echo "Error: Field not filled";
            header("Location: signup.php");
            exit();
        }

        // Email check
        if(strpos($email, '@') == false) {
            echo "The email address is not valid.";
            // Finding out the history.go is making me rework some older pages
            echo '<button type="button" onclick="history.go(-1)">Go Back</button>';
            exit();
        }

        //Let them go on
        else {
            echo "you did it. Yay <br>";
        }
    }

    //Send data to database
    $sql = "INSERT INTO account (STUDENTID, FIRSTNAME, LASTNAME, ACCOUNT_PASSWORD, EMAIL) VALUES('$id', '$first_name', '$last_name', '$password', '$email')";

    //Try Catch Exception Handling
    try{
        mysqli_query($conn, $sql);
        echo "User is now registered <br>";
    }

    catch(mysql_exception){
        echo "User could not be registered <br>";
    }
    
    //Test link to check that this works
    echo "<a href='home.php'>Home</a> <br>";
    
    mysqli_close($conn);
?>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <title>Processing Answers</title>
        <link rel="stylesheet" href="stupidstylewiththesauce.css">
    </head>
</html>