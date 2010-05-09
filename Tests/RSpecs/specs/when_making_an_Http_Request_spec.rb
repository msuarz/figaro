require "spec"
require File.join(File.dirname(__FILE__), "../../Features/dotnet","Figaro.dll")

describe "when making an Http Request" do

  before(:each) do
    @sut = Figaro::HttpFixture.new
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

end