<?php
	//Ceate Session
	session_start();

	if(!isset($_SESSION["user_id"])){
	    header("Location: login.php");
	    exit();
	}
?>
<html>
	<head>
		<title>Home</title>
		<link rel="stylesheet" href="stupidstylewiththesauce.css">
	</head>
	<body>
		<form method="post" action="logout.php">
    		<button type="submit" name="submit_button">Log Out</button>
		</form>
		<?php echo "Welcome " . $_SESSION["first_name"] . " " . $_SESSION['last_name']; 
		echo "<br>", "<a href='exam.php'>Take Exam</a> <br>";
		?>
	</body>
</html>