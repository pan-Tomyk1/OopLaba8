using System;

namespace OopLaba8.Documents
{
    public class Magazine : Document
    {
         private string ISSN;
    private int issueNumber;
    private int amountOfPages;
    private string releaseData;

    public Magazine(string name, string author, string publisher, string language, string description, string tags, bool inLibrary, string ISSN, int issueNumber, int amountOfPages, string releaseData) 
        : base(name, author, publisher, language, description, tags, inLibrary){ 
        this.ISSN = ISSN;
        this.issueNumber = issueNumber;
        this.amountOfPages = amountOfPages;
        this.releaseData = releaseData;
    }

    public Magazine() {
    }

    public string getISSN() {
        return ISSN;
    }

    public void setISSN(string ISSN) {
        this.ISSN = ISSN;
    }

    public int getIssueNumber() {
        return issueNumber;
    }

    public void setIssueNumber(int issueNumber) {
        this.issueNumber = issueNumber;
    }

    public int getAmountOfPages() {
        return amountOfPages;
    }

    public void setAmountOfPages(int amountOfPages) {
        this.amountOfPages = amountOfPages;
    }

    public string getReleaseData() {
        return releaseData;
    }

    public void setReleaseData(string releaseData) {
        this.releaseData = releaseData;
    }
    
   
    public override string beautifulOutput(){
        return "Document type : Magazine" +"\n"+
                "Name of the magazine: " +this.getName()+"\n"+
                "Author of the magazine: " +this.getAuthor()+"\n"+
                "Publisher of the magazine: " +this.getPublisher()+"\n"+
                "Language of the magazine: " +this.getLanguage()+"\n"+
                "Description of the magazine: " +this.getDescription()+"\n"+
                "Tags of the magazine: " +this.getTags()+"\n"+
                "Status inLibrary of the magazine: " +this.isInLibrary()+"\n"+
                "ISSN of the magazine: " +this.getISSN()+"\n"+
                "Issue number of the magazine: " +this.getIssueNumber()+"\n"+
                "Amount of pages of the magazine: " +this.getAmountOfPages()+"\n"+
                "Date of release of the magazine: " +this.getReleaseData()+"\n";
    }
    public override int printAllAtributes() {
        Console.WriteLine("1 name");
        Console.WriteLine("2 author");
        Console.WriteLine("3 publisher");
        Console.WriteLine("4 language");
        Console.WriteLine("5 description");
        Console.WriteLine("6 tags");
        Console.WriteLine("7 inLibrary");
        Console.WriteLine("8 ISSN");
        Console.WriteLine("9 issue number");
        Console.WriteLine("10 amount of pages");
        Console.WriteLine("11 release data");
        return 11;
    }
    
    public override String ToString() {
        return "Magazine{" +
                "name='" + getName() + '\'' +
                ", author='" + getAuthor() + '\'' +
                ", publisher='" + getPublisher() + '\'' +
                ", language='" + getLanguage() + '\'' +
                ", description='" + getDescription() + '\'' +
                ", tags='" + getTags() + '\'' +
                ", inLibrary=" + isInLibrary() +'\'' +
                "ISSN='" + ISSN + '\'' +
                ", issueNumber=" + issueNumber +'\'' +
                ", amountOfPages=" + amountOfPages +'\'' +
                ", releaseData='" + releaseData + '\'' +
                '}';
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    }
}