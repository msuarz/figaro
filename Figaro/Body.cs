namespace Figaro {

    public interface Body {
        
        string Content { get; }
        string ValueOf(string Part);
    }
}