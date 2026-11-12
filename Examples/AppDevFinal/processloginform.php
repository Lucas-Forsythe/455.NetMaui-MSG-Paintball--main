<?php
    //Make a session
    session_start();

	//Include database
	include("database.php");

	//Collect the input data
    $entered_password  = $_POST['user_password'];
    $id = $_POST['user_id'];

    //Pull data from database
    $sql = "select * from account where STUDENTID = '$id'";

    //Make it a query
    $result = mysqli_query($conn, $sql);

    //Check for results
    if(mysqli_num_rows($result) > 0) {

        //Fetch the right row from database, this threw me way too much when trying to make this thing print the first and last name
        $row = mysqli_fetch_assoc($result);

        $stored_password = $row['ACCOUNT_PASSWORD'];

        // Verify password against hash
        if ($entered_password === $stored_password) {

            echo "Login complete <br>";

            // Set session variables
            $_SESSION["user_id"] = $id;
            $_SESSION["first_name"] = $row["FIRSTNAME"];
            $_SESSION["last_name"] = $row["LASTNAME"];

            echo "<a href='home.php'>Home</a> <br>";
        }

        // Error statement
        else {
        echo "Invalid ID or password <br>";
        }
    }
    
    // Error statement
    else {
        echo "Invalid ID or password <br>";
    }

    //Close connection
    mysqli_close($conn);
?>
<html>
    <link rel="stylesheet" href="stupidstylewiththesauce.css">
</html>