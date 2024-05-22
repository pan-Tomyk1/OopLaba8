using System;
using System.Collections.Generic;
using System.Text;
using OopLaba8.Documents;
using OopLaba8.Users;

namespace OopLaba8.DataMaintenance
{
    public class DocumentsMaintaining
    { 
        private const int MAX_STRING_INPUT_LENGTH=40;
        private const int MAX_DESCRIPTION_LENGTH=500;
        private const int MAX_TAG_LENGTH=100;
        static DocumentsMaintaining documentsMaintaining = new DocumentsMaintaining();
        public static Document addDocument(){
            int type=DocumentsMaintaining.chooseTypeOfDocument();
            string name=documentsMaintaining.enterName();
            string author=documentsMaintaining.enterAuthor();
            string dateOfRelease=documentsMaintaining.enterDateOfRelease();
            string publisher=documentsMaintaining.enterPublisher();
            string language=documentsMaintaining.enterLanguage();
            string description=documentsMaintaining.enterDescription();
            string tags=documentsMaintaining.enterTags();
            switch (type){
                case 1:{
                    string DOI=documentsMaintaining.enterDOI();
                    string ISSN=documentsMaintaining.enterISSN();
                    string releaseDate=documentsMaintaining.enterDateOfRelease();
                    int amountOfPages=documentsMaintaining.enterAmountOfPages();
                    int issueNumber=documentsMaintaining.enterIssueNumber();
                    Article article=new Article(name,author,publisher,language,description,tags,true,ISSN, issueNumber,amountOfPages,releaseDate,DOI);
                    return article;
                    }
                case 2:{
                    string ISBN=documentsMaintaining.enterISBN();
                    string genre=documentsMaintaining.enterGenre();
                    int amountOfPages=documentsMaintaining.enterAmountOfPages();
                    Book book=new Book(name, author, publisher,language,description,tags,true,ISBN,genre,amountOfPages);
                    return book;
                }
                case 3:{
                    string ISSN=documentsMaintaining.enterISSN();
                    string releaseDate=documentsMaintaining.enterDateOfRelease();
                    int amountOfPages=documentsMaintaining.enterAmountOfPages();
                    int issueNumber=documentsMaintaining.enterIssueNumber();
                    Magazine magazine=new Magazine(name, author, publisher,language,description,tags,true,ISSN,issueNumber,amountOfPages,releaseDate);
                    return magazine;
                    }
            }
            return null;
        }

