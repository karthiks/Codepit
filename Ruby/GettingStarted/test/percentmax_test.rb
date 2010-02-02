# To change this template, choose Tools | Templates
# and open the template in the editor.

$:.unshift File.join(File.dirname(__FILE__),'..','lib')

require 'test/unit'
require 'percentmax'

class PercentMaxTest < Test::Unit::TestCase

  def percent_s(value)
    PercentMax.new(value).to_s
  end

  def test_zero_string_returns_0_pc
    assert_equal "0%", percent_s(0)
  end

  def test_fifty_string_returns_50_pc
    assert_equal "50%", percent_s(50)
  end

  def test_onehundredfifty_string_returns_100_pc
    assert_equal "100%", percent_s(100)
  end

  def test_onehundredfifty_string_returns_100_pc
    assert_equal "100%", percent_s(150)
  end

  def test_negativeten_string_returns_0_pc
    assert_equal "0%", percent_s(-10)
  end

  def test_ten_point_eleven_string_returns_10pt11_pc
    assert_equal "10.11%", percent_s(10.11)
  end

  def test_ten_point_oneonefive_string_returns_10pt11_pc
    assert_equal "10.11%", percent_s(10.115)
  end

  def test_sixty_point_eightseventwothree_string_returns_60pt87_pc
    assert_equal "60.87%", percent_s(60.8723)
  end

  def test_zero_point_zerozerozeroone_string_returns_0pt01_pc
    assert_equal "0%", percent_s(0.0001)
  end

  def test_onehundred_point_sevenfivefive_string_returns_100_pc
    assert_equal "100%", percent_s(100.755)
  end

end