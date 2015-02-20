'use strict';
/* Integer Humanize - http://problemotd.com/problem/integer-humanize/ */
/* Today's problem you will hopefully find super useful. It will likely come in handy in some project for the future.
The goal is to convert integers to their character/language equivalent. Your program should be able to do up to
999 thousand. For example:
9 => nine
245 = > two hundred fourty five
99999 => ninety nine thousand nine hundred
My examples use English but feel free to use whatever language you are most comfortable with.*/

this.window.onload = function () {
  for (var intVal = 1; intVal <= 1000000; intVal++) {
    this.document.writeln(intVal + " => " + GetText(intVal.toString()) + "<br />");
  }
};
function GetText(numVal) {
  var result = "";
  var hundredsCount = Math.floor((numVal.length - 1) / 3) + 1;
  for (var hundredsIndex = 0; hundredsIndex < hundredsCount; hundredsIndex++) {
    if (hundredsIndex == (hundredsCount - 1)) {
      switch (hundredsIndex) {
        case 1:
          result = " thousand " + result;
          break;
        case 2:
          result = " million " + result;
          break;
        case 3:
          result = " billion " + result;
          break;
      }

      if (numVal.length % 3 === 0) {
        result = GetHundreds(numVal.substr(numVal.length - ((hundredsIndex * 3) + 3), 3)) + " " + result;
      }
      else {
        result = GetHundreds(numVal.substr(numVal.length - ((hundredsIndex * 3) + (numVal.length % 3)), numVal.length % 3)) + " " + result;
      }
    }
    else {
      result = GetHundreds(numVal.substr(numVal.length - ((hundredsIndex + 1) * 3), 3)) + result;
    }
  }
  return result;
}
function GetHundreds(numVal) {
  switch(numVal.length) {
    case 1:
      return GetSingle(numVal.charAt(numVal.length - 1));
    case 2:
      return GetTens(numVal.substr(numVal.length - 2, 2));
    case 3:
      if (numVal.charAt(numVal.length - 3) != "0") {
        return GetSingle(numVal.charAt(numVal.length - 3)) + " hundred " + GetTens(numVal.substr(numVal.length - 2, 2));
      }
      return GetSingle(numVal.charAt(numVal.length - 3)) + " " + GetTens(numVal.substr(numVal.length - 2, 2));
    default:
      return ' ';
  }
}
function GetSingle(numVal) {
  switch (numVal) {
    case '1':
      return "one";
    case '2':
      return "two";
    case '3':
      return "three";
    case '4':
      return "four";
    case '5':
      return "five";
    case '6':
      return "six";
    case '7':
      return "seven";
    case '8':
      return "eight";
    case '9':
      return "nine";
    default:
      return "";
  }
}
function GetTens(numVal) {
  switch (numVal.charAt(0)) {
    case '0':
      return " " + GetSingle(numVal.charAt(1));
    case '1':
      switch (numVal.charAt(1)) {
        case '1':
          return "eleven";
        case '2':
          return "twelve";
        case '3':
          return "thirteen";
        case '4':
          return "fourteen";
        case '5':
          return "fifteen";
        case '6':
          return "sixteen";
        case '7':
          return "seventeen";
        case '8':
          return "eighteen";
        case '9':
          return "nineteen";
        default:
          return "ten";
      }
      break;
    case '2':
      return "twenty" + " " + GetSingle(numVal.charAt(1));
    case '3':
      return "thirty" + " " + GetSingle(numVal.charAt(1));
    case '4':
      return "fourty" + " " + GetSingle(numVal.charAt(1));
    case '5':
      return "fifty" + " " + GetSingle(numVal.charAt(1));
    case '6':
      return "sixty" + " " + GetSingle(numVal.charAt(1));
    case '7':
      return "seventy" + " " + GetSingle(numVal.charAt(1));
    case '8':
      return "eighty" + " " + GetSingle(numVal.charAt(1));
    case '9':
      return "ninety" + " " + GetSingle(numVal.charAt(1));
    default:
      return "";
  }
}
