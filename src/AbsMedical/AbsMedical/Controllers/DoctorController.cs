﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbsMedical.Data;
using AbsMedical.Utils;

namespace AbsMedical.Controllers
{
    public class DoctorController
    {
        /// <summary>
        /// Get a doctor object in the Database by its email and password
        /// </summary>
        /// <param name="email">Email of the doctor</param>
        /// <param name="password">Password of the doctor</param>
        /// <returns>A doctor object</returns>
        public static doctor Find(string email, string password)
        {
            string md5Password = Encryption.GetMD5Hash(password);
            using (rfidEntities db = new rfidEntities())
            {
                var query = db.doctor.FirstOrDefault(d => d.Email == email && d.Password == md5Password);
                //var query2 = (from d in db.doctor where d.Email == email && d.Password == md5Password select d).FirstOrDefault();
                return query;
            }
        }

        /// <summary>
        /// Add a doctor object in the Database
        /// </summary>
        /// <param name="doctor">doctor object to add</param>
        /// <returns>Boolean indicating if the insertion was made</returns>
        public static bool Create (doctor doctor)
        {
            using (rfidEntities db = new rfidEntities())
            {
                try
                {
                    db.doctor.Add(doctor);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Update doctor informations
        /// </summary>
        /// <param name="doctor">doctor object to update</param>
        /// <returns>Boolean indicating if the insertion was made</returns>
        public static bool Update (doctor doctor)
        {
            using (rfidEntities db = new rfidEntities())
            {
                try
                {
                    db.doctor.Attach(doctor);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}