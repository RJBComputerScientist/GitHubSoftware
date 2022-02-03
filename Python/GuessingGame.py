import random

target = random.randint(1,100)

print('I am thinking of a number from one to ten!')
print('Guess the number!')
print("You'll have one chance to get it right")

guess = int(input("What's your guess?"))
count = 1

while guess != target:
    print("Nope try again.")
    guess = int(input("Next guess, you're" + guessCounter + "to the number"))
    guessCounter = target.scanner(input)
    count += 1
      
      
print('It took you ' + str(count) + " guesses.")
