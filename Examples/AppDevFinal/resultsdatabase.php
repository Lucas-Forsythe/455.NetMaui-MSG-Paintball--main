<?php
include("database.php");

$sql = "SELECT Student_Id, Score, Date, Time FROM examresults";

$result = mysqli_query($conn, $sql);

$data = [];

while ($row = mysqli_fetch_assoc($result))
{
    $data[] = $row;
}

echo json_encode($data);
?>