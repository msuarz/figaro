using Figaro;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_making_an_Http_Request : BehaviorOf<HttpFixture> {
        
        [TestMethod]
        public void should_be_able_to_GET() {
            
            When.Get("localhost");

            Then.Method.ShouldBe("GET");
            And.Uri.ShouldBe("localhost");
        }
    }
}