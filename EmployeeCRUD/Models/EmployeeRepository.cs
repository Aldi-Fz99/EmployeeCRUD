using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using EmployeeCRUD.DAL;

namespace EmployeeCRUD.Models
{
    public class EmployeeRepository
    {
        DBContext db = new DBContext();

        // get all
        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Employee
                {
                    EmployeeID = Convert.ToInt32(rdr["EmployeeID"]),
                    Name = rdr["Name"].ToString(),
                    PlaceOfBirth = rdr["PlaceOfBirth"].ToString(),
                    DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]),
                    BasicSalary = Convert.ToDecimal(rdr["BasicSalary"]),
                    Gender = rdr["Gender"].ToString(),
                    MaritalStatus = rdr["MaritalStatus"].ToString()
                });
            }
            con.Close();
            return list;
        }

        // Add
        public bool Add(Employee emp)
        {
            SqlConnection con = db.GetConnection();
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Employess ( Name, PlaceOfBirth, DateOfBirth, BasicSalary, Gender, MatrialStatus) " +
                "VALUES ( @Name, @PlaceOfBirth, @DateOfBirth, @BasicSalary @Gender, @MatrialStatus)", con
             );

            cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@PlaceOfBirth", emp.PlaceOfBirth);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
            cmd.Parameters.AddWithValue("@BasicSalary", emp.BasicSalary);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@MaritalStatus", emp.MaritalStatus);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1;
        }

        // Get By ID
        public Employee GetById(int id)
        {
            Employee emp = new Employee();
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", id);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                emp.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                emp.Name = rdr["Name"].ToString();
                emp.PlaceOfBirth = rdr["PlaceOfBirth"].ToString();
                emp.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);
                emp.BasicSalary = Convert.ToDecimal(rdr["BasicSalary"]);
                emp.Gender = rdr["Gender"].ToString();
                emp.MaritalStatus = rdr["MaritalStatus"].ToString();
            }
            con.Close();
            return emp;
        }

        // Update
        public bool Update(Employee emp)
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand(
             "UPDATE Employee SET Name=@Name, PlaceOfBirth=@PlaceOfBirth, " + 
             "DateOfBirth=@DateOfBisrt, BasicSalary=@BasicSalary Gender=@Gender, MaritalStatus=@MaritalStatus " +
             "WHERE EmployeeID=@EmployeID", con );

            cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@PlaceOfBirth", emp.PlaceOfBirth);
            cmd.Parameters.AddWithValue("@DateOfBirth", emp.DateOfBirth);
            cmd.Parameters.AddWithValue("@BasicSalary", emp.BasicSalary);
            cmd.Parameters.AddWithValue("@Gender", emp.Gender);
            cmd.Parameters.AddWithValue("@MaritalStatus", emp.MaritalStatus);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1;
        }

        // Delete
        public bool Delete(int id)
        {
            SqlConnection con = db.GetConnection();

            SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i >= 1;

        }

    }
}