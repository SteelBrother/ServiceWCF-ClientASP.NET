using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AudiSoftWCF
{
    [ServiceContract]
    public interface IService1
    {

        #region operations
        [OperationContract]
        Student CreateStudent(Student student);

        [OperationContract]
        Student UpdateStudent(Student student);

        [OperationContract]
        void DeleteStudent(int Id);

        [OperationContract]
        Student SelectStudent(int Id);

        [OperationContract]
        IEnumerable<Student> GetAllStudents();

        [OperationContract]
        Teacher CreateTeacher(Teacher teacher);

        [OperationContract]
        Teacher UpdateTeacher(Teacher teacher);

        [OperationContract]
        void DeleteTeacher(int Id);

        [OperationContract]
        Teacher SelectTeacher(int Id);

        [OperationContract]
        IEnumerable<Teacher> GetAllTeachers();

        [OperationContract]
        Note CreateNote(Note note);

        [OperationContract]
        Note UpdateNote(Note note);

        [OperationContract]
        void DeleteNote(int Id);

        [OperationContract]
        Note SelectNote(int Id);
        [OperationContract]
        IEnumerable<Note> GetAllNotes();
        #endregion
    }

}
