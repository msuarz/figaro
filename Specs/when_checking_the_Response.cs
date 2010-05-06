using Figaro;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_checking_the_Response : BehaviorOf<ResponseBodyFixture> {
        
        readonly Body Body = TestObjectFor<Body>();

        [TestInitialize]
        public void SetUp() { Given.Body.Is(Body); }

        [TestMethod]
        public void should_be_able_to_find_Values_using_XPath() {

//            Given.XPath = "meaning of life";

            Body.Given().ValueOf("meaning of life").Is("42");

            The.Value.ShouldBe("42");
        }

        [TestMethod]
        public void should_be_able_to_find_Values_using_JSON() {

//            Given.JsonProperty = "meaning of life";
            
            Body.Given().ValueOf("meaning of life").Is("42");

            The.Value.ShouldBe("42");
        }

        [TestMethod]
        public void should_load_XmlBody_for_XPath() {

//            Given.XPath = "using xml";
            The.Body.ShouldBeA<XmlBody>();
        }

        [TestMethod]
        public void should_load_JsonBody_for_JsonProperties() {

//            Given.JsonProperty = "using json";
            The.Body.ShouldBeA<JsonBody>();
        }
    }
}