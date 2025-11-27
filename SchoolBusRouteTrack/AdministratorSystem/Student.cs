namespace SchoolBusRouteTrack.AdministratorSystem
{
    internal class Student
    {
        public string _name { get; private set; }

        public int _studentID { get; private set; }
        public MapLocation _address { get; private set; }
        public string _grade { get; private set; }
        public string _guardianName { get; private set; }
        public string _guardianRelationship { get; private set; }
        public string _guardianPhone { get; private set; }
        public int _schoolID { get; private set; }
        public string _specialCare { get; private set; }
        

        public Student(int studentID, string name, MapLocation address, string grade, string guardianName, string guardianRelationship, string guardianPhone, int schoolID, string specialCare)
        {
            _studentID = studentID;
            _name = name;
            _address = address;
            _grade = grade;
            _guardianName = guardianName;
            _guardianRelationship = guardianRelationship;
            _guardianPhone = guardianPhone;
            _schoolID = schoolID;
            _specialCare = specialCare;
            
        }

        public string getInfo()
        {
            string studentInfo = $"Name: {_name}, Address:{_address.FullAddress}";
            return studentInfo;
        }
    }
}