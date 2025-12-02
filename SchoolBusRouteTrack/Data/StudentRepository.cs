using SchoolBusRouteTrack.AdministratorSystem;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SchoolBusRouteTrack.Data
{
    internal class StudentRepository
    {
        private DBHelper _db = new DBHelper();

        public bool InsertStudent(Student student)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", student._name),
                new SqlParameter("@Latitude", student._address.Latitude),
                new SqlParameter("@Longitude", student._address.Longitude),
                new SqlParameter("@Address", student._address.FullAddress),
                new SqlParameter("@Grade", student._grade),
                new SqlParameter("@GuardianName", student._guardianName),
                new SqlParameter("@GuardianRelationship", student._guardianRelationship),
                new SqlParameter("@GuardianPhone", student._guardianPhone),
                new SqlParameter("@SchoolID", student._schoolID),
                new SqlParameter("@SpecialCare", student._specialCare ?? (object)DBNull.Value)
            };

            return _db.ExecuteNonQuerySP("sp_InsertStudent", parameters) > 0;
        }

        public List<Student> GetAllStudents()
        {
            DataTable dt = _db.ExecuteDataTable("sp_GetAllStudents");
            List<Student> students = new List<Student>();

            foreach (DataRow row in dt.Rows)
            {
                var location = new MapLocation(
                    Convert.ToDouble(row["Latitude"]),
                    Convert.ToDouble(row["Longitude"]),
                    row["Address"].ToString(),
                    Convert.ToInt32(row["StudentID"])
                );

                students.Add(new Student(
                    Convert.ToInt32(row["StudentID"]),
                    row["FullName"].ToString(),
                    location,
                    row["Grade"].ToString(),
                    row["GuardianName"].ToString(),
                    row["GuardianRelationship"].ToString(),
                    row["GuardianPhone"].ToString(),
                    Convert.ToInt32(row["SchoolID"]),
                    row["SpecialCare"].ToString()
                ));
            }

            return students;
        }

        public bool DeleteStudent(int studentID)
        {
            SqlParameter[] prm = { new SqlParameter("@StudentID", studentID) };
            return _db.ExecuteNonQuerySP("sp_DeleteStudent", prm) > 0;
        }
    }
}
