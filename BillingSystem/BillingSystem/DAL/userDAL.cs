using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BillingSystem.BLL.DAL
{
    class userDAL
    {
        #region Select Data from Database
        public DataTable Select()
        {
            //Static method to connect Database
            SqlConnection conn = new SqlConnection(Global.DBConn);

            //To hold the data from database 
            DataTable dt = new DataTable();

            try
            {
                //SQL query to get data from database
                String sql = "SELECT *FROM tbl_users";

                //For executing command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Getting data from Datatable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                //Database connection open
                conn.Open();

                //Fill data in our datatable
                sda.Fill(dt);

            }
            catch(Exception ex)
            {
                //Trow message if any erroe occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing database connection
                conn.Close();

            }

            //Return the value in Datatable
            return dt;
        }
        #endregion

        #region Insert Data in Database
        public bool Insert(userBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(Global.DBConn);

            try
            {
                String sql = "INSERT INTO tbl_users(FirstName, LastName, Email, UserName, Password, Contact, Address, Gender, UserType, AddedDate, AddedBy) values(@FirstName, @LastName, @Email, @UserName, @Password, @Contact, @Address, @Gender, @UserType, @AddedDate, @AddedBy)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
                cmd.Parameters.AddWithValue("@LastName", u.LastName);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@UserName", u.Username);
                cmd.Parameters.AddWithValue("@Password", u.Password);
                cmd.Parameters.AddWithValue("@Contact", u.Contact);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@Gender",u.Gender);
                cmd.Parameters.AddWithValue("@UserType", u.UserType);
                cmd.Parameters.AddWithValue("@AddedDate", u.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", u.AddedBy);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
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

        #region Update data in database
        public bool Update(userBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(Global.DBConn);
            try
            {
                String sql = "UPDATE tbl_users SET FirstName = @FirstName, LastName = @LastName , Email =@Email , UserName=@UserName, Password=@Password, Contact=@Contact, Address = @Address, Gender =@Gender, UserType =@UserType, AddedDate = @AddedDate, AddedBy=@AddedBy WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@FirstName", u.FirstName);
                cmd.Parameters.AddWithValue("@LastName", u.LastName);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@UserName", u.Username);
                cmd.Parameters.AddWithValue("@Password", u.Password);
                cmd.Parameters.AddWithValue("@Contact", u.Contact);
                cmd.Parameters.AddWithValue("@Address", u.Address);
                cmd.Parameters.AddWithValue("@Gender", u.Gender);
                cmd.Parameters.AddWithValue("@UserType", u.UserType);
                cmd.Parameters.AddWithValue("@AddedDate", u.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", u.AddedBy);
                cmd.Parameters.AddWithValue("@ID", u.ID);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region Delete data from database
        public bool Delete(userBLL u)
        {
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(Global.DBConn);
            try
            {
                String sql = "DELETE FROM tbl_users WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@ID", u.ID);

                conn.Open();

                int rows = cmd.ExecuteNonQuery();
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
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        #endregion

        #region method for record search
        public DataTable Search(String keyword)
        {
            //Static method to connect Database
            SqlConnection conn = new SqlConnection(Global.DBConn);

            //To hold the data from database 
            DataTable dt = new DataTable();

            try
            {
                //SQL query to get data from database
                String sql = "SELECT *FROM tbl_users where ID like '%" + keyword + "%' OR FirstName like '%" + keyword + "%' OR LastName like '%" + keyword + "%' OR UserName like '%" + keyword + "%' OR Contact like '%" + keyword + "%' OR Address like '%" + keyword + "%' OR Gender like '%" + keyword + "%' OR UserType like '%" + keyword + "%' OR Email like '%" + keyword + "%'";

                //For executing command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Getting data from Datatable
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                //Database connection open
                conn.Open();

                //Fill data in our datatable
                sda.Fill(dt);

            }
            catch (Exception ex)
            {
                //Trow message if any erroe occurs
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Closing database connection
                conn.Close();

            }

            //Return the value in Datatable
            return dt;
        }
        #endregion

        #region Getting user ID from Username
        public userBLL GetIDFromUserName(String Username)
        {
            userBLL u = new userBLL();
            SqlConnection conn = new SqlConnection(Global.DBConn);
            DataTable dt = new DataTable();

            try
            {
                String sql = "SELECT id from tbl_users WHERE Username = '" + Username + "'";
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                conn.Open();

                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    u.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return u;
        }

        #endregion
    }
}