        private String enterStringData(int maxLength) {
            String input;
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
        private String enterName(){
            Console.WriteLine("-Enter the name of the document");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterDOI(){
            Console.WriteLine("-Enter the DOI of the article");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterISBN(){
            Console.WriteLine("-Enter the ISBN of the book");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterGenre(){
            Console.WriteLine("-Enter the genre of the book");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterISSN(){
            Console.WriteLine("-Enter the DOI of the article");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private int enterAmountOfPages(){
            Console.WriteLine("-Enter the amount of pages of the document");
            return InputOutput.enterInt(Int32.MaxValue, 0);
        }
        private int enterIssueNumber(){
            Console.WriteLine("-Enter the issue number of the document");
            return InputOutput.enterInt(Int32.MaxValue,0);
        }
       
        private String enterAuthor(){
            Console.WriteLine("-Enter the author of the document");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterDateOfRelease(){
            Console.WriteLine("-Enter the date of release of the document");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private bool enterStatus(){
            Console.WriteLine("-Please enter the status of the document i.e.\n" +
                              " whether the document is in the library \n" +
                              "or it is given to some reader");
            Console.WriteLine("Please enter true if the document is in the library, otherwise enter false");
            bool checkResult=false;
            bool status=false;
            while(!checkResult){
                try{
                    status=InputOutput.enterBooleanData();
                    checkResult=true;
                }catch (Exception e){
                    Console.WriteLine("Invalid input. Please, enter true or false");
                }
            }
            return status;
        }
        private bool enterBooleanData(){
            return InputOutput.enterBooleanData();
        }
        private String enterPublisher(){
            Console.WriteLine("-Enter the publisher of the document");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterLanguage(){
            Console.WriteLine("-Enter the language of the document");
            return enterStringData(MAX_STRING_INPUT_LENGTH);
        }
        private String enterDescription(){
            Console.WriteLine("-Enter the description of the document");
            return enterStringData(MAX_DESCRIPTION_LENGTH);
        }
        private String enterTags(){
            Console.WriteLine("-Enter the tags of the document");
            return enterStringData(MAX_TAG_LENGTH);
        }
        public static int chooseTypeOfDocument(){
            Console.WriteLine("Please select a document type");
            Console.WriteLine("1 Article");
            Console.WriteLine("2 Book");
            Console.WriteLine("3 Magazine");
            Console.WriteLine("Select document type min 1, max 3");
            return InputOutput.enterInt(3,1);
        }

        public static void editDocument(Statistics statistics){
            if (statistics.getAmountDocuments() == 0) {
                Console.WriteLine("No document found, add document first");
                return;
            }
            DocumentsMaintaining.printAllDocuments(statistics);
            Console.WriteLine("Select the document you want to edit the data, max = "+(statistics.getAmountDocuments())+", min = 1");
            int documentIndex=InputOutput.enterInt((statistics.getAmountDocuments()),1);
            Document document=statistics.getDocument(documentIndex-1);
            Console.WriteLine(document.beautifulOutput());
            Console.WriteLine("What data do you want to edit?");
            int numberOfAtributes=document.printAllAtributes();
            Console.WriteLine("Please select the data you want to edit, max="+numberOfAtributes+", min=1");
            int dataType = InputOutput.enterInt(numberOfAtributes, 1);
            switch (dataType){
                case 1:{
                    document.setName(documentsMaintaining.enterName());
                    break;}
                case 2:{
                    document.setAuthor(documentsMaintaining.enterAuthor());
                    break;}
                case 3:{
                    document.setPublisher(documentsMaintaining.enterPublisher());
                    break;}
                case 4:{
                    document.setLanguage(documentsMaintaining.enterLanguage());
                    break;}
                case 5:{
                    document.setDescription(documentsMaintaining.enterDescription());
                    break;}
                case 6:{
                    document.setTags(documentsMaintaining.enterTags());
                    break;}
                case 7:{
                    document.setInLibrary(documentsMaintaining.enterStatus());
                    break;}
                case 8: {
                    if(document.GetType()== typeof(Magazine)){
                        ((Magazine) document).setISSN(documentsMaintaining.enterISSN());
                    }
                    if(document.GetType()== typeof(Article)){
                        ((Article) document).setISSN(documentsMaintaining.enterISSN());
                    }
                    if(document.GetType()== typeof(Book)){
                        ((Book) document).setISBN(documentsMaintaining.enterISBN());
                    }
                    break;
                }
                case 9: {
                    if(document.GetType()== typeof(Magazine)){
                        ((Magazine) document).setIssueNumber(documentsMaintaining.enterIssueNumber());
                    }
                    if(document.GetType()== typeof(Article)){
                        ((Article) document).setIssueNumber(documentsMaintaining.enterIssueNumber());
                    }
                    if(document.GetType()== typeof(Book)){
                        ((Book) document).setGenre(documentsMaintaining.enterGenre());
                    }
                    break;
                }
                case 10: {
                    if(document.GetType()== typeof(Magazine)){
                        ((Magazine) document).setAmountOfPages(documentsMaintaining.enterAmountOfPages());
                    }
                    if(document.GetType()== typeof(Article)){
                        ((Article) document).setAmountOfPages(documentsMaintaining.enterAmountOfPages());
                    }
                    if(document.GetType()== typeof(Book)){
                        ((Book) document).setAmountOfPages(documentsMaintaining.enterAmountOfPages());
                    }
                    break;
                }
                case 11: {
                    if(document.GetType()== typeof(Magazine)){
                        ((Magazine) document).setReleaseData(documentsMaintaining.enterDateOfRelease());
                    }
                    else{
                        ((Article) document).setReleaseData(documentsMaintaining.enterDateOfRelease());
                    }
                    break;
                }
                case 12:{
                    ((Article) document).setDOI(documentsMaintaining.enterDOI());
                    break;
                }
            }
        }
        public static void printAllDocuments(Statistics statistics){
            Console.WriteLine("No. | User");
            Console.WriteLine("----|--------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < statistics.getAmountDocuments(); i++) {
                Console.WriteLine( i + 1 +"|"+ Statistics.getListOfDocuments()[i].ToString());
            }
            Console.WriteLine("----|--------------------------------------------------------------------------------------------------------");

        }
        public static void printAvailableDocuments(Statistics statistics){
            Document document;
            Console.WriteLine("No. | User");
            Console.WriteLine("----|--------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < statistics.getAmountDocuments(); i++) {
                document=Statistics.getListOfDocuments()[i];
                if(!document.isInLibrary())break;
                Console.WriteLine( i + 1+"|"+ document.ToString());
            }
            Console.WriteLine("----|--------------------------------------------------------------------------------------------------------");

        }
        public static void deleteDocument(Statistics statistics){
            if (statistics.getAmountDocuments() == 0) {
                Console.WriteLine("No document found, add document first");
                return;
            }
            DocumentsMaintaining.printAllDocuments(statistics);
            Console.WriteLine("Select the document you want to delete, max = "+(statistics.getAmountDocuments())+", min = 1");
            int documentIndex=InputOutput.enterInt((statistics.getAmountDocuments()),1)-1;
            Document document=statistics.getDocument(documentIndex);
            Statistics.getListOfDocuments().Remove(document);
            statistics.setAmountDocumnets(Statistics.getListOfDocuments().Count);
        }
        public static void printIndividualDocument(Statistics statistics){
            if (statistics.getAmountDocuments() == 0) {
                Console.WriteLine("No document found, add document first");
                return;
            }
            DocumentsMaintaining.printAllDocuments(statistics);
            Console.WriteLine("Select the user you want to see, max = "+(statistics.getAmountDocuments())+", min = 1");
            int documentIndex=InputOutput.enterInt((statistics.getAmountDocuments()),1)-1;
            Console.WriteLine(statistics.getDocument(documentIndex).beautifulOutput());
        }
        public static UserProfile locateDocument(Document document, Statistics statistics){
            foreach(var i in statistics.getListOfUsers()){
                if(i.getHashSet().Contains(document)){
                    return i;
                }
            }
            return null;
        }
        public static List<Document> findDocumentByTheName(String name, Statistics statistics){
            List<Document> arrayList = new List<Document>();
            foreach(var i in Statistics.getListOfDocuments()){
                if(i.getName().Contains(name)){
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        public static List<Document> findDocumentByTheAuthor(String author, Statistics statistics){
            List<Document> arrayList = new List<Document>();
            foreach(var i in Statistics.getListOfDocuments()){
                if(i.getAuthor().Contains(author)){
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        public static List<Document> findDocumentByThePublisher(String publisher, Statistics statistics){
            List<Document> arrayList = new List<Document>();
            foreach(var i in Statistics.getListOfDocuments()){
                if(i.getPublisher().Contains(publisher)){
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        public static List<Document> findDocumentByTheLanguage(String language, Statistics statistics){
            List<Document> arrayList = new List<Document>();
            foreach(var i in Statistics.getListOfDocuments()){
                if(i.getLanguage().Contains(language)){
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        public static List<Document> findDocumentByTheTags(String tags, Statistics statistics){
            List<Document> arrayList = new List<Document>();
            foreach(var i in Statistics.getListOfDocuments()){
                if(i.getTags().Contains(tags)){
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        public static List<Document> findDocumentByTheType(Document document, Statistics statistics){
            List<Document> arrayList = new List<Document>();
            foreach(var i in Statistics.getListOfDocuments()){
                if(i.GetType()==document.GetType()){
                    arrayList.Add(i);
                }
            }
            return arrayList;
        }
        private static string makeListInLine(List<Document> list)
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