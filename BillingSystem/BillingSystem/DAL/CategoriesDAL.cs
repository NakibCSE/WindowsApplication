using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BillingSystem.BLL;

namespace BillingSystem.DAL
{
    
    class CategoriesDAL
    {
        SqlConnection conn = new SqlConnection(Global.DBConn);

        #region Select Method
        public DataTable Select()
        { 
            //Creating database connection
            SqlConnection conn = new SqlConnection(Global.DBConn);
            DataTable dt = new DataTable();

            try
            {
                //Query to get all the data from Database
                String sql = "SELECT *FROM tbl_categories";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter sda = new SqlDataAdapter();

                //Open database connection
                conn.Open();

                //Adding the value from adapter to data table
                sda.Fill(dt);       
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert New category
        public bool Insert(CategoriesBLL c)
        {
            bool isSuccess = false;

            //Connecting to database
            SqlConnection conn = new SqlConnection(Global.DBConn);

            try
            {
                //Query to add new category
                String sql = "INSERT INTO tbl_categories(Title, Description, AddedDate, AddedBy) VALUES(@Title, @Description, @AddedDate, @AddedBy)";

                //Creating sql command to pass values in our query
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Title", c.Title);
                cmd.Parameters.AddWithValue("@Description", c.Description);
                cmd.Parameters.AddWithValue("@AddedDate", c.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", c.AddedBy);

                //Open database connection
                conn.Open();

                //Creating the int variable to execute the command
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then it's value will be greater than 0 else it will be zero
                if(rows>0)
                {
                    //Query executed successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute query
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion

        #region update method
        public bool Update(CategoriesBLL c)
        {
            bool isSuccess = false;
            try
            {
                //Query to update category
                String sql = "";
                //14 number vdo, 20:23 (last)
            }
            catch
            {
            }
            finally
            { 
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }
        #endregion



    }
}
