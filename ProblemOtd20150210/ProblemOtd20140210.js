'use strict';
/* Lucky Numbers - http://problemotd.com/problem/lucky-numbers/ */
/* A lucky number is one that contains only 3s or only 7s (such as 77 or 333).
A number can also be considered lucky if the length of the number is 3 or 7 (such as 249).
Given this knowledge can you compute how many lucky numbers exist in the range [0-1000000]? */

this.window.onload = function () {
  var luckyNumbers = 0;
  for (var index = 0; index <= 1000000; index++) {
    if(new IsNumberLucky(index.toString())) {
      this.document.writeln(index);
      luckyNumbers = luckyNumbers + 1;
    }
  }

  this.document.writeln("Lucky Numbers: " + luckyNumbers);
};

function IsNumberLucky(chkStr)
{
  if (chkStr.length == 3 || chkStr.length == 7) {
    return true;
  }

  var validChar = "";
  if (chkStr.charAt(0) == "3" || chkStr.charAt(0) == "7") {
    validChar = chkStr.charAt(0);
  }
  else {
    return false;
  }

  for (var chkStrPosition = 1; chkStrPosition < chkStr.length; chkStrPosition++) {
    if (chkStr.charAt(chkStrPosition) != validChar) {
      return false;
    }
  }

  return true;
}
