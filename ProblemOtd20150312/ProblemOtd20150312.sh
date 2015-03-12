#!/bin/bash

#Mobile 6 - http://problemotd.com/problem/mobile-6/
#Today's goal is to try and find an integer where the digit in the ones column is a 6 and when the 6 
#is moved to the front of the number, the number becomes 4 times the value of the starting number.

counter=6

while [ $counter -lt 1000000 ]; do
	if [[ ${counter:${#counter}-1:1} == '6' ]]
	then
	  mult=$(($counter * 4))
	  if [[ $mult == 6${counter:0:${#counter}-1} ]]
	  then
	  	echo $counter $mult 6${counter:0:${#counter}-1}
	  	exit
	  fi
	fi 

	let counter=counter+10
done