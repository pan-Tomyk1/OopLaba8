using System;
using System.Collections.Generic;
using OopLaba8.Users;

namespace OopLaba8.DataMaintenance
{
    public class UserMaintaining
    {
        private const int MAX_STRING_INPUT_LENGTH = 30;
    private const int MAX_PHONE_NUMBER_LENGTH = 10;
    static UserMaintaining userMaintaining= new UserMaintaining();
    public static UserProfile addUser() {

        int userType = userMaintaining.chooseUserType();
        Console.WriteLine("---Enter user data");
        string name = userMaintaining.enterName();
        string surname=userMaintaining.enterSurname();
        string email=userMaintaining.enterEmail();
        string phoneNumber=userMaintaining.enterPhoneNumber();
        switch (userType) {
            case 1: {
                return new RegularUserProfile(name, surname, email, phoneNumber);
            }
            case 2: {
                int course =userMaintaining.enterCourse();
                string faculty = userMaintaining.enterFaculty();
                string group = userMaintaining.enterGroup();
                string fieldOfKnowledge = userMaintaining.enterFieldOfKnowledge();
                return new StudentUserProfile(name, surname, email, phoneNumber, course, faculty, group, fieldOfKnowledge);

            }
            case 3: {
                string advancedDegree = userMaintaining.enterAdvancedDegree();
                string scopeOfTeaching = userMaintaining.enterScopeOfTeaching();
                return new TeacherUserProfile(name, surname, email, phoneNumber, advancedDegree, scopeOfTeaching);

            }
        }
        return null;
    }

