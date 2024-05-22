using System;
using System.Collections.Generic;
using System.Text;
using OopLaba8.Documents;

namespace OopLaba8.Users
{
    public abstract class UserProfile
    { 
        HashSet<Document>hashSet;
    private string name;
    private string surname;
    private string email;
    private string phoneNumber;
    private int AmountTakenDocuments;

    public List<Document> getListOfTakenDocuments() {
        return listOfTakenDocuments;
    }

    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public string getSurname() {
        return surname;
    }

    public void setSurname(string surname) {
        this.surname = surname;
    }

    public string getEmail() {
        return email;
    }

    public void setEmail(string email) {
        this.email = email;
    }

    public string getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(string phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public int getAmountTakenDocuments() {
        return AmountTakenDocuments;
    }

    public void setAmountTakenDocuments(int amountTakenDocuments) {
        AmountTakenDocuments = amountTakenDocuments;
    }

    private List<Document> listOfTakenDocuments;

    public UserProfile(string name, string surname, string email, string phoneNumber) {
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.phoneNumber = phoneNumber;
        AmountTakenDocuments = 0;
        listOfTakenDocuments = new List<Document>();
        hashSet=new HashSet<Document>();
    }

    public UserProfile() {
    }

    public HashSet<Document> getHashSet() {
        return hashSet;
    }

    public void setHashSet(HashSet<Document> hashSet) {
        this.hashSet = hashSet;
    }
    
    public override string ToString() {
        return "Regular user{" +
                "name='" + name + '\'' +
                ", surname='" + surname + '\'' +
                ", email='" + email + '\'' +
                ", phoneNumber='" + phoneNumber + '\'' +
                ", AmountTakenDocuments=" + AmountTakenDocuments +
                ", listOfTakenDocuments=" + makeListInLine(listOfTakenDocuments ) +
                '}';
    }

    public String beautifulOutput() {
        return "User type : Regular user" + "\n" +
                "User name : " + this.name + "\n" +
                "User surname : " + this.surname + "\n" +
                "User email : " + this.email + "\n" +
                "User phoneNumber : " + this.phoneNumber + "\n" +
                "User AmountTakenDocuments : " + this.AmountTakenDocuments + "\n" +
                "User listOfTakenDocuments : " + makeListInLine(this.listOfTakenDocuments)  + "\n";
    }

    public int printAllAtributes() {
        Console.WriteLine("1 name");
        Console.WriteLine("2 surname");
        Console.WriteLine("3 email");
        Console.WriteLine("4 phoneNumber");
        return 4;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    protected string makeListInLine(List<Document> list)
    {
        StringBuilder stringBuilder = new StringBuilder("[");
        foreach (var i in list)
        {
            stringBuilder.Append(i.ToString() + "\t");
        }

        stringBuilder.Append("]");
        return stringBuilder.ToString();
    }
    }
}