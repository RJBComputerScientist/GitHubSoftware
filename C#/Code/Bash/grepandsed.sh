#!usr/bin/bash

#A word in history

if grep -q "medicine" ./.bash_history;
then
	echo "I see mediicine in your history"
else 
	echo "You a liar"
fi

#grep '.*\.sh$'

if grep -q '.*\.sh$' ~/desktop/github/RyanB
then 
	echo "I found one or more shell files"
else 
	echo "You have no shell files"
fi

#grep is finding a word and doing a action when found, you can also involve a 
#else statement

#sed is finding a word and replacing that word with another  
