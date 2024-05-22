using System;
using OopLaba8.DataMaintenance;

namespace OopLaba8
{
    internal class Program
    {
        private static string adminName = "Artem";
        private static string adminSurname = "Danyliuk";
        private static string adminEmail = "danyliuk.artem@lll.kpi.ua";
        private static string adminPhoneNumber = "0965616886";
        private static Administrator administrator = new Administrator(adminName, adminSurname, adminEmail, adminPhoneNumber);

    public static void Main(string[] args)
    {
        Program main = new Program();
        while(true){
            main.runProgram();
        }
    }

    private void mainMenu() {
        Console.WriteLine("1 Manage Library Users");
        Console.WriteLine("2 Management of library documents (literature)");
        Console.WriteLine("3 Document Issuance Management");
        Console.WriteLine("4 Search");
        Console.WriteLine("5 Exit program");
    }
    private void runProgram(){

        Console.WriteLine("-----STUDENT LIBRARY: ACCOUNTING OF LITERATURE AND READER FORMS-----");
        switch (mainMenu_ChooseWorkOption()) {
            case 1: {
                switch (managingReaders_ChooseWorkOption()) {
                    case 1: {
                        administrator.addUser();
                        break;
                    }
                    case 2: {
                        administrator.deleteUser();
                        break;
                    }
                    case 3: {
                        administrator.editUserProfile();
                        break;
                    }
                    case 4: {
                        administrator.printIndividualUser();
                        break;
                    }
                    case 5: {
                        administrator.printAllUsers();
                        break;
                    }
                    case 6: {
                        administrator.sortListOfUsers();
                        break;
                    }
                }
                break;
            }
            case 2:{
                switch (documentManagement_ChooseWorkOption()){
                    case 1 :{
                        administrator.addDocument();
                        break;}
                    case 2 :{
                        administrator.deleteDocument();
                        break;}
                    case 3 :{
                        administrator.editDocument();
                        break;}
                    case 4 :{
                        administrator.printIndividualDocument();
                        break;}
                    case 5 :{
                        administrator.printAllDocuments();
                        break;}
                    case 6 :{
                        administrator.sortListOfDocuments();
                        break;}
                }
                break;
            }
            case 3:{
                switch (documentIssuanceManagement_ChooseWorkOption()){
                    case 1 :{
                        administrator.borrowBook();
                        break;}
                    case 2 :{
                        administrator.findDocumentLocation();
                        break;}
                    case 3 :{
                        administrator.returnBookToLibrary();
                        break;}
                }
                break;
            }
            case 4:{
                switch (search_ChooseWorkOption()){
                    case 1 :{
                        administrator.searchUser();
                        break;}
                    case 2 :{
                        administrator.searchDocument();
                        break;}
                }
                break;
            }
            case 5 :{
                Environment.Exit(0);
                break;
            }
        }
    }

    private int mainMenu_ChooseWorkOption() {
        mainMenu();
        Console.WriteLine("Select the option to work with the system");
        Console.WriteLine("Please enter a number between 1 and 5");
        return InputOutput.enterInt(5, 1);
    }

    private void managingReaders_Menu() {
        Console.WriteLine("1 Add a user");
        Console.WriteLine("2 Delete a user");
        Console.WriteLine("3 Change user information");
        Console.WriteLine("4 View user information");
        Console.WriteLine("5 View a list of all users");
        Console.WriteLine("6 Sort");
    }

    private int managingReaders_ChooseWorkOption() {
        managingReaders_Menu();
        Console.WriteLine("Select the option to work with managing readers");
        Console.WriteLine("Please enter a number between 1 and 6");
        return InputOutput.enterInt(6, 1);
    }

    private void documentManagement_Menu() {
        Console.WriteLine("1 Add a document");
        Console.WriteLine("2 Delete a document");
        Console.WriteLine("3 Change document information");
        Console.WriteLine("4 View document information");
        Console.WriteLine("5 View a list of all document");
        Console.WriteLine("6 Sort");
    }

    private int documentManagement_ChooseWorkOption() {
        documentManagement_Menu();
        Console.WriteLine("Select the option to work with managing documents");
        Console.WriteLine("Please enter a number between 1 and 6");
        return InputOutput.enterInt(6, 1);
    }

    private void documentIssuanceManagement_Manu() {
        Console.WriteLine("1 Lend the user a document");
        Console.WriteLine("2 Determine by the document which user he is in");
        Console.WriteLine("3 Return document to the library");
    }

    private int documentIssuanceManagement_ChooseWorkOption() {
        documentIssuanceManagement_Manu();
        Console.WriteLine("Select the option to work with document issuance management");
        Console.WriteLine("Please enter a number between 1 and 3");
        return InputOutput.enterInt(3, 1);
    }

    private void search_Menu() {
        Console.WriteLine("1 Search for a given word among users");
        Console.WriteLine("2 Search for a given word among documents");
    }

    private int search_ChooseWorkOption() {
        search_Menu();
        Console.WriteLine("Select the option to work with searching");
        Console.WriteLine("Please enter a number between 1 and 2");
        return InputOutput.enterInt(2, 1);
    }
    }
}