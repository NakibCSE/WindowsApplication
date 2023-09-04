using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TransportManagementSystem.DataAccess
{
    class TransportDataAccess
    {
        //public setter getter
        public int ID { get; set; }
        public string Name { get; set; }
        public string RegistrationNo { get; set; }
        public string Note { set; get; }
        public int VehicleID { set; get; }
        public int SectorID { set; get; }
        public int RouteID { set; get; }
        public int StartingPointID { set; get; }

        //Selecting existing vechicle sector from database 
        public DataTable SelectVehicleSector()
        {
            //Database connection
            SqlConnection conn = new SqlConnection(Global.BDConn);
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to select data
                string sql = "SELECT *FROM VechicleSector";

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //Method for creating new Vehicle sector
        public bool createVehicleSector(String VehicleName, String isActive)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "INSERT INTO [dbo].[VehicleType_Mst](Name, isActive) VALUES(@Name, @isActive)";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }

        //Method for updating vehicleSector
        public bool updateVehicleSector(int ID, String Name, String isActive)
        {
            bool isSuccess = false;
            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "UPDATE VechicleSector SET Name=@Name, isActive=@isActive WHERE ID=@ID";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }

        //Method for creating new vehicle type
        //String RegistrationNo, String Note
        public bool createVehicleType(String Name, String isActive, String RegistrationNo, String Note)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);


            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "INSERT INTO VehicleType_Mst(Name, isActive) VALUES('" + Name + "', '" + isActive + "')";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                int rows = cmd.ExecuteNonQuery();
             
                //Get the generated ID
                //string selectIdentitySql = "SELECT SCOPE_IDENTITY()";
                //SqlCommand cmd2 = new SqlCommand(selectIdentitySql, conn);

                

                String IDstr = "SELECT MAX(ID) FROM VehicleType_Mst";
                SqlCommand cmdIdStr = new SqlCommand(IDstr, conn);
                object result = cmdIdStr.ExecuteScalar();
                
                int maxId = Convert.ToInt32(result);


                string sql2 = "INSERT INTO VehicleType_Dtl(ID, RgistrationNo, Note) VALUES('" + maxId + "','" + RegistrationNo + "', '" + Note + "')";

                //Creating sql command using sql and conn
                SqlCommand cmd3 = new SqlCommand(sql2, conn);


                //Create parameter to add data
                cmd3.Parameters.AddWithValue("@ID", ID);
                cmd3.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                cmd3.Parameters.AddWithValue("@Note", Note);

                int rows2 = cmd3.ExecuteNonQuery();

                //If the query runs successfully them the vlues of rows will be greater then zero else value will be 0
                if (rows2 > 0)
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
                //Close the connection
                conn.Close();

            }

            return isSuccess;
        }

        //Selecting existing vechicle  
        public DataTable SelectVehicle()
        {
            //Database connection
            SqlConnection conn = new SqlConnection(Global.BDConn);
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to select data
                string sql = "Select mst.ID, mst.Name, mst.isActive, dtl.RgistrationNo, dtl.Note FROM VehicleType_Mst mst INNER JOIN VehicleType_Dtl dtl on mst.ID = dtl.ID";

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //Update existing vehicle
        public bool updateVehicle(int ID, String Name, String RgistrationNo, String note, String isActive)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "UPDATE VehicleType_Dtl SET RgistrationNo=@RgistrationNo, Note=@note WHERE ID=@ID";
                string sql1 = "UPDATE VehicleType_Mst SET Name=@Name, isActive=@isActive WHERE ID=@ID";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd1 = new SqlCommand(sql1,conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID",ID);
                cmd.Parameters.AddWithValue("@RgistrationNo", RgistrationNo);
                cmd.Parameters.AddWithValue("@Note", note);
                cmd1.Parameters.AddWithValue("@ID", ID);
                cmd1.Parameters.AddWithValue("@Name",Name);
                cmd1.Parameters.AddWithValue("@isActive",isActive);

                int rows = cmd.ExecuteNonQuery();
                int rows1 = cmd1.ExecuteNonQuery();

                //If the query runs successfully them the vlues of rows will be greater then zero else value will be 0
                if (rows > 0 && rows1>0)
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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }

        //Create transpor route
        public bool createTransportRoute(String RouteName)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "INSERT INTO TransportRoute(Name) VALUES(@Name)";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@name", Name);

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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }

        //Select transport route
        public DataTable SelectTransportRoute()
        {
            //Database connection
            SqlConnection conn = new SqlConnection(Global.BDConn);
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to select data
                string sql = "SELECT *from transportroute";

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }


        //Update existing route
        public bool updateTransportRoute(int ID, String Name)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Update query
                String sql = "UPDATE transportroute SET Name=@Name WHERE ID=@ID";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
               
                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);

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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }

        //Create vehicle starting point
        public bool createVehicleStartingPoint(String Name, int sectorID, int vehicleID, int routeID, String isActive)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);


            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "INSERT INTO VehicleStartingPoint(SectorID, VehicleID, RouteID,Name,isActive) VALUES('" + sectorID + "', '" + vehicleID + "', '" + routeID + "','" + Name + "','" + isActive + "')";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@SectorID", sectorID);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@RouteID", routeID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

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
                //Close the connection
                conn.Close();

            }

            return isSuccess;
            
        }

        //Select starting points
        public DataTable SelectVechileStartingPoint()
        {
            //Database connection
            SqlConnection conn = new SqlConnection(Global.BDConn);
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to select data
                string sql = "SELECT *from VehicleStartingPoint";

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //Update starting points
        public bool updateStartingPoint(int ID, String Name, int sectorID, int vehicleID, int routeID, String isActive)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Update query
                String sql = "UPDATE VehicleStartingPoint SET Name=@Name, SectorID=@sectorID, VehicleID=@vehicleID, RouteID=@routeID, isActive=@isActive WHERE ID=@ID";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@SectorID", sectorID);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@RouteID", routeID);
                cmd.Parameters.AddWithValue("@isActive", isActive);

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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }

        //Create vehicle starting point
        public bool createVehiclePickUpPoint(String Name, int StartingPointID,String Note, String isActive)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);


            //Open connection
            conn.Open();

            try
            {
                //Insert query
                string sql = "INSERT INTO PickUpPoints(StartingPointID,Name,Note,isActive) VALUES('" + StartingPointID + "', '" + Name + "', '" + Note + "','" + isActive + "')";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@StartingPointID", StartingPointID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@isActive", isActive);

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
                //Close the connection
                conn.Close();

            }

            return isSuccess;

        }

        //Select pickup points
        public DataTable SelectVehiclePickUpPOint()
        {
            //Database connection
            SqlConnection conn = new SqlConnection(Global.BDConn);
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to select data
                string sql = "SELECT *from PickUpPoints";

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //Update starting points
        public bool updatePickupPoint(int ID, String Name, int StartingPointID, String Note, String isActive)
        {
            bool isSuccess = false;

            //Connect database
            SqlConnection conn = new SqlConnection(Global.BDConn);

            //Open connection
            conn.Open();

            try
            {
                //Update query
                String sql = "UPDATE pickuppoints SET Name=@Name, StartingPointID=@StartingPointID, Note=@Note, isActive=@isActive WHERE ID=@ID";

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@StartingPointID", StartingPointID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@isActive", isActive);

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
                //Close the connection
                conn.Close();
            }

            return isSuccess;
        }
    }
}