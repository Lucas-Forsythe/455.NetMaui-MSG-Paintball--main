
<?php
header("Content-Type: application/json");
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Methods: POST, OPTIONS");
header("Access-Control-Allow-Headers: Content-Type");

if ($_SERVER["REQUEST_METHOD"] == "OPTIONS") {
    http_response_code(200);
    exit();
}

if ($_SERVER["REQUEST_METHOD"] != "POST") {
    http_response_code(405);
    echo json_encode([
        "success" => false,
        "message" => "POST requests only."
    ]);
    exit();
}

require_once __DIR__ . "/../db.php";

$data = json_decode(file_get_contents("php://input"), true);

$playerID = (int)($data["player_id"] ?? 0);
$time = $data["time"] ?? "";
$gameType = $data["game_type"] ?? "";
$date = $data["date"] ?? "";
$location = $data["location"] ?? "";

$validTimes = [
    "10:00 am",
    "12:00 pm",
    "1:00 pm",
    "2:00 pm"
];

$validParties = [
    "Paintball Party",
    "Airsoft Party",
    "Gel Party"
];

$validFields = [
    "King of the hill",
    "Castle",
    "Town",
    "Forest",
    "Sandhill",
    "Graveyard"
];

if (
    $playerID <= 0 ||
    !in_array($time, $validTimes, true) ||
    !in_array($gameType, $validParties, true) ||
    !in_array($location, $validFields, true) ||
    !preg_match('/^\d{4}-\d{2}-\d{2}$/', $date) ||
    $date < date("Y-m-d")
) {
    echo json_encode([
        "success" => false,
        "message" => "Please enter valid booking information."
    ]);
    exit();
}

try {
    $sql = "INSERT INTO game
            (Player_ID, Game_Type, `Date`, `Time`, Location)
            VALUES (?, ?, ?, ?, ?)";

    $statement = $pdo->prepare($sql);

    $statement->execute([
        $playerID,
        $gameType,
        $date,
        $time,
        $location
    ]);

    echo json_encode([
        "success" => true,
        "message" => "Your booking was successfully submitted."
    ]);

} catch (PDOException $e) {
    http_response_code(500);

    echo json_encode([
        "success" => false,
        "message" => "The booking could not be saved. Please try again."
    ]);
}
?>
