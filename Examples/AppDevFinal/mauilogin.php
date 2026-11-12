<?php
	header("Content-Type: application/json");
	error_reporting(0);
	include "database.php";

	$data = json_decode(file_get_contents("php://input"));

	if (!$data) {
	    echo json_encode([
	        "status" => "error",
	        "message" => "Invalid input"
	    ]);
	    exit;
	}

	$STUDENTID = $data->STUDENTID;
	$PASSWORD = $data->PASSWORD;

	$stmt = $conn->prepare("SELECT STUDENTID, FIRSTNAME, LASTNAME, EMAIL 
                        	FROM account 
                        	WHERE STUDENTID = ? AND ACCOUNT_PASSWORD = ?");

	$stmt->bind_param("ss", $STUDENTID, $PASSWORD);
	$stmt->execute();

	$result = $stmt->get_result();

	if ($row = $result->fetch_assoc()) {
	    echo json_encode([
	        "status" => "success",
	        "student" => $row
	    ]);
	} else {
	    echo json_encode([
	        "status" => "error",
	        "message" => "Invalid login"
	    ]);
	}
?>