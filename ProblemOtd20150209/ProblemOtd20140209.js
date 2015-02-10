'use strict';
/* Unique Integers - http://problemotd.com/problem/unique-integers/ */
/* Today's goal is to determine the amount of unique integers in the range [0-1000000]. A unique integer is an integer with no duplicates of numbers. 7 and 18 are unique whereas 99 and 100 are not. Your program should print out just the final count of total unique integers. */

this.window.onload = function () {
  var uniqueIntegers = 0;
  for (var index = 0; index < 1000000; index++) {
    if(checkString(index.toString())) {
      uniqueIntegers = uniqueIntegers + 1;
    }
  }

  this.document.writeln("Unique integers: " + uniqueIntegers);
};

function checkString(chkStr)
{
  if (chkStr.length == 1) {
    return true;
  }

  for (var chkInt = 0; chkInt < 10; chkInt++)
  if (chkStr.indexOf(chkInt.toString()) != chkStr.lastIndexOf(chkInt.toString())) {
    return false;
  }

  return true;
}
