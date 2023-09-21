using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BillingSystem.BLL;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace BillingSystem.DAL
{
    class LoginDAL
    {
        public bool loginCheck(LoginBLL l)
        {
            bool isSuccess = false;

            //Open sql connection
            SqlConnection conn = new SqlConnection(Global.DBConn);

            try
            {
                conn.Open();

                //Sql query to check login
                String sql = "SELECT *FROM tbl_users WHERE UserName=@Username and Password=@Password and UserType=@UserType";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Username", l.Username);
                cmd.Parameters.AddWithValue("@Password", l.Password);
                cmd.Parameters.AddWithValue("@UserType", l.UserType);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //Login match
                    isSuccess = true;
                }
                else
                {
                    //Login doesn't match
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { 
                //Close connection
                conn.Close();
            }


            return isSuccess;
        }
    }
}
