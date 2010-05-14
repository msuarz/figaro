require "spec_helper.rb"
include System::Collections::Specialized

describe "when making an Http Request" do

  before(:each) do
    @sut = Figaro::HttpFixture.new
    @sut.RequestFactory = test_object_for(Figaro::RequestFactory)
  end

  it "should be able to GET" do
    @sut.Get "localhost"
    @sut.Method.should == "GET"
    @sut.Uri.should == "localhost"
  end

  it "should not reuse fields between Requests" do
    @sut.Host = "previous host"
    @sut.Get "localhost"
    @sut.Host.should be_nil
  end

  it "should send the Request and get Response" do
    request = test_object_for Figaro::Request
    expected_response = test_object_for Figaro::Response

    stub(request).Response {expected_response}
    stub(@sut.RequestFactory).NewRequest(@sut) {request}

    @sut.Send

    @sut.Response.should == expected_response
  end

  describe "a Request Factory" do

    before(:each) do
      @sut = Figaro::Classes::RequestFactoryClass.new
    end

    it "should build a new Request" do
      sut = Figaro::Classes::RequestFactoryClass.new
      fixture = Actors.http_fixture

      sut.NewRequest(fixture)

      sut.NewHttpRequest.should_not be_nil
      sut.NewHttpRequest.Method.should == fixture.Method;
    end

    it "should use Uri if no Host provided" do
      @sut.RequestUriString(nil, "expected uri").
        should == "expected uri"
    end

    it "should compose Uri with Host if provided" do
      @sut.RequestUriString("host", "expected uri").
        should == "http://host/expected uri"
    end
  end

  describe "the Authorization" do

    before(:each) do
      @sut = Figaro::Classes::RequestFactoryClass.new
      @sut.NewHttpRequest = test_object_for Figaro::Request

      @headers = System::Collections::Specialized::NameValueCollection.new
      stub(@sut.NewHttpRequest).Headers {@headers}
    end

    it "should be disabled by default" do
      @sut.AddAuthorization(nil, "User", "Password");
      @headers["Authorization"].should be_nil;
    end

    it "should be Basic if desired" do
      @sut.AddAuthorization("Basic", "User", "Password");
      @headers["Authorization"].should =~ /^Basic/;
    end
  end
end