<?php
include('connection.php');

$sql = "SELECT * FROM users_data WHERE user_name = '".$_POST['userName']."'";

$result = mysqli_query($connect,$sql);

//用户是否存在
if(mysqli_num_rows($result)>0){
	$row = mysqli_fetch_assoc($result);
	
	//密码是否正确
	if($_POST['userPass'] == md5($row['user_pass'])){
		echo "Login";
	}
	else{
		echo "Password_error";
	}
}
else
{
	echo "Not_user";
}
?>