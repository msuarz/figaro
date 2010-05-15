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

    it "should be able to find Values using Object Path" do
      @sut.Content =  "<dog><name>Fido</name></dog>"
      @sut.ValueOf("dog.name").should == "Fido"
    end

    it "should be able to find Values with a Part Prefix" do
      @sut.Content = "<person><address><city>Miami</city></address></person>"
      @sut.ValueOf("city","person.address").should == "Miami"
    end
  end
end