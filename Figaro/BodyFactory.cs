using System;
using fit;
using StructureMap;

namespace Figaro {

    public static class BodyFactory {
        
        static readonly Container Container = new Container(X => 
            X.For<Body>().MissingNamedInstanceIs.Conditional(C => {
                C.If(P => P.RequestedName.Contains("json")).ThenIt.Is.Type<JsonBody>();
                C.TheDefault.Is.Type<XmlBody>();
        }));

        public static Fixture NewResponseBodyFixture
            (string ContentType, string Content, string PartPrefix = "") {
            
            var BodyFixture = new ResponseBodyFixture{ 
                Body = Container.GetInstance<Body>(ContentType),
                PartPrefix = PartPrefix 
            };
            
            BodyFixture.Body.Content = Content;
            return BodyFixture;
        }

    }
}