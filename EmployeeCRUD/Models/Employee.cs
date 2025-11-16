using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        public int EmployeeID { get; set;}

        [Required(ErrorMessage = "Nama Wajib diisi!!")]
        [StringLength(20, ErrorMessage = "Nama Maksimal 100 Character")]
        public string Name { get; set; }

        
        [StringLength(50, ErrorMessage = "Tempat Lahir Maksimal 50 Character")]
        public string PlaceOfBirth { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Tanggal Wajib Diisi")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gaji pokok harus diisi")]
        [Range(0, 99999999, ErrorMessage = "Gaji Pokok Tidak Valid")]
        public decimal BasicSalary { get; set;}

        [StringLength(1, ErrorMessage = "Gender Wajib Diisi")]
        public string Gender { get; set; }

        [StringLength(20, ErrorMessage = "Status Pernikahan Wajib Diisi")]
        public string MaritalStatus { get; set;}

    }
}