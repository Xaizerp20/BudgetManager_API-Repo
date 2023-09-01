using BudgetManagerAPI.Connection;
using BudgetManagerAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BudgetManagerAPI.Data
{
    public class DUserAccounts
    {
       
        ConnectionDB cn = new ConnectionDB(); //get a string db connection


        //METHOD TO EXECUTE SP FOR READ USERS
        public async Task<List<MUserAccounts>> GetUserAccountsAsync()
        {
            var list = new List<MUserAccounts>();

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_getAllUsers", sql)) //get procedure for execute
                {
                    await sql.OpenAsync(); //open db connection 
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command

                    using(var item = await cmd.ExecuteReaderAsync()) //execute sp
                    {
                        while(await item.ReadAsync()) //read data of table
                        {
                            MUserAccounts users = new MUserAccounts();

                            users.UserId = (int)item["UserId"];
                            users.UserName = (string)item["UserName"];
                            users.PasswordHash = (string)item["PasswordHash"];
                            users.Email = (string)item["Email"];
                            users.PhoneNumber = (decimal)item["PhoneNumber"];
                            users.Active = (bool)item["Active"];


                            list.Add(users);
                        }

                    }

                }

            }

            return list;
        }


        //METHOD TO EXECUTE SP FOR INSERT USERS
        public async Task InsertUserAccountsAsync(MUserAccounts user)
        {

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_insertUsers", sql)) //get procedure for execute
                {
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Active", user.Active);

                    await sql.OpenAsync(); //open db connection
                    await cmd.ExecuteNonQueryAsync();
                    
                }

            }
        }

    }
}
