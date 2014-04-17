#Et tu, Brute? / http://problemotd.com/problem/et-tu-brute/
#WRGDBVSUREOHPRIWKHGDBLVWRFUHDWHDFDHVDUFLSKHUHQFUBSWHUDQGGHFUBSWHU

import enchant
import random

def DecryptString(encyptedStr):
  possibleSolutions = []

  offset = 0
  while offset <= 25:
    decryptedStr = ""
    for char in encyptedStr:
      charIndex = charList.index(char)
      charIndex = charIndex - offset
      if charIndex < 0:
        charIndex = charIndex + 26
      decryptedStr = decryptedStr + charList[charIndex]

    if ContainsAWord(decryptedStr):
      possibleSolutions.append(decryptedStr)
    offset = offset + 1
  return possibleSolutions

def EncryptString(str, offset):
  encryptedStr = ""
  for char in str:
    charIndex = charList.index(char)
    charIndex = charIndex + offset
    if charIndex > 25:
      charIndex = charIndex - 26

    encryptedStr = encryptedStr + charList[charIndex]   

  return encryptedStr

#This should be refactored to make sure that you can make words from the letters all the way
#accross. I just ran out of allocated time for this problem.
def ContainsAWord(str):
  dict = enchant.Dict("en_US")
  index = 1
  while index <= len(str):
    if dict.check(str[:index]):
      return True
    index = index + 1
  return False

charList = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"]
encryptedString = "WRGDBVSUREOHPRIWKHGDBLVWRFUHDWHDFDHVDUFLSKHUHQFUBSWHUDQGGHFUBSWHU"

print("Possible Decrypted Strings")
for decryptedString in DecryptString(encryptedString):
  print(decryptedString)

print()
print("Randomly Encrypted String")
randomlyEncryptedString = EncryptString(decryptedString, random.randint(1,26))
print(randomlyEncryptedString)

print()
print("Possible Decrypted Strings")
for decryptedString in DecryptString(randomlyEncryptedString):
  print(decryptedString)
