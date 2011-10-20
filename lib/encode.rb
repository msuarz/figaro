require 'base64'

module Figaro

  class Encode

    def to64(token)
      Base64.encode64 token
    end

  end

end