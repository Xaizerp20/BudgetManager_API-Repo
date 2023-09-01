using BudgetManagerAPI.Connection;
using BudgetManagerAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BudgetManagerAPI.Data
{
    public class DExpensesRegister
    {
       
        ConnectionDB cn = new ConnectionDB(); //get a string db connection


        //METHOD TO EXECUTE SP FOR READ Expenses
        public async Task<List<MExpensesRegister>> GetExpensesRegistersAsync()
        {
            var list = new List<MExpensesRegister>();

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_getAllExpenses", sql)) //get procedure for execute
                {
                    await sql.OpenAsync(); //open db connection 
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command

                    using(var item = await cmd.ExecuteReaderAsync()) //execute sp
                    {
                        while(await item.ReadAsync()) //read data of table
                        {
                            MExpensesRegister expenses = new MExpensesRegister();

                            expenses.ExpenseId = (int)item["ExpenseId"];
                            expenses.ExpenseDescription = (string)item["ExpenseDescription"];
                            expenses.Amount = (decimal)item["Amount"];
                            expenses.ExpenseDate = (DateTime)item["ExpenseDate"];
                            expenses.UserId = (int)item["UserId"];
                            expenses.CategoryId = (int)item["CategoryId"];


                            list.Add(expenses);
                        }

                    }

                }

            }

            return list;
        }


        //METHOD TO EXECUTE SP FOR INSERT Expenses
        public async Task InsertExpensesRegistersAsync(MExpensesRegister expense)
        {

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_insertExpense", sql)) //get procedure for execute
                {
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command
                    cmd.Parameters.AddWithValue("@ExpenseDescription", expense.ExpenseDescription);
                    cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@ExpenseDate", expense.ExpenseDate);
                    cmd.Parameters.AddWithValue("@UserId", expense.UserId);
                    cmd.Parameters.AddWithValue("@CategoryId", expense.CategoryId);

                    await sql.OpenAsync(); //open db connection
                    await cmd.ExecuteNonQueryAsync();
                    
                }

            }
        }

    }
}
