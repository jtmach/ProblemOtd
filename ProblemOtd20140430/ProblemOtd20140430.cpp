//Party Hat / http://www.problemotd.com/problem/party-hat/
//Over at Problem of the Day we like to party it up.Since April is coming to a close let's create a program to prepare for all the May birthdays coming up. Today's problem is given a number, generate a party hat that many lines tall.Here is an example with 8:
//       *
//      ***
//     *****
//    *******
//   *********
//  ***********
// *************
//***************
#include "stdafx.h"
#include <iostream>
#include <sstream>

using namespace std;
int _tmain(int argc, _TCHAR* argv[])
{
  string input = "";

  while (true)
  {
    int partyHatLines = 0;
    
    while (true) 
    {
      cout << "Enter the number of lines you would like in your party hat, or type exit to exit." << std::endl;
      getline(cin, input);

      if (input == "exit")
      {
        return 0;
      }

      stringstream myStream(input);
      if (myStream >> partyHatLines)
      {
        break;
      }
      cout << "Invalid number, please try again" << endl;
    }

    int partyHatSpaces = partyHatLines + (partyHatLines - 1);
    for (int index = 1; index <= partyHatLines; index++)
    {
      int starCount = index + (index - 1);
      int padCount = (partyHatSpaces - starCount) / 2;
      cout << std::string(padCount, ' ');
      cout << std::string(starCount, '*');
      cout << std::string(padCount, ' ');
      cout << std::endl;
    }
  }

  return 0;
}
