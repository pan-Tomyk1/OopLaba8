using System;

namespace OopLaba8.Users
{
    public class TeacherUserProfile : UserProfile
    {
         public void setAdvancedDegree(string advancedDegree) {
        this.advancedDegree = advancedDegree;
    }

    public void setScopeOfTeaching(string scopeOfTeaching) {
        this.scopeOfTeaching = scopeOfTeaching;
    }

    protected string advancedDegree;

    public string getAdvancedDegree() {
        return advancedDegree;
    }

    public string getScopeOfTeaching() {
        return scopeOfTeaching;
    }

    protected string scopeOfTeaching;
    public TeacherUserProfile(string name, string surname, string email, string phoneNumber, string advancedDegree, string scopeOfTeaching) 
        :base(name, surname, email, phoneNumber){
        this.advancedDegree = advancedDegree;
        this.scopeOfTeaching = scopeOfTeaching;
    }

    public TeacherUserProfile() {
    }

    public override string ToString() {
        return "Teacher{" +
                "name='" + this.getName() + '\'' +
                ", surname='" + this.getSurname() + '\'' +
                ", email='" + this.getEmail() + '\'' +
                ", phoneNumber='" + this.getPhoneNumber() + '\'' +
                ", AmountTakenDocuments=" + this.getAmountTakenDocuments() +'\'' +
                ", listOfTakenDocuments=" + makeListInLine(this.getListOfTakenDocuments())  +'\'' +
                ", advancedDegree='"+this.getAdvancedDegree()+'\''+
                ", scopeOfTeaching='"+this.getScopeOfTeaching()+'\''+
                '}';
    }
    public string beautifulOutput(){
        return "User type : Teacher" +"\n"+
                "User name : " +this.getName()+"\n"+
                "User surname : " +this.getSurname()+"\n"+
                "User email : " +this.getEmail()+"\n"+
                "User phoneNumber : " +this.getPhoneNumber()+"\n"+
                "User advancedDegree : " +this.getAdvancedDegree()+"\n"+
                "User scopeOfTeaching : " +this.getScopeOfTeaching()+"\n"+
                "User AmountTakenDocuments : " +this.getAmountTakenDocuments()+"\n"+
                "User listOfTakenDocuments : " + makeListInLine(this.getListOfTakenDocuments()) +"\n";
    }
    public int printAllAtributes() {
        Console.WriteLine("1 name");
        Console.WriteLine("2 surname");
        Console.WriteLine("3 email");
        Console.WriteLine("4 phoneNumber");
        Console.WriteLine("5 advancedDegree");
        Console.WriteLine("6 scopeOfTeaching");
        return 6;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    }
}