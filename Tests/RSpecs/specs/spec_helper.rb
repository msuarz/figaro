require "spec"
require "mocha"
require File.join(File.dirname(__FILE__), "../../Specs/bin/debug","Figaro.dll")
require File.join(File.dirname(__FILE__), "../../Specs/bin/debug","Specs.dll")

Spec::Runner.configure do |config|
 config.mock_with :mocha
end

def test_object_for(class_or_interface)
  case class_or_interface
    when Class
      # Return a child of the class so that its virtuals can be altered
      child_name = class_or_interface.to_s.gsub(/[.:]/,'_')
      if self.class.constants.include? child_name
        return self.class.const_get(child_name).new
      end
      return self.class.const_set(child_name, Class.new(class_or_interface)).new
    when Module
      # Create a class that includes the module (or C# interface)
      return Class.new {include class_or_interface}.new
    end
  class_or_interface # return instance
end