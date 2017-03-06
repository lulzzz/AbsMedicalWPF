﻿using AbsMedical.Data;
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
using AbsMedical.NFC;
using AbsMedical.Controllers;
using MahApps.Metro.Controls;

namespace AbsMedical.Forms
{
    /// <summary>
    /// Logique d'interaction pour HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : MetroWindow
    {
        #region Properties
        private doctor CurrentDoctor
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
        #endregion

        public HomeWindow(string doctorGuid)
        {
            NFCReader.establishContext();
            NFCReader.SelectDevice();
            this.CurrentDoctorGuid = doctorGuid;
            InitializeComponent();
            SetTitle();
        }

        private void SetTitle()
        {
            this.Title += " - Logged as " + CurrentDoctor.Firstname;
        }

        #region Tile Click
        private void tileRegisterStudent_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void tileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tileProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow window = new ProfileWindow(CurrentDoctorGuid);
            window.Show();
        }

        private void tileRegisterNewCertificate_Click(object sender, RoutedEventArgs e)
        {
            if (NFCReader.connectCard())
            {
                string studentGuid = NFCReader.getcardUID();
                student student = StudentController.Find(studentGuid);
                if (student != null)
                {
                    AbsMedWindow window = new AbsMedWindow(student, CurrentDoctorGuid);
                    window.Show();
                }
            }
        }
        #endregion Event
    }
}
