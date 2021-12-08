using MRA_Client.DataAccess;
using MRA_Web_Application.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MRA_Web_Application.Controller {
    public class LoginController {
        internal static Student GetUser(string roll, string password) {
            string sql = @"SELECT * FROM Student WHERE roll = @roll AND password = @password";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@roll", SqlDbType.NChar) {Value = roll},
                new SqlParameter("@password", SqlDbType.NVarChar) {Value = password}
            };
            if (DAO.GetDataBySQL(sql, parameters).Rows.Count == 0) {
                return null;
            }
            DataRow item = DAO.GetDataBySQL(sql, parameters).Rows[0];

            string rollStudent = item["roll"].ToString();
            string name = item["name"].ToString();
            string gender = item["gender"].ToString();
            string address = item["address"].ToString();
            string email = item["email"].ToString();
            string phone = item["phone"].ToString();

            return new Student(rollStudent, name, gender, address, email, phone);



        }
    }
}