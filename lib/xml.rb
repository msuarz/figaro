require 'rubygems'
require 'xmlsimple'

module Figaro
  class Xml
    def initialize(content)
      @content = content      
    end
    
    def xpath(path)
      XmlSimple.new.xml_in(@content)[path]  
    end
  end
end