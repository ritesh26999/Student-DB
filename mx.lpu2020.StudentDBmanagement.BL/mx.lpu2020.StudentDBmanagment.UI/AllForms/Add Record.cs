﻿using mx.lpu2020.StudentDB.common;
using mx.lpu2020.StudentDBmanagement.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mx.lpu2020.StudentDBmanagment.UI
{
    public partial class Add_Record : Form
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        StudentRepositery studentRepositery;
        Validation validation;
        AddFields addfields;

        public Add_Record()
        {
            try
            {
                log.Info("into the addRecord forms constructer");
                InitializeComponent();
                studentRepositery = new StudentRepositery();
                validation = new Validation();
                log.Info("out of the addRecord forms constructer");

            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show(e1.Message);
            }


        }

        //For Adding the record Button name-> Addrecord button;
        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the add record button click");
                int isValidate = validation.ValidateAddRecord(FirstnameTb.Text, LastnameTb.Text, Email.Text, City.Text, Gender.Text);
                if (isValidate == 1)
                {
                    MessageBox.Show("FIRST NAME MUST BE FILLED");
                }
                else if (isValidate == 2)
                {
                    MessageBox.Show("LAST NAME MUST BE FILLED");
                }
                else if (isValidate == 3)
                {
                    MessageBox.Show("EMAIL MUST BE FILLED");
                }
                else if (isValidate == 4)
                {
                    MessageBox.Show("CITY MUST BE FILLED");
                }
                else if (isValidate == 5)
                {
                    MessageBox.Show("GENDER MUST BE FILLED");
                }
                else if (validation.IsMaliciousAttempt(FirstnameTb.Text, LastnameTb.Text, Email.Text, City.Text, Gender.Text) == true)
                {
                    MessageBox.Show("Malicious Attempt");
                }
                else
                {
                    Student student = new Student
                    {
                        FirstName = FirstnameTb.Text,
                        LastName = LastnameTb.Text,
                        Email = Email.Text,
                        City = City.Text,
                        Gender = Gender.Text,
                    };
                    bool HasInserted = studentRepositery.Save(student);
                    if (HasInserted == true)
                    {
                        MessageBox.Show("Record Has Inserted Properly");
                        FirstnameTb.Text = "";
                        LastnameTb.Text = "";
                        Email.Text = "";
                        City.Text = "";
                        Gender.Text = "";
                    }
                }

                log.Info("out of the add record button click");
            }
            catch (Exception e1)
            {
                log.Error(e1.Message);
                MessageBox.Show("Invalid or Malicious attempt!: ");
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            log.Info("Addrecord button hover event listner");
            button1.BackColor = Color.Red;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            log.Info("Addrecord button Leave event listner");
            button1.BackColor = Color.DarkRed;
        }

        //FOR 'HERE' LABEL       
        private void label7_MouseHover(object sender, EventArgs e)
        {
            log.Info(" \"Here\" Hover event listner");
            label7.ForeColor = Color.Blue;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {

            label7.ForeColor = Color.MidnightBlue;
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {

            label7.ForeColor = Color.Blue;
        }

        //'HERE' LABEL CLICK EVENT LISTNER
        private void label7_Click_1(object sender, EventArgs e)
        {
            try
            {
                log.Info("into the here-label click function");
                if (addfields == null)
                {
                    addfields = new AddFields();
                    addfields.Show();
                }
                //   addfields.Close();
                addfields = null;
                log.Info("out of the here-label click function");
            }
            catch (Exception exception)
            {
                log.Error(exception.Message);
                MessageBox.Show("SOMETHING WENT WRONG: RESTART THE APPLICATION");
            }
        }
        



    }
}
