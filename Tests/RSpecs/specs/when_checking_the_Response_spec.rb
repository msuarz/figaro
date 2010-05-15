require "helpers/actors.rb"

describe "when checking the Response" do

  describe "in Xml" do

    before(:each) do
      @sut = Figaro::XmlBody.new
    end

    it "should be able to find Values using XPath" do
      @sut.Content =  "<field>42</field>"
      @sut.ValueOf("/field").should == "42"
    end
  end
end