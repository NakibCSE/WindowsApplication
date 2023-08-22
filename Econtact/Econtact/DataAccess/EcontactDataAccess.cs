using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Econtact.DataAccess
{
    class EcontactDataAccess
    {
        

        //Setter and getter properties act as data carrier in our application

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        //Selecting data from our database 
        public DataTable Select()
        {
            //Step 1: Database connection
            SqlConnection conn = new SqlConnection(Global.DBCon);
            DataTable dt = new DataTable();

            try{
                //Step 2: Wite SQL Query
                string sql = "SELECT *FROM tbl_contact";

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql,conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex){
            
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }


        //Inserting data into database 
        public bool Insert(EcontactDataAccess c)
        {
            //Creating a default return type and setting it's value to false
            bool isSuccess = false;

            //Step 1: Connect DataBase
            SqlConnection conn = new SqlConnection(Global.DBCon);
            //Connection open here
            conn.Open();
            try
            {
                //Step 2: Create a sql query to insert data 
                string sql = "INSERT INTO tbl_contact(FirstName, LastName, ContactNo, Address, Gender) VALUES(@FirstName, @LastName, @ContactNo, @Address, @Gender)";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully them the vlues of rows will be greater then zero else value will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();         
            }
            return isSuccess;
        }

        //Method to update data in database from our application
        public bool Update(EcontactDataAccess c)
        {
            //Create a default return tyoe and set its value to false
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(Global.DBCon);
            try
            {
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";

                //Creating SQL command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add value 
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //Open database connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully them the vlues of rows will be greater then zero else value will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex) { 
            
                }
            finally {
                conn.Close();
            }

            return isSuccess;
        }

        //Method to dalete data form database
        public bool Delete(EcontactDataAccess c)
        {
            //Create a default return value and set its value to false 

            bool isSuccess = false;

            //Create sql connection 
            SqlConnection conn = new SqlConnection(Global.DBCon);
            try
            {
                //Sql to delte data
                string sql = "DELETE FROM tbl_contact WHERE ContactID=@ContactID";

                //Create sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //Open connection 
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //If the query runs successfully then the value of rows is greater than zero and else its value is 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close(); 
            }
            return isSuccess;
        }

    }
}
