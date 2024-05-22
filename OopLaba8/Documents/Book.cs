using System;

namespace OopLaba8.Documents
{
    public class Book : Document
    {
        private string ISBN;
    private string genre;
    private int amountOfPages;

    public Book(string name, string author, string publisher, string language, string description, string tags, bool inLibrary, string ISBN, string genre, int amountOfPages) 
        : base(name, author, publisher, language, description, tags, inLibrary){
        this.ISBN = ISBN;
        this.genre = genre;
        this.amountOfPages = amountOfPages;
    }

    public Book() {
    }

    public string getISBN() {
        return ISBN;
    }

    public void setISBN(string ISBN) {
        this.ISBN = ISBN;
    }

    public string getGenre() {
        return genre;
    }

    public void setGenre(string genre) {
        this.genre = genre;
    }

    public int getAmountOfPages() {
        return amountOfPages;
    }

    public void setAmountOfPages(int amountOfPages) {
        this.amountOfPages = amountOfPages;
    }
    public override string beautifulOutput(){
        return "Document type : Book" +"\n"+
                "Name of the book: " +this.getName()+"\n"+
                "Author of the book: " +this.getAuthor()+"\n"+
                "Publisher of the book: " +this.getPublisher()+"\n"+
                "Language of the book: " +this.getLanguage()+"\n"+
                "Description of the book: " +this.getDescription()+"\n"+
                "Tags of the book: " +this.getTags()+"\n"+
                "Status inLibrary of the book: " +this.isInLibrary()+"\n"+
                "ISbN of the book: " +this.getISBN()+"\n"+
                "Genre of the book: " +this.getGenre()+"\n"+
                "Amount of pages of the book: " +this.getAmountOfPages()+"\n";

    }
    public override int printAllAtributes() {
        Console.WriteLine("1 name");
        Console.WriteLine("2 author");
        Console.WriteLine("3 publisher");
        Console.WriteLine("4 language");
        Console.WriteLine("5 description");
        Console.WriteLine("6 tags");
        Console.WriteLine("7 inLibrary");
        Console.WriteLine("8 ISBN");
        Console.WriteLine("9 genre");
        Console.WriteLine("10 amount of pages");
        return 10;
    }

    
    public override string ToString() {
        return "Book{" +
                "name='" + getName() + '\'' +
                ", author='" + getAuthor() + '\'' +
                ", publisher='" + getPublisher() + '\'' +
                ", language='" + getLanguage() + '\'' +
                ", description='" + getDescription() + '\'' +
                ", tags='" + getTags() + '\'' +
                ", inLibrary=" + isInLibrary() +'\'' +
                "ISBN='" + ISBN + '\'' +
                ", genre='" + genre + '\'' +
                ", amountOfPages=" + amountOfPages +
                '}';
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    }
}