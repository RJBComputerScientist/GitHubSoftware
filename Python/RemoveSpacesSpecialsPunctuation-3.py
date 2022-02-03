import re

phrase = ''
while phrase != 'quit':
    print("Please enter phrase for palindrome checkers; enter quit to end.")
    phrase = input()
    stripped = re.sub('\W+', '', phrase)
    print("CLEAN: " + stripped)
