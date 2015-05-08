'use strict';
/* Telephone Words - Telephone Words */
/* Each number on the telephone dial (except 0 and 1) corresponds to three alphabetic characters. Those correspondences are:

2 ABC
3 DEF
4 GHI
5 JKL
6 MNO
7 PRS
8 TUV
9 WXY

Given a 7 digit phone number, print all possible words that can be formed. For bonus points write the program to solve for N digit phone numbers. Here is a dictionary to help you out (English).*/

this.window.onload = function () {
  var words = [];
  var letters = [
    ['a','b','c'],
    ['d','e','f'],
    ['g','h','i'],
    ['j','k','l'],
    ['m','n','o'],
    ['p','r','s'],
    ['t','u','v'],
    ['w','x','y']
  ];

  function findWords(searchText, charIndex, wordList) {
    var newWordList = [];

    var searchIndex = searchText.substr(charIndex,1);
    if (searchIndex === 0 || searchIndex == 1) {
      return [];
    }

    for(var word in wordList)
    {
      if (wordList[word].substr(charIndex,1) === letters[searchIndex-2][0] || wordList[word].substr(charIndex,1) === letters[searchIndex-2][1] || wordList[word].substr(charIndex,1) === letters[searchIndex-2][2]) {
        newWordList.push(wordList[word]);
      }
    }

    if (charIndex < searchText.length - 1) {
      newWordList = findWords(searchText, charIndex + 1, newWordList);
    }

    return newWordList;
  }

  var request = new XMLHttpRequest();
  request.onreadystatechange = function () {
    if (request.readyState === 4 && request.status === 200) {
      words = request.responseText.split('\r\n');
    }
  };
  request.open('GET', 'wordsEn.txt', true);
  request.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
  request.send(null);

  var textBox = document.createElement('input');
  textBox.setAttribute('id', 'inputText');
  textBox.setAttribute('type', 'text');
  textBox.setAttribute('value', '8675309');
  textBox.addEventListener('input', function() {
    document.getElementById('results').innerHTML = "";
    var searchText = document.getElementById('inputText').value;
    var foundWordList = findWords(searchText, 0, words);
    if (foundWordList.length === 0) {
      document.getElementById('results').innerHTML = "No words found";
    }
    else {
      for(var wordIndex in foundWordList) {
        document.getElementById('results').innerHTML += foundWordList[wordIndex] + '\r\n';
      }
    }
  });

  var results = document.createElement('div');
  results.setAttribute('id', 'results');

  this.document.body.appendChild(textBox);
  this.document.body.appendChild(results);
};
