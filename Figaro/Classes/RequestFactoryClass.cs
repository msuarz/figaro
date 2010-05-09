using System;
using System.Net;

namespace Figaro.Classes {

    public class RequestFactoryClass : RequestFactory {

        public HttpRequest NewHttpRequest { get; set; }

        public Request NewRequest(HttpFixture Fixture) {

            var Uri = RequestUriString(Fixture.Host, Fixture.Uri);
        
            NewHttpRequest = new HttpRequest { Core = WebRequest.Create(Uri) };

            AddAuthorization(Fixture.Authorization, Fixture.UserName, Fixture.Password);

            NewHttpRequest.Core.Method = Fixture.Method;

            return NewHttpRequest;
        }

        public virtual string RequestUriString(string Host, string Uri) { return 
            Host.IsEmpty() ? Uri : "http://" + Host + "/" + Uri
        ;}

        public virtual void AddAuthorization(string Authorization, string UserName, string Password) { 
            if (string.IsNullOrEmpty(Authorization)) return;

            var Token = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(UserName + ":" + Password));
            
            NewHttpRequest.Core.Headers.Add("Authorization", Authorization + " " + Token);
        }

    }
}