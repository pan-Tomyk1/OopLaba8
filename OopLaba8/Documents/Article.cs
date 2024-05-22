using System;

namespace OopLaba8.Documents
{
    public class Article : Magazine
    {
        private string DOI;

    public Article(string name, string author, string publisher, string language, string description, string tags, bool inLibrary, string ISSN, int issueNumber, int amountOfPages, string releaseData, string DOI) 
        :base(name, author, publisher, language, description, tags, inLibrary, ISSN, issueNumber, amountOfPages, releaseData){ 
        this.DOI = DOI;
    }

    public Article() {
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public string getDOI() {
        return DOI;
    }

    public void setDOI(string DOI) {
        this.DOI = DOI;
    }
    
    public override string beautifulOutput(){
        return "Document type : Article" +"\n"+
                "Name of the article: " +this.getName()+"\n"+
                "Author of the article: " +this.getAuthor()+"\n"+
                "Publisher of the article: " +this.getPublisher()+"\n"+
                "Language of the article: " +this.getLanguage()+"\n"+
                "Description of the article: " +this.getDescription()+"\n"+
                "Tags of the article: " +this.getTags()+"\n"+
                "Status inLibrary of the article: " +this.isInLibrary()+"\n"+
                "ISSN of the article: " +this.getISSN()+"\n"+
                "Issue number of the article: " +this.getIssueNumber()+"\n"+
                "Amount of pages of the article: " +this.getAmountOfPages()+"\n"+
                "Date of release of the article: " +this.getReleaseData()+"\n"+
                "DOI of the article: " +this.getDOI()+"\n";
    }
    public int printAllAtributes() {
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
        Console.WriteLine("12 DOI");
        return 12;
    }
    
    public override string ToString() {
        return "Article{" +
                "name='" + getName() + '\'' +
                ", author='" + getAuthor() + '\'' +
                ", publisher='" + getPublisher() + '\'' +
                ", language='" + getLanguage() + '\'' +
                ", description='" + getDescription() + '\'' +
                ", tags='" + getTags() + '\'' +
                ", inLibrary=" + isInLibrary() +
                "ISSN='" + getISSN() + '\'' +
                ", issueNumber=" + getIssueNumber() +
                ", amountOfPages=" + getAmountOfPages() +
                ", releaseData='" + getReleaseData() + '\'' +
                "DOI='" + DOI + '\'' +
                '}';
    }
    }
}