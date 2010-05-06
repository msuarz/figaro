using fit;

namespace Figaro {

    public static class BodyFactory {
        
        public static Fixture NewResponseBodyFixture(string ContentType, string Content) { return
            new ResponseBodyFixture {
                Body = NewBody(ContentType, Content)
        };}

        static Body NewBody(string ContentType, string Content) { return 
            ContentType.Contains("json") ?
                (Body) new JsonBody {Content = Content} :
                new XmlBody {Content = Content}
        ;}
    }
}