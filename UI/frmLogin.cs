﻿using EasyBilling.BLL;
using EasyBilling.BLL.Application;
using EasyBilling.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyBilling.UI
{
    public partial class frmLogin : Form
    {
        LoginBLL l = new LoginBLL();
        LoginDAL dal = new LoginDAL();
        public static string loggedInUser;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = Common.ConvertToString(txtUserName.Text.Trim());
            l.password = Common.ConvertToString(txtPassword.Text.Trim());
            l.user_type = Common.ConvertToString(cmbUserType.Text.Trim());
            if(dal.LoginCheck(l))
            {
                MessageBox.Show("Login successfull.");
                loggedInUser = l.username;
                //Open respective form based on user type
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;
                    case "User":
                        {
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;
                    default:
                        MessageBox.Show("User Type does not exists.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Login failed please try again.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            AppManager.LaunchApplication();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppManager.ConnectionManager.Close();
        }
    }
}