    public string enterName(){
        Console.WriteLine("-Enter the user name");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    public string enterSurname(){
        Console.WriteLine("-Enter the user surname");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterEmail(){
        Console.WriteLine("-Enter the user email");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterPhoneNumber(){
        string phoneNumber;
        do{
            Console.WriteLine("-Enter the user phoneNumber");
            phoneNumber = enterStringData(MAX_PHONE_NUMBER_LENGTH);
        }while(Validation.validatePhoneNumber(phoneNumber.ToCharArray()));
        return phoneNumber;
    }
    private int enterCourse(){
        Console.WriteLine("-Enter the course");
        return InputOutput.enterInt(8, 1);
    }
    private string enterFaculty(){
        Console.WriteLine("-Enter the faculty");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterGroup(){
        Console.WriteLine("-Enter the group");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterAdvancedDegree(){
        Console.WriteLine("-Enter the advancedDegree");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterFieldOfKnowledge(){
        Console.WriteLine("-Enter the fieldOfKnowledge");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterScopeOfTeaching(){
        Console.WriteLine("-Enter the scopeOfTeaching");
        return enterStringData(MAX_STRING_INPUT_LENGTH);
    }
    private string enterStringData(int maxLength) {
        string input;
        bool checkAtribute;
        do {
            input = InputOutput.enterString();
            checkAtribute = input.Length <= maxLength;
            if (!checkAtribute) {
                Console.WriteLine("Invalid input, input is too long");
            }
        } while (!checkAtribute);
        return input;
    }
    private int chooseUserType() {
        Console.WriteLine("Select user type");
        printTypeOfUsers();
        return InputOutput.enterInt(3, 1);
    }
    public static void printTypeOfUsers() {
        Console.WriteLine("1 Regular library user");
        Console.WriteLine("2 Student");
        Console.WriteLine("3 Teacher");
    }
    public static void editProfile(Statistics statistics) {
        if(statistics.getAmountUsers()==0){
            Console.WriteLine("No users found, add reader first");
            return;
        }
        UserMaintaining.printAllUsers(statistics);
        Console.WriteLine("Select the user you want to edit the data, max = "+(statistics.getAmountUsers())+", min = 1");
        int userIndex=InputOutput.enterInt((statistics.getAmountUsers()),1);
        UserProfile user=statistics.getUser(userIndex-1);
        Console.WriteLine(user.beautifulOutput());
        Console.WriteLine("What data do you want to edit?");
        int numberOfAtributes=user.printAllAtributes();
        Console.WriteLine("Please select the data you want to edit, max="+numberOfAtributes+", min=1");
        int dataType = InputOutput.enterInt(numberOfAtributes, 1);
        switch (dataType){
            case 1:{
                user.setName(userMaintaining.enterName());
                break;}
            case 2:{
                user.setSurname(userMaintaining.enterSurname());
                break;}
            case 3:{
                user.setEmail(userMaintaining.enterEmail());
                break;}
            case 4:{
                user.setPhoneNumber(userMaintaining.enterPhoneNumber());
                break;}
            case 5: {
                if(user.GetType()==typeof(StudentUserProfile)){
                    ((StudentUserProfile) user).setCourse(userMaintaining.enterCourse());
                }else{
                    ((TeacherUserProfile) user).setAdvancedDegree(userMaintaining.enterAdvancedDegree());
                }
                break;
            }
            case 6: {
                if(user.GetType()==typeof(StudentUserProfile)){
                    ((StudentUserProfile) user).setFaculty(userMaintaining.enterFaculty());
                }else{
                    ((TeacherUserProfile) user).setScopeOfTeaching(userMaintaining.enterScopeOfTeaching());
                }
                break;
            }
            case 7:{
                ((StudentUserProfile) user).setGroup(userMaintaining.enterGroup());
                break;
            }
            case 8:{
                ((StudentUserProfile) user).setFieldOfKnowledge(userMaintaining.enterFieldOfKnowledge());
                break;
            }
        }
    }
    public static void printAllUsers(Statistics statistics) {

        Console.WriteLine("No. | User");
        Console.WriteLine("----|--------------------------------------------------------------------------------------------------------");
        for (int i = 0; i < statistics.getAmountUsers(); i++) {
            Console.WriteLine( i + 1+"|"+ statistics.getListOfUsers()[i]);
        }
        Console.WriteLine("----|--------------------------------------------------------------------------------------------------------");
    }
    public static void deleteUser(Statistics statistics){
        if(statistics.getAmountUsers()==0){
            Console.WriteLine("No users found, add reader first");
            return;
        }
        UserMaintaining.printAllUsers(statistics);
        Console.WriteLine("Select the user you want to delete, max = "+(statistics.getAmountUsers())+", min = 1");
        int userIndex=InputOutput.enterInt((statistics.getAmountUsers()),1)-1;
        UserProfile userProfile=statistics.getUser(userIndex);
        statistics.getListOfUsers().Remove(userProfile);
        statistics.setAmountUsers(statistics.getListOfUsers().Count);
    }
    public static void printIndividualUser(Statistics statistics){
        if(statistics.getAmountUsers()==0){
            Console.WriteLine("No users found, add reader first");
            return;
        }
        UserMaintaining.printAllUsers(statistics);
        Console.WriteLine("Select the user you want to see, max = "+(statistics.getAmountUsers())+", min = 1");
        int userIndex=InputOutput.enterInt((statistics.getAmountUsers()),1)-1;
        Console.WriteLine(statistics.getUser(userIndex).beautifulOutput());
    }
    public static List<UserProfile> findUserByTheName(string name, Statistics statistics){
        List<UserProfile> arrayList = new List<UserProfile>();
        foreach(var i in statistics.getListOfUsers()){
            if(i.getName().Contains(name)){
                arrayList.Add(i);
            }
        }
        return arrayList;
    }
    public static List<UserProfile> findUserByTheSurname(string surname, Statistics statistics){
        List<UserProfile> arrayList = new List<UserProfile>();
        foreach(var i in statistics.getListOfUsers()){
            if(i.getSurname().Contains(surname)){
                arrayList.Add(i);
            }
        }
        return arrayList;
    }
    public static List<UserProfile> findUserByTheType(UserProfile user, Statistics statistics){
      List<UserProfile> arrayList = new List<UserProfile>();
        foreach(var i in statistics.getListOfUsers()){
            if(i.GetType()==user.GetType()){
                arrayList.Add(i);
            }
        }
        return arrayList;
    }

    }
}