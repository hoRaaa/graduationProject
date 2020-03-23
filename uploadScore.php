<?php
include('connection.php');

$sql = "SELECT * FROM `users_data` ORDER BY `users_data`.`user_score` DESC";
$result = mysqli_query($connect,$sql);

for($x=0;$x<5;$x++){
	$row = mysqli_fetch_assoc($result);
	echo $row['user_name'].";".$row['user_score'].";";
}
?>