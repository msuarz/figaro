require 'rubygems'
require 'rest-client'

module Figaro

  class Request

    attr_reader :sut

    def initialize(url)
      @url = url
      @options = { :headers => {}}
    end

    def client
      RestClient::Resource.new @url, @options
    end

    def get(resource)
      @sut = client[resource].get
    end

    def post(resource, content)
      @sut = client[resource].post content
    end

    def put(resource, content)
      @sut = client[resource].put(content)
    end

    def user(value)
      @options[:user] = value
    end

    def password(value)
      @options[:password] = value
    end

    def headers
      @options[:headers]
    end

    def authorization(value)
      headers[:authorization] = value
    end

    def content_type(value)
      headers[:content_type] = value
    end

    def accept(value)
      headers[:accept] = value
    end

  end

end