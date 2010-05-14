require File.join(File.dirname(__FILE__), "../../../Specs/bin/debug","Figaro.dll")

class Actors

  def self.http_fixture
    http_fixture = Figaro::HttpFixture.new
    http_fixture.Method = "GET"
    http_fixture.Host = "host"
    http_fixture.Uri = "uri"
    http_fixture.Authorization = "BASIC"
    http_fixture.UserName = "lola"
    http_fixture.Password = "run"
    return http_fixture
  end
end