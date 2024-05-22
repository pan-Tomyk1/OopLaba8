namespace OopLaba8.Documents
{
    public abstract class Document
    {
        private string name;
    private string author;
    
    private string publisher;
    private string language;
    private string description;
    private string tags;
    private bool inLibrary=true;

    public string getName() {
        return name;
    }

    public void setName(string name) {
        this.name = name;
    }

    public string getAuthor() {
        return author;
    }

    public void setAuthor(string author) {
        this.author = author;
    }
    
    public string getPublisher() {
        return publisher;
    }

    public void setPublisher(string publisher) {
        this.publisher = publisher;
    }
    
    public override string ToString() {
        return "Document{" +
                "name='" + name + '\'' +
                ", author='" + author + '\'' +
                ", publisher='" + publisher + '\'' +
                ", language='" + language + '\'' +
                ", description='" + description + '\'' +
                ", tags='" + tags + '\'' +
                ", inLibrary=" + inLibrary +
                '}';
    }

    public Document() {
    }

    public string getLanguage() {
        return language;
    }

    public void setLanguage(string language) {
        this.language = language;
    }

    public string getDescription() {
        return description;
    }

    public void setDescription(string description) {
        this.description = description;
    }

    public string getTags() {
        return tags;
    }

    public void setTags(string tags) {
        this.tags = tags;
    }

    public bool isInLibrary() {
        return inLibrary;
    }

    public void setInLibrary(bool inLibrary) {
        this.inLibrary = inLibrary;
    }

    public Document(string name, string author, string publisher, string language, string description, string tags, bool inLibrary) {
        this.name = name;
        this.author = author;
        this.publisher = publisher;
        this.language = language;
        this.description = description;
        this.tags = tags;
        this.inLibrary = inLibrary;
    }
    public  abstract string beautifulOutput();
    public  abstract int printAllAtributes();

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    }
}