using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Component
{
    /// <summary>
    /// tamami asamie session haye system dar in class mojod ast
    /// </summary>
    public static class SessionType
    {
        /// <summary>
        /// etelate kar haye ghabele dastras karbar
        /// </summary>
        public static string Works
        {
            get { return "Works"; }
        }


        /// <summary>
        /// etelate client dar sessioni ast ke namash in hast
        /// </summary>
        public static string ClientInfo
        {
            
            get { return "Log"; }
        }

        /// <summary>
        /// username admin bad az log in kardan dar session be in esm ghara darad
        /// </summary>
        public static string Admin
        {
            
            get { return "Admin"; }
        }

        /// <summary>
        /// usename negahbani dar session be in esm negahdari mishavad
        /// </summary>
        public static string Security
        {
            
            get { return "Security"; }
        }
        /// <summary>
        /// shomare satre emtekhab shodeye marbot b gridview ra dar khod zakhire mikonad
        /// </summary>
        public static string RowIndex
        {
            
            get { return "RowIndex"; }
        }
        public static string MSG
        {
            
            get { return "MSG"; }
        }
        public static string Color
        {
           
            get { return "Color"; }
        }
        public static string WorkingGroup
        {
           
            get { return "WorkingGroup"; }
        }
        public static string Employee
        {

            get { return "Employee"; }
        }
        public static string Register
        {
            
            get { return "Register"; }
        }
        /// <summary>
        /// adrese file akse karbar
        /// </summary>
        public static string ClientImage
        {
            get { return "ClientImage"; }
        }
        /// <summary>
        /// etelate client
        /// </summary>
        public static string Client
        {
            get { return "Client"; }
        }
        public static string UserID
        {
            get { return "UserID"; }
        }
        public static string UserId_EmployeeRegistration
        {
            get { return "EmployeeRegistration_UserId"; }
        }

        public static string TrafficCount_Cardex
        {
            get { return "TrafficCount_Cardex"; }
        }
        public static string TrafficCount_TrafiicList
        {
            get { return "TrafficCount_TrafiicList"; }
        }
        public static string FileName
        {
            get { return "FileName"; }
        }
        public static string ID { get { return "ID"; } }

        public static string No
        {
            get { return "No"; }
        }
        public static string PaperEvaluation
        {
            get { return "PaperEvaluation"; }
        }
    }
}