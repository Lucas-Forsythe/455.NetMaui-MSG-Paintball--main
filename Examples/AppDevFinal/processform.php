<?php
	//Include database
	include("database.php");

	//Check if the form was submitted using POST
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        
        //Collect the input data
        $first_name = $_POST["user_first_name"];
        $last_name = $_POST["user_last_name"];
        $email = $_POST["user_email"];
        $password = $_POST['user_password'];
        $id = $_POST['user_id'];
    }

    //Send data to database
    $sql = "INSERT INTO account (STUDENTID, FIRSTNAME, LASTNAME, ACCOUNT_PASSWORD, EMAIL) VALUES('$id', '$first_name', '$last_name', '$password', '$email')";

    mysqli_query($conn, $sql);

    mysqli_close($conn);
?>