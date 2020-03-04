using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class databaseLinks
{ 
    string connStr;
    MySqlConnection conn;

    //数据库初始化
    public databaseLinks(string _host, string _database, string _id, string _password, string _port, string _pooling,string _charset)
    {
        connStr = "data source="+_host+";database="+_database+";user id="+_id+";password="+_password+";port="+_port+";pooling="+_pooling+";charset="+_charset+";";
        conn = new MySqlConnection(connStr);
    }

    //打开数据库
    public void openSQL()
    {
        conn.Open();
    }

    //添加新用户
    public void addUser(string userName,string userpass)
    {
        string addUser = "insert into userData(user_name,user_pass) values('" + userName + "','" + userpass + "')";
        MySqlCommand cmd = new MySqlCommand(addUser,conn);
        cmd.ExecuteNonQuery();
    }

    //获取密码
    public int getPass(string userName)
    {
        int pass = thePass(userName);
        return pass;
    }
    private int thePass(string userName)
    {
        string getPass = "select user_pass from userData where user_name = '" + userName + "'";
        MySqlCommand cmd = new MySqlCommand(getPass, conn);
        MySqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        return reader.GetInt32("user_pass");
    }
}
