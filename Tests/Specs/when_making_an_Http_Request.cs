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

        [TestMethod]
        public void should_not_reuse_fields_between_Requests() {

            Given.Host = "previous host";
            When.Get("localhost");
            Then.Host.ShouldBeEmpty();
        }

        [TestMethod]
        public void should_get_the_Response() {
            
            When.Send();
            Should.PrepareRequest();
            And.GetResponse();
        }

        [TestMethod]
        public void should_use_URI_if_no_host_provided() {}

    }
}