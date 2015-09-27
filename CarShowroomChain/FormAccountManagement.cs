﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarShowroomChain
{
    public partial class FormAccountManagement : Form
    {
        public FormAccountManagement()
        {
            InitializeComponent();
            this.panel2BackgroundLogin.Visible = false;
        }

        private void buttonLoginData_Click(object sender, EventArgs e)
        {
            this.panel2BackgroundLogin.Visible = true;
        }

        private void buttonPersonalData_Click(object sender, EventArgs e)
        {
            this.panel2BackgroundLogin.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            int user_id = UserSingleton.Instance.userId;
            var login = textBoxLogin.Text;
            var pass = textBoxPassword.Text;
            var newPass1 = textBoxNewPassword1.Text;
            var newPass2 = textBoxNewPassword2.Text;
            if (newPass1 == newPass2)
            {
                var dbModel = new DatabaseModel();
                var result = dbModel.user_data.Find(user_id);
                if (result != null)
                {
                    if (login == result.login && pass == result.password && user_id == result.id)
                    {
                        result.password = newPass1;
                        dbModel.SaveChanges();
                        this.Hide();
                    } 
                    else
                    {
                        MessageBox.Show("Osoba zalogowana może zmienić hasło tylko sobie.");
                    }
                }
                else
                {
                    MessageBox.Show("Błędny login lub hasło.");
                }
            }
            else
            {
                MessageBox.Show("Nowe hasło w obu polach musi być jednakowe.");
            }

        }
    }
}
