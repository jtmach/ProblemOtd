'use strict';
/* Daily Compounded Interest - http://problemotd.com/problem/daily-compounded-interest/ */
/* Today's problem is a fun one to dream about. The objective is to create a function that takes in an initial value and a percentage and return the amount of money you could make off interest compounded daily in the stock market. Since the market's days aren't fixed you can just calculate the number of weekdays in the current year (no need to worry about holidays). An example would be:

Rate of 1%
Day 1: 10000
Day 2: 10100
Day 3: 10201

It's crazy how much money you could make at 1% compounded daily over the course of a year!*/

this.window.onload = function () {
  var startDate = new Date();
  var endDate = new Date(startDate);
  endDate.setDate(startDate.getDate() + 365);
  var startingAmount = 10000;
  var returnPercent = 0.01;
  var currentAmount = 0;

  writeMsg("Start Date: " + formatDate(startDate));
  writeMsg("End Date: " + formatDate(endDate));
  writeMsg("Start Amount: $" + formatNumber(startingAmount));
  writeMsg("Return Percent: " + formatNumber(returnPercent*100) + "%");
  writeMsg("");

  while (startDate <= endDate) {
    if (startDate.getDay() != 0 && startDate.getDay() != 6) {
      if (currentAmount == 0) {
        currentAmount = startingAmount;
      }
      else {
        currentAmount = currentAmount + (currentAmount * returnPercent);
      }
    }

    writeMsg(formatDate(startDate) + ": $" + formatNumber(currentAmount));
    startDate.setDate(startDate.getDate() + 1);
  }
};
function formatNumber(amount) {
  return amount.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
}
function formatDate(dt) {
  return dt.getMonth() + "/" + dt.getDate() + "/" + dt.getFullYear();
}
function writeMsg(message) {
  document.writeln(message + "<br />");
}
