﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyBilling.BLL;
using EasyBilling.BLL.Application;

namespace EasyBilling.DAL
{
    class UserDAL
    {
        
        #region select data from users table
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("USP_GetUsers", AppManager.ConnectionManager);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
                dt = ds.Tables[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        #endregion
        #region insert and update data
        public bool insertAndUpdate(UserBLL u)
        {
            bool isSuccess = false;
            try
            {
                SqlCommand cmd = new SqlCommand("USP_InsertUsersDetails", AppManager.ConnectionManager);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", SqlDbType.Int).Value = u.id;
                cmd.Parameters.Add("first_name", SqlDbType.VarChar).Value = u.first_name;
                cmd.Parameters.Add("last_name", SqlDbType.VarChar).Value = u.last_name;
                cmd.Parameters.Add("email", SqlDbType.VarChar).Value = u.email;
                cmd.Parameters.Add("username", SqlDbType.VarChar).Value = u.username;
                cmd.Parameters.Add("password", SqlDbType.VarChar).Value = u.password;
                cmd.Parameters.Add("contact", SqlDbType.VarChar).Value = u.contact;
                cmd.Parameters.Add("address", SqlDbType.VarChar).Value = u.address;
                cmd.Parameters.Add("gender", SqlDbType.VarChar).Value = u.gender;
                cmd.Parameters.Add("user_type", SqlDbType.VarChar).Value = u.user_type;
                cmd.Parameters.Add("added_date", SqlDbType.DateTime).Value = u.added_date;
                cmd.Parameters.Add("added_by", SqlDbType.Int).Value = u.added_by;
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isSuccess;
        }
        #endregion
        #region delete users
        public bool delete(UserBLL u)
        {
            bool isSuccess = false;
            try
            {
                SqlCommand cmd = new SqlCommand("USP_DeleteUsers", AppManager.ConnectionManager);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", SqlDbType.Int).Value = u.id;
                int row = cmd.ExecuteNonQuery();
                if(row > 0)
                {
                    isSuccess = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isSuccess;
        }
        #endregion
    }
}
