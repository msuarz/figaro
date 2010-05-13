require "spec_helper.rb"

describe "when making an Http Request" do

  before(:each) do
    @sut = Figaro::HttpFixture.new
    @sut.RequestFactory = test_object_for(Figaro::RequestFactory)
    @actors = Specs::Helpers::Actors.new
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
    request.stubs(:Response).returns(expected_response)

    @sut.RequestFactory.stubs(:NewRequest).with(@sut).returns(request)
    @sut.Send

    @sut.Response.should == expected_response
  end

  describe "a Request Factory" do

    before(:each) do
      @sut = Figaro::Classes::RequestFactoryClass.new
    end

    it "should build a new Request" do
#      sut = Figaro::Classes::RequestFactoryClass.new
#      fixture = Specs::Helpers::Actors::HttpFixture
#
#      fixture.Uri.should == 'uri'
#      sut.stubs(:RequestUriString).with()
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
end