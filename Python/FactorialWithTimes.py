import time

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

    t0 = time.perf_counter()
    nBang = factorialIterative(n)
    t1 = time.perf_counter()
    elapsedTime = t1 - t0
    
    print("Iterative: " + str(n) + "! = " + str(nBang) + "  " + str(elapsedTime))

    t0 = time.perf_counter()
    nBang = factorialRecursive(n)
    t1 = time.perf_counter()
    elapsedTime = t1 - t0
    
    print("Recursive: " + str(n) + "! = " + str(nBang) + "  " + str(elapsedTime))

if __name__ == '__main__':
    main()
