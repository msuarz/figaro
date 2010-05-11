namespace Figaro {

    public interface Body {

        string Content { get; set; }
        string ValueOf(string Part, string Prefix);
    }
}