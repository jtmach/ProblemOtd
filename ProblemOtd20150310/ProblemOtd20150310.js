'use strict';
/* Lowercase A's - http://problemotd.com/problem/lowercase-as/ */
/* Happy Monday!

Over the weekend there was a discussion of bad programmers in the work force over on Hacker News. One comment suggested that several employed engineers couldn't figure out the number of lowercase A's in a string. So today's challenge is to find the number of lowercase A's in this post.

Note: you don't have to count the A's in the html for the link to the comment.*/

//Short answer: postText.match(/a/g).length

this.window.onload = function () {
  var postText = 'Happy Monday! Over the weekend there was a discussion of bad programmers in the work force over on Hacker News. One comment suggested that several employed engineers couldn\'t figure out the number of lowercase A\'s in a string. So today\'s challenge is to find the number of lowercase A\'s in this post. Note: you don\'t have to count the A\'s in the html for the link to the comment.';
  var regexPattern = /a/g;
  this.document.writeln(postText);
  this.document.writeln("<br />");
  this.document.writeln("Count of A\'s: " + postText.match(regexPattern).length);
  this.document.writeln("<br />");
  this.document.writeln(postText.replace(regexPattern, '<b>a</b>'));
};
