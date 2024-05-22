using System.Collections.Generic;
using OopLaba8.Documents;
using OopLaba8.Users;

namespace OopLaba8.DataMaintenance
{
    public class Statistics
    {
        private int amountUsers = 0;
        private int amountDocumnets = 0;
        private static List<UserProfile> listOfUsers;
        private static List<Document> listOfDocuments;

        public List<UserProfile> getListOfUsers() {
            return listOfUsers;
        }

      public static List<Document> getListOfDocuments() {
            return listOfDocuments;
        }
        
        private HashSet<int> hashSetOfUsers;
        private HashSet<int> hashSetOfDocuments;

        public Statistics() {
            listOfUsers = new List<UserProfile>();
            hashSetOfUsers = new HashSet<int>();
            listOfDocuments = new List<Document>();
            hashSetOfDocuments = new HashSet<int>();
        }

        public int getAmountUsers() {
            return amountUsers;
        }

        public void setAmountUsers(int amountUsers) {
            this.amountUsers = amountUsers;
        }

        public int getAmountDocuments() {
            return amountDocumnets;
        }

        public void setAmountDocumnets(int amountDocumnets) {
            this.amountDocumnets = amountDocumnets;
        }

        public void addUser(UserProfile userProfile) {
            if (checkUser(userProfile.GetHashCode())) throw new MyException("Such a user already insinuates in the system");
            hashSetOfUsers.Add(userProfile.GetHashCode());
            listOfUsers.Add(userProfile);
            amountUsers = listOfUsers.Count;
        }

        public void addDocument(Document document) {
            if (checkDocument(document.GetHashCode())) throw new MyException("Such a user already insinuates in the system");
            hashSetOfDocuments.Add(document.GetHashCode());
            listOfDocuments.Add(document);
            amountDocumnets = listOfDocuments.Count;
        }

        public bool checkUser(int hash) {
            return hashSetOfUsers.Contains(hash);
        }

        public bool checkDocument(int hash) {
            return hashSetOfDocuments.Contains(hash);
        }

        public UserProfile getUser(int index) {
            return listOfUsers[index];
        }

        public Document getDocument(int index) {
            return listOfDocuments[index];
        }

        public void deleteUser(int index) {
            UserProfile user = getUser(index);
            hashSetOfUsers.Remove(user.GetHashCode());
            listOfUsers.Remove(user);
            amountUsers--;
        }

        public void deleteDocument(int index) {
            Document document = getDocument(index);
            hashSetOfDocuments.Remove(document.GetHashCode());
            listOfDocuments.Remove(document);
            amountDocumnets--;
        }
        public static List<Document> getListOfAvailableDocuments(){
            List<Document> list=new List<Document>();
            foreach(var i in listOfDocuments){
                if(i.isInLibrary()){
                    list.Add(i);
                }
            } return list;
        }
    }
}