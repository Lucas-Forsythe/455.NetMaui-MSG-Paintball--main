<?php
	include("database.php")
?>
<!DOCTYPE html>
<html>
	<head>
		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<title>Home Page</title>
		<link rel="stylesheet" href="stupidstylewiththesauce.css">
	</head>
	<body>
		<form action="processexamform.php" method="POST">
			<p>Question 1: Which statement about form inputs is correct?</p>
			<input type="radio" name="q1" value= "false" required> Checkbox values are always sent <br>
			<input type="radio" name="q1" value = "false"> Text inputs are only sent if selected <br>
			<input type="radio" name="q1" value = "true"> Text inputs are always sent; checkboxes are only sent if selected <br>
			<input type="radio" name="q1" value = "false"> Only password fields are sent<br>
			<p>Question 2: Which HTML attribute specifies the script that will process form data?</p>
			<input type="radio" name="q2" value= "false" required> Method<br>
			<input type="radio" name="q2" value= "true"> Action<br>
			<input type="radio" name="q2" value= "false"> Process<br>
			<input type="radio" name="q2" value= "false"> Submit<br>
			<p>Question 3: How do you access a global variable inside a function?</p>
			<input type="checkbox" name="q3[]" value= "true" > global $var;<br>
			<input type="checkbox" name="q3[]" value= "false"> use $var;<br>
			<input type="checkbox" name="q3[]" value= "false"> declare $var;<br>
			<input type="checkbox" name="q3[]" value= "false"> $GLOBALS['var'];<br>
			<p>Question 4: Which of the following is NOT a valid arithmetic operator in PHP?</p>
			<input type="checkbox" name="q4[]" value= "false" > +<br>
			<input type="checkbox" name="q4[]" value= "false"> %<br>
			<input type="checkbox" name="q4[]" value= "true"> //<br>
			<input type="checkbox" name="q4[]" value= "false"> **<br>
			<p>Question 5: Which of the following statements is true?</p>
			<input type="radio" name="q5" value= "false" required> PHP does not support ternary operators. <br>
			<input type="radio" name="q5" value= "false"> An if statement must always have an else statement.<br>
			<input type="radio" name="q5" value= "false"> The foreach loop can only be used with indexed arrays, not associative arrays. <br>
			<input type="radio" name="q5" value= "true"> switch statements can only check for equality, not conditions like < or >. <br>
			<input type="submit" value="SUBMIT EXAM">
			<?php echo "<br>", "<a href='home.php'>Return to Home</a> <br>";?>
		</form>
		


		

	</body>
</html>