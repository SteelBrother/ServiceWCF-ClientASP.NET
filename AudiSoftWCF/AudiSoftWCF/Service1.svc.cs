using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AudiSoftWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        string Connection_string = ConfigurationManager.ConnectionStrings["AudiSoftConnectionString"].ConnectionString.ToString();

        #region Student
        public Student CreateStudent(Student student)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Student(Nombre) values (@Nombre)", con);
            cmd.Parameters.AddWithValue("@Nombre", student.Nombre);
            cmd.ExecuteNonQuery();
            con.Close();
            return student;
        }
        public void DeleteStudent(int Id)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Delete FROM Student WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            SqlConnection con = new SqlConnection(Connection_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    students.Add(new Student(Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
                }
            }

            con.Close();
            return students;
        }
        public Student SelectStudent(int Id)
        {
            Student student = new Student(0, "");
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Select * FROM Student WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student.Id = reader.GetInt32(0);
                    student.Nombre = reader.GetString(1);
                }
            }
            con.Close();
            reader.Close();
            return student;
        }
        public Student UpdateStudent(Student student)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Update Student SET Nombre = @Nombre WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Nombre", student.Nombre);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return student;
        }
        #endregion

        #region Teacher
        public Teacher CreateTeacher(Teacher teacher)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Teacher(Nombre) values (@Nombre)");
            cmd.Parameters.AddWithValue("@Nombre", teacher.Nombre);
            cmd.ExecuteNonQuery();
            con.Close();
            return teacher;
        }
        public void DeleteTeacher(int Id)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Delete FROM Teacher WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public IEnumerable<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            SqlConnection con = new SqlConnection(Connection_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Teacher", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    teachers.Add(new Teacher(Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
                }
            }

            con.Close();
            return teachers;
        }
        public Teacher SelectTeacher(int Id)
        {
            Teacher teacher = new Teacher(0, "");
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Select * FROM Teacher WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teacher.Id = reader.GetInt32(0);
                    teacher.Nombre = reader.GetString(1);
                }
            }
            con.Close();
            reader.Close();
            return teacher;
        }
        public Teacher UpdateTeacher(Teacher teacher)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Update Teacher SET Nombre = @Nombre WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", teacher.Id);
            cmd.Parameters.AddWithValue("@Nombre", teacher.Nombre);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return teacher;
        }
        #endregion

        #region Note
        public Note CreateNote(Note note)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Note(Nombre, idProfesor, idEstudiante, Valor) values (@Nombre, @idProfesor, @idEstudiante, @Valor)");
            cmd.Parameters.AddWithValue("@Nombre", note.Nombre);
            cmd.Parameters.AddWithValue("@idProfesor", note.idProfesor);
            cmd.Parameters.AddWithValue("@idEstudiante", note.idEstudiante);
            cmd.Parameters.AddWithValue("@Valor", note.Valor);
            cmd.ExecuteNonQuery();
            con.Close();
            return note;
        }
        public void DeleteNote(int Id)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Delete FROM Note WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public IEnumerable<Note> GetAllNotes()
        {
            List<Note> notes = new List<Note>();
            SqlConnection con = new SqlConnection(Connection_string);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Note", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    notes.Add(new Note(Convert.ToInt32(dr[0].ToString()), dr[1].ToString(), Convert.ToInt32(dr[2].ToString()), Convert.ToInt32(dr[3].ToString()), dr[4].ToString()));
                }
            }

            con.Close();
            return notes;
        }
        public Note SelectNote(int Id)
        {
            Note note = new Note(0, "", 0, 0, "");
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Select * FROM Note WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    note.Id = reader.GetInt32(0);
                    note.Nombre = reader.GetString(1);
                    note.idProfesor = reader.GetInt32(2);
                    note.idEstudiante = reader.GetInt32(3);
                    note.Valor = reader.GetString(4);
                }
            }
            con.Close();
            reader.Close();
            return note;
        }
        public Note UpdateNote(Note note)
        {
            SqlConnection con = new SqlConnection(Connection_string);
            SqlCommand cmd = new SqlCommand("Update Note SET Nombre = @Nombre, idProfesor=@idProfesor,idEstudiante=@idEstudiante, Valor=@Valor WHERE Id = @Id");
            cmd.Parameters.AddWithValue("@Nombre", note.Nombre);
            cmd.Parameters.AddWithValue("@idProfesor", note.idProfesor);
            cmd.Parameters.AddWithValue("@idEstudiante", note.idEstudiante);
            cmd.Parameters.AddWithValue("@Valor", note.Valor);
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return note;
        }
        #endregion
    }
}
