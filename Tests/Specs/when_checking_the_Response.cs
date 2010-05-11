using Figaro;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Specs {

    [TestClass]
    public class when_checking_the_Response {
        
        [TestClass]
        public class in_Xml : BehaviorOf<XmlBody> {
            
            [TestMethod]
            public void should_be_able_to_find_Values_using_XPath() {

                Given.Content = "<field>42</field>";
                The.ValueOf("/field").ShouldBe("42");
            }

            [TestMethod]
            public void should_be_able_to_find_Values_using_Object_Path(){

                Given.Content = "<dog><name>Fido</name></dog>";
                The.ValueOf("dog.name").ShouldBe("Fido");
            }

            [TestMethod]
            public void should_be_able_to_find_Values_with_a_Part_Prefix() {
                
                Given.Content = @"<person><address>
                                    <city>Miami</city>
                                 </address></person>";
                The.ValueOf("city","person.address").ShouldBe("Miami");
            }

        }

        [TestClass]
        public class in_Json : BehaviorOf<JsonBody> {

            [TestMethod]
            public void should_be_able_to_find_Values_using_JSON() {
                
                Given.Content = "{\"field\":42}";
                The.ValueOf("field").ShouldBe("42");
            }
        }

        [TestMethod]
        public void should_load_XmlBody_for_XPath() {

            (BodyFactory.NewResponseBodyFixture("application/xml","") as ResponseBodyFixture)
                .Body.ShouldBeA<XmlBody>();
        }

        [TestMethod]
        public void should_load_JsonBody_for_JsonProperties() {

            (BodyFactory.NewResponseBodyFixture("application/json","") as ResponseBodyFixture)
                .Body.ShouldBeA<JsonBody>();
        }
    }
}