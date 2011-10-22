require 'rubygems'
require 'json/ext'
require 'hashie/mash'

module Figaro

  class Json

    attr_reader :sut

    def initialize(content)
      @sut = Hashie::Mash.new JSON.parse(content)
    end

    def get(object_path)
      eval '@sut.' + object_path
    end

    def set_to(object_path, value)
      eval '@sut.' + object_path + ' = ' + value
    end

    def json
      @sut.to_json
    end

  end

end