class Stack():

    def __init__(self):
        self.list = []

    def push(self, e):
        self.list.append(e)

    def pop(self):
        return self.list.pop()

    def peek(self):
        return self.list[-1]

    def isEmpty(self):
        return self.list == []

    def size(self):
        return len(self.list)

'''
#This program parses and evaluates a fully parenthesized arithmetic expression
#comprised of addition, subtraction, multiplication and division operations.

#The only error checking done is avoiding an attempt to divide by zero.
'''

def main():

    operators = '+-*/'
    digits = '0123456789.'

    operandsStack = Stack()

    expression = '()'

    while True:

        print('Please enter a postfix arithmetic expression and the computer will evaluate it.')
        print('For example, 3 5 7 * + equals 38')
        print('Enter quit or an empty line to end the program: ', end='')
        expression = input()

        if len(expression) == 0 or expression == 'quit':
            break

        operand = ''

        i = 0

        while i < len(expression):

            if (expression[i] == ' ') : #or (expression[i] == '('):
                i += 1
                continue

            # This code will loop through the stack and evaluate the expression with i as the iterator
            # than with operators being called from the top.
            if expression[i] in operators:
                op2 = operandsStack.pop()
                op1 = operandsStack.pop()
                if expression[i] == '+':
                    operandsStack.push(op1 + op2)
                elif expression[i] == '-':
                    operandsStack.push(op1 - op2)
                elif expression[i] == '*':
                    operandsStack.push(op1 * op2)
                elif expression[i] == '/':
                    if op2 == 0:
                        print('Whoops! Cannot divide by 0! Result is unreliable.')
                        break
                    operandsStack.push(op1 / op2)
        

            elif expression[i] in digits: # build up the operand
                operand = operand + expression[i]
                # look ahead and if next character in the expression is not
                # a digit or decimal point, then operand token is complete
                if expression[i+1] not in digits:
                    operandsStack.push(float(operand))
                    operand = ''

            

            i +=1

        if not operandsStack.isEmpty():
            print(expression + ' evaluates to: ' + str(operandsStack.pop()), end='\n\r')


if __name__ == '__main__':
    main()
