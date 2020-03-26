<?php
include('connection.php');

$sql = "SELECT * FROM `users_data` ORDER BY `users_data`.`user_score` DESC";
$sql1 = "SELECT * FROM users_data WHERE user_name = '".$_POST['userName']."'";

$result1 = mysqli_query($connect,$sql);
$row1 = mysqli_fetch_assoc($result);

if($_POST['userScore'] > $row1['user_score'])
{
	$sql2 = "UPDATE `users_data` SET `user_score` = '".$_POST['userScore']."' WHERE `users_data`.`user_name` = '".$_POST['userName']."';";
	$result2 = mysqli_query($connect,$sql);
}

$result = mysqli_query($connect,$sql);

for($x=0;$x<5;$x++){
	$row = mysqli_fetch_assoc($result);
	echo $row['user_name'].";".$row['user_score'].";";
}
?>