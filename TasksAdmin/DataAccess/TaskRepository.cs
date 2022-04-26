using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TasksAdmin.Models;

namespace TasksAdmin.DataAccess
{
    public class TaskRepository : ITaskRepository<TaskItem>
    {
        string SqlString = "Data Source=DESKTOP-P0KS4DF\\SQLEXPRESS;Initial Catalog=TasksManager_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public async Task<List<TaskItem>> GetItems(Boolean IsActive) 
        {

            List<TaskItem> ListTI = new List<TaskItem>();

            using (SqlConnection connection = new SqlConnection(SqlString))  
            {
                string queryString = "Select * from Tasks where active = @paramActive";

                
                
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@paramActive", IsActive);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskItem ObjTI = new TaskItem();

                        ObjTI.Id = reader.GetInt32(0);
                        ObjTI.Description = reader.GetString(1);
                        ObjTI.Active = reader.GetBoolean(2);

                        ListTI.Add(ObjTI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                { 
                    connection.Close();
                }

            }

            return ListTI;
        }

       
        public async Task<List<TaskItem>> SaveNewItems(TaskItem newItem)
        {

            List<TaskItem> ListTI = new List<TaskItem>();

            using (SqlConnection connection = new SqlConnection(SqlString))
            {
                string queryString = "exec SaveNewItem @Description";

                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@Description", newItem.Description);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskItem ObjTI = new TaskItem();

                        ObjTI.Id = reader.GetInt32(0);
                        ObjTI.Description = reader.GetString(1);
                        ObjTI.Active = reader.GetBoolean(2);

                        ListTI.Add(ObjTI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }

            return ListTI;
        }

        public async Task<List<TaskItem>> DeleteItems(TaskItem newItem)
        {

            List<TaskItem> ListTI = new List<TaskItem>();

            using (SqlConnection connection = new SqlConnection(SqlString))
            {
                string queryString = "exec DeleteItem @Id, @IsActive";

                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@Id", newItem.Id);
                command.Parameters.AddWithValue("@IsActive", newItem.Active);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskItem ObjTI = new TaskItem();

                        ObjTI.Id = reader.GetInt32(0);
                        ObjTI.Description = reader.GetString(1);
                        ObjTI.Active = reader.GetBoolean(2);

                        ListTI.Add(ObjTI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }

            return ListTI;
        }


        public async Task<List<TaskItem>> UpdateItems(TaskItem newItem)
        {

            List<TaskItem> ListTI = new List<TaskItem>();

            using (SqlConnection connection = new SqlConnection(SqlString))
            {

                bool IsActive = newItem.Active==true ? false : true;

                string queryString = "exec UpdateItem @Id, @IsActive";

                SqlCommand command = new SqlCommand(queryString, connection)
                {
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@Id", newItem.Id);
                command.Parameters.AddWithValue("@IsActive", IsActive);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TaskItem ObjTI = new TaskItem();

                        ObjTI.Id = reader.GetInt32(0);
                        ObjTI.Description = reader.GetString(1);
                        ObjTI.Active = reader.GetBoolean(2);

                        ListTI.Add(ObjTI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }

            }

            return ListTI;
        }
    }
}
