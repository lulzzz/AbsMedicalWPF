﻿using AbsMedical.Controllers;
using AbsMedical.Data;
using AbsMedical.Utils;
using AbsMedical.WcfServices;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AbsMedical.Forms
{
    /// <summary>
    /// Logique d'interaction pour AbsMedWindow.xaml
    /// </summary>
    public partial class AbsMedWindow : MetroWindow
    {
        #region Properties
        private student CurrentStudent
        {
            get;
        }

        private DoctorS CurrentDoctor
        {
            get
            {
                return DoctorController.Get(CurrentDoctorGuid);
            }
        }

        private string CurrentDoctorGuid
        {
            get;
        }

        private absmedical GetAbsMedicalValue()
        {
            absmedical absMedical = new absmedical()
            {
                VisitDate = DateTime.Now,
                Note = txtMotive.Text,
                DoctorGuid = CurrentDoctorGuid,
                StudentGuid = CurrentStudent.Guid,
                StartDate = dtStart.SelectedDate,
                EndDate = dtEnd.SelectedDate
            };
            return absMedical;
        }
        #endregion

        public AbsMedWindow(student student, string doctorGuid)
        {
            this.CurrentStudent = student;
            this.CurrentDoctorGuid = doctorGuid;
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            this.lblLogedAs.Content = "Logged as " + CurrentDoctor.Firstname + " " + CurrentDoctor.Lastname;
            
            //Student binding
            lblStudentId.Content = CurrentStudent.StudentId;
            lblFirstname.Content = CurrentStudent.Firstname;
            lblLastname.Content = CurrentStudent.Lastname;
            lblSecurityNumber.Content = CurrentStudent.SocialSecurityNumber;
            lblBirthDate.Content = CurrentStudent.Birthdate;
            lblBirthPlace.Content = CurrentStudent.Birthplace;
            lblAddress.Content = CurrentStudent.Address;
            lblAddress2.Content = CurrentStudent.PostalCode + " " + CurrentStudent.City + ", " + CurrentStudent.country.Name;
            lblPhone.Content = CurrentStudent.Phone;
            lblMail.Content = CurrentStudent.Email;

            //School binding
            lblSchool.Content = CurrentStudent.school.Name;
            lblSchoolAdrs.Content = CurrentStudent.school.Address;
            lblSchoolAdrs2.Content = CurrentStudent.school.PostalCode + " " + CurrentStudent.school.City + ", " + CurrentStudent.school.country.Name;
            lblSchoolPhone.Content = CurrentStudent.school.Phone;
            lblSchoolMail.Content = CurrentStudent.school.Email;

            //Proof
            lblDate.Content = DateTime.Now.ToString("dd/MM/yyyy");
            dtStart.SelectedDate = DateTime.Now;

            //Mail
            txtSubject.Text = "Justificatif Absence Médicale du " + DateTime.Now.ToString("dd/MM/yyyy");
            txtBody.Text = "";
            chkBxSendStudent.IsChecked = true;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            mailconfiguration mailConfig = DoctorController.GetMailConfiguration(CurrentDoctorGuid);
            List<string> sendTo = new List<string> { CurrentStudent.school.Email };
            List<string> sendToCC = new List<string> { };
            if (chkBxSendStudent.IsChecked == true)
            {
                sendToCC.Add(CurrentStudent.Email);
            }
            string subject = txtSubject.Text;
            StringBuilder body = new StringBuilder();
            body.Append(txtBody.Text);
            if (Utils.Mail.Send(mailConfig, sendTo, sendToCC, subject, body, null, false))
            {
                ShowAlert("Votre mail bien été envoyé.");
            } else
            {
                ShowAlert("Erreur: votre mail n'a pas pu être envoyé.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Dialog
        private async void ShowAlert(string title)
        {
            var dialog = (BaseMetroDialog)this.Resources["CustomCloseDialog"];
            dialog.Title = title;

            await this.ShowMetroDialogAsync(dialog);
            await dialog.WaitUntilUnloadedAsync();
        }

        private async void btnCloseCustomDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = (BaseMetroDialog)this.Resources["CustomCloseDialog"];

            await this.HideMetroDialogAsync(dialog);
        }
        #endregion

        private void btnExportPDF_Click(object sender, RoutedEventArgs e)
        {
            if(PDF.CreatePDF(CurrentStudent, CurrentDoctor, GetAbsMedicalValue()))
            {
                ShowAlert("PDF has been created");
            }
        }
    }
}
