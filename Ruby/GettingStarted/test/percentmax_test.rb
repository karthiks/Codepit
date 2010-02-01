# To change this template, choose Tools | Templates
# and open the template in the editor.

$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'percentmax'

class PercentMaxTest < Test::Unit::TestCase
  def test_zero_string_returns_zero_pc
    assert_equal("0%", PercentMax.new(0).to_s)
  end
end