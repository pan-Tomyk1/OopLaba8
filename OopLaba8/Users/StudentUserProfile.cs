using System;

namespace OopLaba8.Users
{
    public class StudentUserProfile : UserProfile
    {
        protected int course;

    public int getCourse() {
        return course;
    }

    public string getFaculty() {
        return faculty;
    }

    public string getGroup() {
        return group;
    }

    public string getFieldOfKnowledge() {
        return fieldOfKnowledge;
    }

    public void setCourse(int course) {
        this.course = course;
    }

    public void setFaculty(string faculty) {
        this.faculty = faculty;
    }

    public void setGroup(string group) {
        this.group = group;
    }

    public void setFieldOfKnowledge(string fieldOfKnowledge) {
        this.fieldOfKnowledge = fieldOfKnowledge;
    }

    protected string faculty;
    protected string group;
    protected string fieldOfKnowledge;

    public StudentUserProfile(string name, string surname, string email, string phoneNumber, int course, string faculty, string group, string fieldOfKnowledge) 
        :base(name, surname, email, phoneNumber){
        this.course = course;
        this.faculty = faculty;
        this.group = group;
        this.fieldOfKnowledge = fieldOfKnowledge;
    }

    public StudentUserProfile() {
    }
    
    public override string ToString() {
       return  "Student{" +
               "name='" + this.getName() + '\'' +
               ", surname='" + this.getSurname() + '\'' +
               ", email='" + this.getEmail() + '\'' +
               ", phoneNumber='" + this.getPhoneNumber() + '\'' +
               ", AmountTakenDocuments=" + this.getAmountTakenDocuments() +'\'' +
               ", listOfTakenDocuments=" + makeListInLine(this.getListOfTakenDocuments())  +'\'' +
               ", course='"+this.getCourse()+'\''+
               ", faculty='"+this.getFaculty()+'\''+
               ", group='"+this.getGroup()+'\''+
               ", fieldOfKnowledge='"+this.getFieldOfKnowledge()+'\''+
               '}';
    }
    public string beautifulOutput(){
        return "User type : Student" +"\n"+
                "User name : " +this.getName()+"\n"+
                "User surname : " +this.getSurname()+"\n"+
                "User email : " +this.getEmail()+"\n"+
                "User phoneNumber : " +this.getPhoneNumber()+"\n"+
                "User course : " +this.getCourse()+"\n"+
                "User faculty : " +this.getFaculty()+"\n"+
                "User group : " +this.getGroup()+"\n"+
                "User fieldOfKnowledge : " +this.getFieldOfKnowledge()+"\n"+
                "User AmountTakenDocuments : " +this.getAmountTakenDocuments()+"\n"+
                "User listOfTakenDocuments : " + makeListInLine(this.getListOfTakenDocuments()) +"\n";
    }
    public int printAllAtributes() {
        Console.WriteLine("1 name");
        Console.WriteLine("2 surname");
        Console.WriteLine("3 email");
        Console.WriteLine("4 phoneNumber");
        Console.WriteLine("5 course");
        Console.WriteLine("6 faculty");
        Console.WriteLine("7 group");
        Console.WriteLine("8 fieldOfKnowledge");
        return 8;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    }
}