require 'rubygems'
require 'rest-client'

module Figaro

  class Request

    def initialize(url)
      @url = url
      @options = { :headers => {}}
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

    def client
      RestClient::Resource.new @url, @options
    end

    def get(resource)
      client[resource].get
    end

  end

end