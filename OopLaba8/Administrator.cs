using System;
using System.Collections.Generic;
using OopLaba8.DataMaintenance;
using OopLaba8.Documents;
using OopLaba8.Users;

namespace OopLaba8
{
    public class Administrator : UserProfile
    {
        
    private Statistics statistics;

    public Administrator(string name, string surname, string email, string phoneNumber)
        :base(name, surname, email, phoneNumber){
        statistics = new Statistics();
    }

    public void addUser() {
        addUserInList(UserMaintaining.addUser());
        Console.WriteLine("-----User added successfully-----");
    }

    public void editUserProfile() {
        UserMaintaining.editProfile(statistics);
        Console.WriteLine("-----User profile edited successfully-----");
    }

    public void editDocument() {
        DocumentsMaintaining.editDocument(statistics);
        Console.WriteLine("-----Document edited successfully-----");
    }

    private bool addUserInList(UserProfile userProfile) {
        try {
            statistics.addUser(userProfile);
            return true;
        } catch (MyException e) {
            Console.WriteLine("Invalid input, " + e.Message);
            return false;
        }
    }

    private bool addDocumentInList(Document document) {
        try {
            statistics.addDocument(document);
            return true;
        } catch (MyException e) {
            Console.WriteLine("Invalid input, " + e.Message);
            return false;
        }
    }


    public void deleteUser() {
        UserMaintaining.deleteUser(statistics);
        Console.WriteLine("----User deleted successfully-----");
    }

    public void deleteDocument() {
        DocumentsMaintaining.deleteDocument(statistics);
        Console.WriteLine("Document deleted successfully");
    }

    public void printIndividualUser() {
        UserMaintaining.printIndividualUser(statistics);
    }

    public void printIndividualDocument() {
        DocumentsMaintaining.printIndividualDocument(statistics);
    }

    public void sortListOfUsers() {
        if (statistics.getAmountUsers() == 0) {
            Console.WriteLine("No users found, add reader first");
            return;
        }
        Console.WriteLine("Choose what to sort the list");
        Console.WriteLine("1 by name");
        Console.WriteLine("2 by surname");
        int whatToSort = InputOutput.enterInt(2, 1);
        Console.WriteLine("Choose sort type");
        Console.WriteLine("1 Ascending");
        Console.WriteLine("2 Descending");
        int sortType = InputOutput.enterInt(2, 1);
        switch (whatToSort) {
            case 1: {
                if (sortType == 1) {
                    statistics.getListOfUsers().Sort((s1, s2) => s1.getName().CompareTo(s2.getName())) ;
                } else {
                    statistics.getListOfUsers().Sort((s1, s2) => s2.getName().CompareTo(s1.getName())); 
                }
                break;
            }
            case 2: {
                if (sortType == 1) {
                   statistics.getListOfUsers().Sort( (s1, s2) => s1.getSurname().CompareTo(s2.getSurname()));
                } else {
                    statistics.getListOfUsers().Sort( (s1, s2) => s2.getSurname().CompareTo(s1.getSurname()));
                }
                break;
            }
        }
        Console.WriteLine("----List of users sorted successfully-----");
    }

