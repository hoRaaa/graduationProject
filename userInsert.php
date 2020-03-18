<?php
include('connection.php');

$selectUserName = "SELECT * FROM users_data WHERE user_name = '".$_POST['addUserName']."'";

$resultUserName = mysqli_query($connect,$selectUserName);

//用户是否存在
if(mysqli_num_rows($resultUserName)>0){
	echo "user_exists";
}
else
{
	$sql = "INSERT INTO users_data (user_name,user_pass) values ('".$_POST['addUserName']."','".$_POST['addPass']."')";
	$result = mysqli_query($connect,$sql);
	echo "success";
}
?>