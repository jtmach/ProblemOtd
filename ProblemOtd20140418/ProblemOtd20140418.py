#The Lone Survivor / http://problemotd.com/problem/the-lone-survivor/
#There are 1,500 loyal servants sitting around the king's table when they decide to play a little game. The 1st servant gets a sword and kills the 2nd servant. He then gives the sword to the 3rd servant, who then kills the 4th servant and then gives the sword to the 5th. This continues so that the 1,499th servant kills the 1,500th servant and gives the sword back to the 1st servant.
#Now the 1st servant kills the 3rd and gives the sword to the 5th. This process continues until only one servant remains. Which number servant is the lone survivor?

class Servant(object):
  def __init__(self, pos):
    self.pos = pos

  def __str__(self):
    return str(self.pos)

  def GetPosition(self):
    return self.pos

servants = list()
index = 1
while index <= 1500:
  servants.append(Servant(index))
  index = index + 1


index = 0
while len(servants) > 1:
  servantToBeKilled = index + 1
  if servantToBeKilled >= len(servants):
    servantToBeKilled = 0
      
  print("Servant " + str(servants[index]) + " kills servant " + str(servants[servantToBeKilled]))
  servants.pop(servantToBeKilled)
  index = index + 1
  if index >= len(servants):
    index = 0

print()
print(str(servants[0]) + " is the Highlander")
