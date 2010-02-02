# To change this template, choose Tools | Templates
# and open the template in the editor.

class PercentString
  def initialize(value)
    @value = value
  end

  def to_s
    two_dp = sprintf("%.2f", @value).to_f
    ranged = (two_dp > 100) ? 100 : (two_dp < 0) ? 0 : two_dp
    formatted = (ranged.floor == two_dp) ? ranged.to_i : ranged
    "#{formatted.to_s}%"
  end
end
