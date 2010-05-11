using System;
using System.Net;

namespace Figaro.Classes {

    public class RequestFactoryClass : RequestFactory {

        public Request NewHttpRequest { get; set; }

        public Request NewRequest(HttpFixture Fixture) {

            var Uri = RequestUriString(Fixture.Host, Fixture.Uri);
        
            NewHttpRequest = new HttpRequest {
                Core = WebRequest.Create(Uri),
                Method = Fixture.Method,
            };

            AddAuthorization(Fixture.Authorization, Fixture.UserName, Fixture.Password);

            return NewHttpRequest;
        }

        public virtual string RequestUriString(string Host, string Uri) { return 
            Host.IsEmpty() ? Uri : "http://" + Host + "/" + Uri
        ;}

        public virtual void AddAuthorization(string Authorization, string UserName, string Password) { 
            if (string.IsNullOrEmpty(Authorization)) return;

            NewHttpRequest.Headers["Authorization"] =
                Authorization + " " + Encrypt(UserName, Password);
        }

        public virtual string Encrypt(string UserName, string Password) { return
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(
                    UserName + ":" + Password
        ));}
    }
}