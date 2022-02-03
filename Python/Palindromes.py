import re, time

class Stack():

    def __init__(stack):
        stack.list = []

    def push(stack, o):
        stack.list.append(o)

    def pop(stack):
        return stack.list.pop()

    def peek(stack):
        return stack.list[-1]

    def isEmpty(stack):
        return stack.list == []

    def size(stack):
        return len(stack.list)

class Queue():

    def __init__(e):
        e.list = []

    def enqueue(e, o):
        e.list.append(o)

    def dequeue(e):
        temp = e.list[0]
        del e.list[0]
        return temp

    def isEmpty(e):
        return e.list == []

    def size(e):
        return len(e.list)


#Palindrome Implementations

#Recursive        
def isPalindrome1(string) :
   if len(string) <= 1 :
      return True
   if string[0] == string[len(string) - 1] :
      return isPalindrome1(string[1:len(string) - 1])
   else :
      return False

#Iterative
def isPalindrome2(string) :
    TheString = string
    a = TheString[0]
    b = TheString[len(string)-1]
    for i in range (0, round(len(string)/2)):
        a = TheString[i]
        b = TheString[len(string)-1-i]
        if a != b:
            return False
    return True

#Queue and Stack
def isPalindrome3(string) :
    TheString = string
    TheQueue = Queue()
    TheStack = Stack()

    TopIndex = round((len(string)/2)+.1)
    BottomIndex = TopIndex

    if len(TheString)%2 !=0:
        BottomIndex -= 1

    for z in range(TopIndex):
        TheQueue.enqueue(TheString[z])
    for z in range(TopIndex):
        TheStack.push(TheString[z + BottomIndex])

    #Comparing The Stack & Queue
    for z in range(round(len(string)/2)):
        c = TheQueue.dequeue()
        d = TheStack.pop()

        if c != d:
            return False
    return True

#Timed User input with filtered spaces and special characters
while True:    

    UserString = input("Welcome!! Enter A Palindrome: ")
    
    if len(UserString) == 0 or UserString == 'quit':
        print("Thanks For Playing!!")
        break
    
    
    UserOutput = re.sub('\W+', '', UserString)
    t0 = time.perf_counter()
    RecursiveCheck = isPalindrome1(UserOutput)
    t1 = time.perf_counter()
    ElapsedTime = t1-t0
    print("Is this a palidrome? (Recursive): ", RecursiveCheck, UserOutput,
          "\tIt Took: ", ElapsedTime)

    t0 = time.perf_counter()
    IterativeCheck = isPalindrome2(UserOutput)
    t1 = time.perf_counter()
    ElapsedTime = t1-t0
    print("Is this a palidrome? (Iterative): ", IterativeCheck, UserOutput,
          "\tIt Took: ", ElapsedTime)

    t0 = time.perf_counter()
    StackandQueueCheck = isPalindrome3(UserOutput)
    t1 = time.perf_counter()
    ElapsedTime = t1-t0
    print("Is this a palidrome? (Stack and Queue): ", StackandQueueCheck,
          UserOutput, "\tIt Took: ", ElapsedTime)
    
    UserString = input("Tap Enter To Play Again OR Double Tap Enter To End")