    public void sortListOfDocuments() {
        if (statistics.getAmountDocuments() == 0) {
            Console.WriteLine("No document found, add document first");
            return;
        }
        Console.WriteLine("Choose what to sort the list");
        Console.WriteLine("1 by name");
        Console.WriteLine("2 by author");
        Console.WriteLine("3 by publisher");
        Console.WriteLine("4 by language");
        Console.WriteLine("5 by tags");
        int whatToSort = InputOutput.enterInt(5, 1);
        Console.WriteLine("Choose sort type");
        Console.WriteLine("1 Ascending");
        Console.WriteLine("2 Descending");
        int sortType = InputOutput.enterInt(2, 1);
        switch (whatToSort) {
            case 1: {
                if (sortType == 1) {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s1.getName().CompareTo(s2.getName())); 
                } else {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s2.getName().CompareTo(s1.getName())); 
                }
                break;
            }
            case 2: {
                if (sortType == 1) {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s1.getAuthor().CompareTo(s2.getAuthor()));
                } else {
                    Statistics.getListOfDocuments().Sort( (s1, s2) => s2.getAuthor().CompareTo(s1.getAuthor()));
                }
                break;
            }
            case 3: {
                if (sortType == 1) {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s1.getPublisher().CompareTo(s2.getPublisher()));
                } else {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s2.getPublisher().CompareTo(s1.getPublisher()));
                }
                break;
            }
            case 4: {
                if (sortType == 1) {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s1.getLanguage().CompareTo(s2.getLanguage()));
                } else {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s2.getLanguage().CompareTo(s1.getLanguage()));
                }
                break;
            }
            case 5: {
                if (sortType == 1) {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s1.getTags().CompareTo(s2.getTags())) ;
                } else {
                    Statistics.getListOfDocuments().Sort((s1, s2) => s2.getTags().CompareTo(s1.getTags())) ;
                }
                break;
            }

        }
    }

    public void printAllUsers() {
        UserMaintaining.printAllUsers(statistics);
    }

    public void printAllDocuments() {
        DocumentsMaintaining.printAllDocuments(statistics);
    }

    public void addDocument() {
        addDocumentInList(DocumentsMaintaining.addDocument());
        Console.WriteLine("Document added successfully");
    }

    private UserProfile chooseUser() {
        UserMaintaining.printAllUsers(statistics);
        Console.WriteLine("Please, select a user which wants to lend a book");
        Console.WriteLine("Please, enter a number min = 1, max = " + statistics.getAmountUsers());
        int userIndex = InputOutput.enterInt(statistics.getAmountUsers(), 1);
        return statistics.getUser(userIndex - 1);
    }

    public void borrowBook() {
        if (statistics.getAmountUsers() == 0) {
            Console.WriteLine("No users found, add reader first");
            return;
        }
        if (statistics.getAmountDocuments() == 0) {
            Console.WriteLine("No documents found, add document first");
            return;
        }
        UserProfile user = chooseUser();
        if (user.getAmountTakenDocuments() >= 5) {
            Console.WriteLine("This user took more than 5 books to the library and has not yet returned them.");
            return;
        }
        List<Document> listOfAvailableDocuments=Statistics.getListOfAvailableDocuments();
        int amountAvailableBooks=listOfAvailableDocuments.Count;
        Console.WriteLine(user.beautifulOutput());
        if (amountAvailableBooks <= 0)
        {
            Console.WriteLine("There are no documents available for this user");
        }

        int maxBooksAllowed=5-user.getAmountTakenDocuments();
        if(maxBooksAllowed>amountAvailableBooks){
            maxBooksAllowed=amountAvailableBooks;
        }
        Console.WriteLine("Enter the number of books you want to borrow from the library, min = 1, max = " + maxBooksAllowed);
        int amount = InputOutput.enterInt(maxBooksAllowed - getAmountTakenDocuments(), 1);
        printDocumentList(listOfAvailableDocuments);
        int documentIndex;
        Document document;
        for (int i = 0; i < amount; i++) {
            Console.WriteLine("Select the document you want to borrow for this");
            Console.WriteLine("Enter the document number min = 1, max = " + amountAvailableBooks);
            documentIndex = InputOutput.enterInt(amountAvailableBooks, 1);
            document = listOfAvailableDocuments[documentIndex - 1];
            user.getListOfTakenDocuments().Add(document);
            user.setAmountTakenDocuments(user.getAmountTakenDocuments() + 1);
            user.getHashSet().Add(document);
            document.setInLibrary(false);
            listOfAvailableDocuments.Remove(document);
        }
    }

    public void findDocumentLocation() {
        if (statistics.getAmountDocuments() == 0) {
            Console.WriteLine("No document found, add document first");
            return;
        }
        DocumentsMaintaining.printAllDocuments(statistics);
        Console.WriteLine("Please enter the number of the document you want to locate, min = 1, max = " + statistics.getAmountDocuments());
        int documentIndex = InputOutput.enterInt(statistics.getAmountDocuments(), 1);
        Document document = statistics.getDocument(documentIndex - 1);
        if (!document.isInLibrary()) {
            Console.WriteLine("The document is not in the library, it was borrowed by this user");
            Console.WriteLine(DocumentsMaintaining.locateDocument(document, statistics).beautifulOutput());
        } else {
            Console.WriteLine("The document is in the library");
        }
    }

    public void returnBookToLibrary() {
        if (statistics.getAmountDocuments() == 0) {
            Console.WriteLine("No document found, add document first");
            return;
        }
        if (statistics.getAmountUsers() == 0) {
            Console.WriteLine("No users found, add reader first");
            return;
        }
        UserProfile user = chooseUser();
        if (user.getAmountTakenDocuments() == 0) {
            Console.WriteLine("No taken documents found, borrow a document first");
            return;
        }
        Console.WriteLine("Select the book you want to return");
        for (int i = 0; i < user.getAmountTakenDocuments(); i++) {
            Console.Write((i + 1)+"\t");
            Console.WriteLine(user.getListOfTakenDocuments()[i]);
        }
        int documentIndex = InputOutput.enterInt(user.getAmountTakenDocuments(), 1);
        Document document=user.getListOfTakenDocuments()[documentIndex-1];
        document.setInLibrary(true);
        user.getListOfTakenDocuments().Remove(document);
        user.setAmountTakenDocuments(user.getListOfTakenDocuments().Count);
    }

    public void searchUser() {
        if (statistics.getAmountUsers() == 0) {
            Console.WriteLine("No users found, add reader first");
            return;
        }
        Console.WriteLine("Choose which field you will search");
        Console.WriteLine("1 name");
        Console.WriteLine("2 surname");
        Console.WriteLine("3 type of reader");
        int type = InputOutput.enterInt(3, 1);
        switch (type) {
            case 1: {
                Console.WriteLine("Enter name :");
                String name = InputOutput.enterString();
                printUserList(UserMaintaining.findUserByTheName(name, statistics));
                break;
            }
            case 2: {
                Console.WriteLine("Enter surname :");
                String surname = InputOutput.enterString();
                printUserList(UserMaintaining.findUserByTheSurname(surname, statistics));
                break;
            }
            case 3: {
                UserMaintaining.printTypeOfUsers();
                Console.WriteLine("Select user type min = 1, max = 3");
                int userType = InputOutput.enterInt(3, 1);
                switch (userType) {
                    case 1: {
                        printUserList(UserMaintaining.findUserByTheType(new RegularUserProfile(), statistics));
                        break;
                    }
                    case 2: {
                        printUserList(UserMaintaining.findUserByTheType(new StudentUserProfile(), statistics));
                        break;
                    }
                    case 3: {
                        printUserList(UserMaintaining.findUserByTheType(new TeacherUserProfile(), statistics));
                        break;
                    }
                }
                break;
            }
        }
    }

    public void searchDocument() {
        if (statistics.getAmountDocuments() == 0) {
            Console.WriteLine("No document found, add document first");
            return;
        }
        Console.WriteLine("Choose which field you will search, min = 1, max = 6");
        Console.WriteLine("1 name");
        Console.WriteLine("2 author");
        Console.WriteLine("3 type of document");
        Console.WriteLine("4 publisher");
        Console.WriteLine("5 language");
        Console.WriteLine("6 tags");
        int userChoice = InputOutput.enterInt(6, 1);
        switch (userChoice) {
            case 1: {
                Console.WriteLine("Enter name :");
                String name = InputOutput.enterString();
                printDocumentList(DocumentsMaintaining.findDocumentByTheName(name, statistics));
                break;
            }
            case 2: {
                Console.WriteLine("Enter author :");
                String author = InputOutput.enterString();
                printDocumentList(DocumentsMaintaining.findDocumentByTheAuthor(author, statistics));
                break;
            }
            case 3: {
                int documentType = DocumentsMaintaining.chooseTypeOfDocument();
                switch (documentType) {
                    case 1: {
                        printDocumentList(DocumentsMaintaining.findDocumentByTheType(new Article(), statistics));
                        break;
                    }
                    case 2: {
                        printDocumentList(DocumentsMaintaining.findDocumentByTheType(new Book(), statistics));
                        break;
                    }
                    case 3: {
                        printDocumentList(DocumentsMaintaining.findDocumentByTheType(new Magazine(), statistics));
                        break;
                    }
                }
                break;
            }
            case 4: {
                Console.WriteLine("Enter publisher :");
                String publisher = InputOutput.enterString();
                printDocumentList(DocumentsMaintaining.findDocumentByThePublisher(publisher, statistics));
                break;
            }
            case 5: {
                Console.WriteLine("Enter language :");
                String language = InputOutput.enterString();
                printDocumentList(DocumentsMaintaining.findDocumentByTheLanguage(language, statistics));
                break;
            }
            case 6: {
                Console.WriteLine("Enter tags :");
                String tags = InputOutput.enterString();
                printDocumentList(DocumentsMaintaining.findDocumentByTheTags(tags, statistics));
                break;
            }
        }

    }
    private void printUserList(List<UserProfile> list){
        if(list.Count==0){
            Console.WriteLine("No users found for your request");
            return;
        }
        foreach (var i in list ){
            Console.WriteLine(i);
        }
    }
    private void printDocumentList(List<Document> list){
        if(list.Count==0){
            Console.WriteLine("No documents found for your request");
            return;
        }
        foreach(var i in list ){
            Console.WriteLine(i);
        }
    }
    }
}