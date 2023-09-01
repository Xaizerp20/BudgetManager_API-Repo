using BudgetManagerAPI.Connection;
using BudgetManagerAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BudgetManagerAPI.Data
{
    public class DCategories
    {
       
        ConnectionDB cn = new ConnectionDB(); //get a string db connection


        //METHOD TO EXECUTE SP FOR READ Categories
        public async Task<List<MCategories>> GetCategoriesAsync()
        {
            var list = new List<MCategories>();

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_getAllCategories", sql)) //get procedure for execute
                {
                    await sql.OpenAsync(); //open db connection 
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command

                    using(var item = await cmd.ExecuteReaderAsync()) //execute sp
                    {
                        while(await item.ReadAsync()) //read data of table
                        {
                            MCategories category = new MCategories();

                            category.CategoryId = (int)item["CategoryId"];
                            category.CategoryName = (string)item["CategoryName"];

                            list.Add(category);
                        }

                    }

                }

            }

            return list;
        }


        //METHOD TO EXECUTE SP FOR READ Categories
        public async Task<MCategories> GetCategoryByIdAsync(int categoryId)
        {

            MCategories category = new MCategories();

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_getCategoriesByID", sql)) //get procedure for execute
                {
                    await sql.OpenAsync(); //open db connection 
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                    using (var item = await cmd.ExecuteReaderAsync()) //execute sp
                    {
                        while (await item.ReadAsync()) //read data of table
                        {
                       
                            category.CategoryId = (int)item["CategoryId"];
                            category.CategoryName = (string)item["CategoryName"];


                        }

                    }

                }

            }

            return category;
        }


        //METHOD TO EXECUTE SP FOR INSERT Categories
        public async Task<MCategories> InsertCategoriesAsync(MCategories category)
        {

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_insertCategories", sql)) //get procedure for execute
                {
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    await sql.OpenAsync(); //open db connection


                    int categoryId = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine("The new category ID is {0}", categoryId);

                    category.CategoryId = categoryId;

                }

            }
            return category;
        }

        //METHOD TO EXECUTE SP FOR UPDATE Categories
        public async Task UpdateCategoriesAsync(MCategories category)
        {

            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_UpdateCategory", sql)) //get procedure for execute
                {
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command
                    cmd.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                    cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                    await sql.OpenAsync(); //open db connection

                    await cmd.ExecuteNonQueryAsync();

                }

            }
        }


        public async Task DeleteExpenseRegisterAsync(int categoryId)
        {
            using (var sql = new SqlConnection(cn.StringSQL())) //get a new db connection
            {
                using (var cmd = new SqlCommand("sp_deleteCategories", sql)) //get procedure for execute
                {
                    cmd.CommandType = CommandType.StoredProcedure; //specifc type of command
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    await sql.OpenAsync(); //open db connection
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }
    }
}
