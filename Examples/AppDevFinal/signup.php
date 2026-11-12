<?php
	//That feeling you did this all wrong and put everything inside an echo statement to fix it without rewriting this after wondering why it has an error with the '<' symbol - lf (It's 2am as I write this)
	echo '
		<form action="processsignupform.php" method="POST">
		    First Name: <input type="text" name="user_first_name" required><br>
		    Last Name: <input type="text" name="user_last_name"required><br>
		    E-mail: <input type="text" name="user_email" required><br>
		    User ID: <input type="value" name="user_id" required>
		    User Password: <input type="text" name="user_password" required><br>
		    <input type="submit" value="Submit">
		</form>'
?>
<html>
	<link rel="stylesheet" href="stupidstylewiththesauce.css">
</html>