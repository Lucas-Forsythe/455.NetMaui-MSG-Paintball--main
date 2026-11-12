<?php
session_start(); // Start the session

// Set session variables
$_SESSION["username"] = "";
$_SESSION["role"] = "";
echo "Session variables are set.<br>";
echo '<a href="get_session.php">Go to the next page</a>';
?>
