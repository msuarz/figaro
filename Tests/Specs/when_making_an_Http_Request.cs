using System.Collections.Specialized;
using Figaro;
using Figaro.Classes;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specs.Helpers;

namespace Specs {

    [TestClass]
    public class when_making_an_Http_Request : BehaviorOf<HttpFixture> {

        readonly RequestFactory RequestFactory = TestObjectFor<RequestFactory>();

        [TestInitialize]
        public void SetUp() {
            Given.RequestFactory = RequestFactory;
        }

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
        public void should_send_the_Request_and_get_Response() {
            var Request = TestObjectFor<Request>();
            var ExpectedResponse = TestObjectFor<Response>();

            RequestFactory.Given().NewRequest(It).Is(Request);
            Request.Given().Response.Is(ExpectedResponse);
            
            When.Send();

            Then.Response.ShouldBe(ExpectedResponse);
        }

        [TestClass]
        public class a_RequestFactory : BehaviorOf<RequestFactoryClass>{
            
            [TestMethod]
            public void should_build_a_new_Request() {
                var Fixture = Actors.HttpFixture;

                Given.RequestUriString(Fixture.Host, Fixture.Uri)
                    .WillReturn("http://google.com");

                The.NewRequest(Fixture).ShouldNotBeNull();
                And.AddAuthorization(
                    Fixture.Authorization, 
                    Fixture.UserName,
                    Fixture.Password
                );
                And.NewHttpRequest.Method = Fixture.Method;
            }

            [TestMethod]
            public void should_use_Uri_if_no_host_provided() {
                
                When.RequestUriString(null, "expected uri")
                    .ShouldBe("expected uri");
            }

            [TestMethod]
            public void should_compose_Uri_with_Host_if_provided() {
                
                When.RequestUriString("host", "expected uri")
                    .ShouldBe("http://host/expected uri");
            }

        }

        [TestClass]
        public class the_authorization : BehaviorOf<RequestFactoryClass>{
            
            readonly NameValueCollection Headers = new NameValueCollection();

            [TestInitialize]
            public void SetUp() { Given.NewHttpRequest.Headers.Are(Headers); }

            [TestMethod]
            public void should_be_disabled_by_default(){

                When.AddAuthorization(null, "User", "Password");
                Headers["Authorization"].ShouldBeNull();
            }

            [TestMethod]
            public void should_be_Basic_if_desired(){

                Given.Encrypt("User", "Password").Is("encrypted credentials");
                When.AddAuthorization("Basic", "User", "Password");
                Headers["Authorization"].ShouldBe("Basic " + "encrypted credentials");
            }
        }
    }
}