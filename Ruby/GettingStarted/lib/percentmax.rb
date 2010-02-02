# To change this template, choose Tools | Templates
# and open the template in the editor.

class PercentMax
  def initialize(max)
    @max = max
  end

  def to_s
    pc = (@max > 100) ? 100 : (@max < 0) ? 0 : @max
    "#{pc}%"
  end
end
