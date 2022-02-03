def factorialIterative(n):
    result = 1
    for factor in range(n, 0, -1):
        result = result * factor
    return result

def factorialRecursive(n):
    if n == 1:
        return 1
    else:
        return factorialRecursive(n - 1)

    
def main():
    n = int(input("Please enter a whole number between 1 and 20: "))
    nBang = factorialIterative(n)
    print("Iterative: " + str(n) + "! = " + str(nBang))
    nBang = factorialRecursive(n)
    print("Recursive: " + str(n) + "! = " + str(nBang))

if __name__ == '__main__':
    main()
