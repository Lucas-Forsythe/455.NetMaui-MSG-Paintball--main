<?php
include("database.php");

$data = json_decode(file_get_contents("php://input"), true);

$studentid = $data["STUDENTID"];
$date = $data["DATE"];
$time = $data["TIME"];
$score = $data["SCORE"];
$correct = $data["CORRECT"];
$wrong = $data["WRONG"];

$sql = "INSERT INTO examresults
(Student_Id, `Date`, `Time`, Score, Correct_Answers, Wrong_Answers)
VALUES
('$studentid', '$date', '$time', '$score', '$correct', '$wrong')";

if(mysqli_query($conn, $sql))
{
    echo json_encode([
        "status" => "success"
    ]);
}
else
{
    echo json_encode([
        "status" => "error",
        "message" => mysqli_error($conn)
    ]);
}
?>