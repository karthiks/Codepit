# To change this template, choose Tools | Templates
# and open the template in the editor.

$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'percentmax'

class PercentMaxTest < Test::Unit::TestCase

  def test_zero_string_returns_0_pc
    assert_equal("0%", PercentMax.new(0).to_s)
  end

  def test_fifty_string_returns_50_pc
    assert_equal("50%", PercentMax.new(50).to_s)
  end

  def test_onehundredfifty_string_returns_100_pc
    assert_equal("100%", PercentMax.new(100).to_s)
  end

  def test_onehundredfifty_string_returns_100_pc
    assert_equal("100%", PercentMax.new(150).to_s)
  end

  def test_negativeten_string_returns_0_pc
    assert_equal("0%", PercentMax.new(-10).to_s)
  end

end