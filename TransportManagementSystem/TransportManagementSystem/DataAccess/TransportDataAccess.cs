using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using TransportManagementSystem.DataInterface;

namespace TransportManagementSystem.DataAccess
{
    class TransportDataAccess
    {
        //Database connection
        SqlConnection conn = new SqlConnection(Global.BDConn);

        //Instance of data interface
        TransportDataInterface tdf = new TransportDataInterface();

        //Select existing vechicle sector from database 
        public DataTable SelectVehicleSector()
        {    
            DataTable dt = new DataTable();
            try
            {
                //Create cmd 
                SqlCommand cmd = new SqlCommand("sprSelectVehicleSector", conn);

                //Create SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open connection and fill the data into datatable 
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

        //Create new Vehicle sector
        public bool createVehicleSector(String Name, String isActive)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {

                //Create cmd
                SqlCommand cmd = new SqlCommand("sprCreateVehicleSector", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);
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

        //Update vehicleSector
        public bool updateVehicleSector(int ID, String Name, String isActive)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {
             
                //Create cmd
                SqlCommand cmd = new SqlCommand("sprUpdateVehicleSector", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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

        //Create new vehicle type
        public bool createVehicleType(String Name, String isActive, String RegistrationNo, String Note)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand("sprCreateVehicleType", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                cmd.Parameters.AddWithValue("@Note", Note);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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

        //Select vehicle type
        public DataTable SelectVehicleType()
        {
            DataTable dt = new DataTable();

            try
            {

                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand("sprSelectVehicleType", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open connection and fill data in datatable
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

        //Update vehicle type
        public bool updateVehicleType(int ID, String Name, String isActive, String RegistrationNo, String note)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {  
                //Create cmd
                SqlCommand cmd = new SqlCommand("sprUpdateVehicleType", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID",ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@RegistrationNo", RegistrationNo);
                cmd.Parameters.AddWithValue("@Note", note);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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

            //Open connection
            conn.Open();

            try
            {

                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand("sprCreateTransportRoute", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@Name", RouteName);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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
            DataTable dt = new DataTable();

            try
            {
                //Create cmd 
                SqlCommand cmd = new SqlCommand("sprSelectTransportRoute", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create SQL DataAdapter using cmd
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


        //Update transport route
        public bool updateTransportRoute(int ID, String Name)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {
               
                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand("sprUpdateTransportRoute", conn);
                cmd.CommandType = CommandType.StoredProcedure;
               
                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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
        public bool createVehicleStartingPoint(int sectorID, int vehicleID, int routeID,String Name, String isActive)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {
                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand("sprCreateVehicleStartingPoint", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@SectorID", sectorID);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@RouteID", routeID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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
            DataTable dt = new DataTable();

            try
            {
               
                //Create cmd 
                SqlCommand cmd = new SqlCommand("sprSelectVehicleStartingPoint", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Creating SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open connection and fill data into datatable 
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

        //Update starting point
        public bool updateStartingPoint(int ID,int sectorID, int vehicleID, int routeID,String Name, String isActive)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {
                //Create cmd
                SqlCommand cmd = new SqlCommand("sprUpdateVehicleStartingPoint", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@SectorID", sectorID);
                cmd.Parameters.AddWithValue("@VehicleID", vehicleID);
                cmd.Parameters.AddWithValue("@RouteID", routeID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);
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

        //Create vehicle pickup point
        public bool createVehiclePickUpPoint(String Name, int StartingPointID,String Note, String isActive)
        {
            bool isSuccess = false;

            //Open connection
            conn.Open();

            try
            {
               
                //Create cmd 
                SqlCommand cmd = new SqlCommand("sprCreateVehiclePickupPoints", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                //Create parameter to add data
                cmd.Parameters.AddWithValue("@StartingPointID", StartingPointID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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
            DataTable dt = new DataTable();

            try
            {
                //Create cmd using sql and conn
                SqlCommand cmd = new SqlCommand("sprSelectVehiclePickupPoints", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create SQL dataadapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open connection and fill data into datatable
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

            //Open connection
            conn.Open();

            try
            {
                
                //Creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand("sprUpdateVehiclePickupPoints", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create parameter to add data
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@StartingPointID", StartingPointID);
                cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                //Output parameter for success/failure message
                SqlParameter resultMessagePram = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(resultMessagePram);

                //Execute the command
                cmd.ExecuteNonQuery();

                //Get the result message from the output parameter
                String resultMessage = resultMessagePram.Value.ToString();
                MessageBox.Show(resultMessage);

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