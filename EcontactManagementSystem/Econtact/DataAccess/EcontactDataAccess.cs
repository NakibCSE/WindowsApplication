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
            //Open connection
            conn.Open();
            try{
                
                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand("sprSelect", conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

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
        public void Insert(EcontactDataAccess c)
        {

            //Connect DataBase
            SqlConnection conn = new SqlConnection(Global.DBCon);

            //Connection open here
            conn.Open();
            try
            {
                //Creating sql command 
                SqlCommand cmd = new SqlCommand("sprInsertContact", conn);

                cmd.CommandType = CommandType.StoredProcedure;


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                // Output parameter for success/failure message
                SqlParameter resultMessageParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessageParam);

                cmd.ExecuteNonQuery();

                // Get the result message from the output parameter
                string resultMessage = resultMessageParam.Value.ToString();
                MessageBox.Show(resultMessage);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();         
            }
        }

        //Method to update data in database from our application
        public void Update(EcontactDataAccess c)
        {

            SqlConnection conn = new SqlConnection(Global.DBCon);
            try
            {
                //Open database connection
                conn.Open();
                
                //Creating SQL command 
                SqlCommand cmd = new SqlCommand("sprUpdateContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add value 
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);


                // Output parameter for success/failure message
                SqlParameter resultMessageParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessageParam);

                cmd.ExecuteNonQuery();

                // Get the result message from the output parameter
                string resultMessage = resultMessageParam.Value.ToString();
                MessageBox.Show(resultMessage);
              

            }
            catch (Exception ex) { 
            
                }
            finally {
                conn.Close();
            }

        }

        //Method to dalete data form database
        public void Delete(EcontactDataAccess c)
        {

            //Create sql connection 
            SqlConnection conn = new SqlConnection(Global.DBCon);
            try
            {
                 //Open connection 
                 conn.Open();

                //Create sql command 
                SqlCommand cmd = new SqlCommand("sprDeleteContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

             
                 // Output parameter for success/failure message
                SqlParameter resultMessageParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessageParam);

                cmd.ExecuteNonQuery();

                // Get the result message from the output parameter
                string resultMessage = resultMessageParam.Value.ToString();
                MessageBox.Show(resultMessage);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close(); 
            }
        }

    }
}
