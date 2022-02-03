import random

SwapCount = 0
CompCount = 0

RANDOMVALUES = False

def initValues():
    global values
    if RANDOMVALUES:
        # values = random.sample(range(100), 50)    no duplicates
        values = random.choices(range(100), k=50) # "with replacement"
    else:
        values = [
            28,  1, 80, 99, 31, 16, 43, 58, 87, 84,
            90, 76, 31,  3, 85, 45, 14, 52, 69, 59,
             7,  4, 40,  2, 87, 70, 63, 83, 15, 60,
            60, 25, 12, 15, 27, 97, 41, 53,  2, 73,
            58, 82, 85, 21, 51, 33,  8, 34, 80, 98
        ]

def backupValues():
    global bupValues
    bupValues = values.copy()

def restoreValues():
    global values
    values = bupValues.copy()

def valuesAreSorted():
    for i in range(1,len(values)):
        if values[i] < values[i - 1]:
            return False
    return True

def showValues():
    # assumes the list has 50 elements
    print("Current state of the values array:")
    for i in range(5):
        for j in range(10):
            print(format(values[10*i + j],'5d'),end="")
        print("")
    if valuesAreSorted():
        print(">>>>> values are sorted")
    else:
        print("***** values are not sorted")


def swap(index1, index2):
    global values
    temp = values[index1]
    values[index1] = values[index2]
    values[index2] = temp

#-----------------------------------------------------

def selectionSort():
    global values, SwapCount, CompCount
    indexLast = len(values) - 1
    for i in range(indexLast):
        indexMin = i
        for j in range(indexMin + 1, len(values)):
            CompCount += 1
            if values[j] < values[indexMin]:
                indexMin = j
        swap(i, indexMin)
        SwapCount += 1


def bubbleSort():
    global values, SwapCount, CompCount
    indexLast = len(values) - 1
    for i in range(indexLast):
        for j in range(indexLast, i, -1):
            CompCount += 1
            if values[j] < values[j - 1]:
                swap(j, j - 1)
                SwapCount += 1


def betterBubble():
    global values, CompCount, SwapCount
    indexLast = len(values) - 1
    for x in range(indexLast):
        IsSorted = True
        for z in range(indexLast, x, -1):
            CompCount += 1
            if values[z]<values[z-1]:
                swap(z, z-1)
                SwapCount += 1
                IsSorted=False
        if IsSorted:
            return



def insertionSort():
    global values, SwapCount, CompCount
    indexLast = len(values)
    for x in range(1, indexLast):
        for z in range(x, 0, -1):
            CompCount += 1
            if values[z]<values[z-1]:
                swap(z, z-1)
                SwapCount += 1
            else:
                break
    



# ------- MERGE SORT -------

def merge(leftFirst, leftLast, rightFirst, rightLast):

    global values, CompCount, SwapCount

    temp = [None] * len(values)

    index = leftFirst
    saveLeftFirst = leftFirst # remember where to copy back to

    while leftFirst <= leftLast and rightFirst <= rightLast:
        CompCount += 1
        if values[leftFirst] < values[rightFirst]:
            temp[index] = values[leftFirst]
            leftFirst += 1
        else:
            temp[index] = values[rightFirst]
            SwapCount += 1
            rightFirst += 1
        index += 1

    # any items leftover on the left?
    while leftFirst <= leftLast:
        temp[index] = values[leftFirst]
        leftFirst += 1
        index     += 1

    # any items remaining on the right?
    while rightFirst <= rightLast:
        temp[index] = values[rightFirst]
        rightFirst += 1
        index      += 1

    for index in range(saveLeftFirst, rightLast + 1):
        values[index] = temp[index]


def mergeSort(first, last):
    if first < last:
        mid = (first + last) // 2  # integer division
        mergeSort(first, mid)
        mergeSort(mid + 1, last)
        merge(first, mid, mid + 1, last)


# ------- QUICK SORT -------

def splitTheRange(alpha, omega):

    global values, SwapCount, CompCount

    alphaAtTheStart = alpha
    splitValue = values[alpha]
    alpha +=1

    done = False;
    while not done:

        onCorrectSide = True
        while onCorrectSide:
            CompCount += 1
            if values[alpha] > splitValue:
                onCorrectSide = False
            else:
                alpha += 1
                onCorrectSide = alpha <= omega

        onCorrectSide = alpha <= omega
        while onCorrectSide:
            CompCount += 1
            if values[omega] <= splitValue:
                onCorrectSide = False
            else:
                omega -= 1
                onCorrectSide = alpha <= omega
        CompCount += 1
        if alpha < omega:
            swap(alpha, omega)
            SwapCount += 1
            alpha += 1
            omega -= 1

        done = alpha > omega

    swap(alphaAtTheStart, omega)
    SwapCount += 1
    return omega


def quickSort(first, last):
    if first < last:
        indexSplit = splitTheRange(first, last)
        # values[first] ... values[indexSplit - 1] <= split value
        # values[indexSplit] = split value
        # values[splitPoint + 1] ... values[last]  >  split value
        quickSort(first, indexSplit - 1)
        quickSort(indexSplit + 1, last)


# ------- HEAP SORT -------

def heapify(size, indexRoot):

    global values, CompCount, SwapCount

    indexLargest = indexRoot
    indexLeftChild  = 2 * indexRoot + 1
    indexRightChild = 2 * indexRoot + 2
    CompCount += 2
    if indexLeftChild < size and values[indexLeftChild] > values[indexLargest]:
        indexLargest = indexLeftChild

    if indexRightChild < size and values[indexRightChild] > values[indexLargest]:
        indexLargest = indexRightChild

    if indexLargest != indexRoot:
        SwapCount += 1
        swap(indexRoot, indexLargest)
        heapify(size, indexLargest)


def heapSort( ):

    global values, SwapCount

    # arrange the values in the array as a heap:
    for i in range(len(values) // 2 - 1, -1, -1):
        heapify(len(values), i)

    # move root element to end; re-heap and repeat
    for i in range(len(values) - 1, -1, -1):
        SwapCount += 1
        swap(0, i)
        heapify(i, 0)


#-----------------------------------------------------

initValues()
backupValues()

print("\n\n--- SELECTION SORT ---")
print("BEFORE:")
showValues()
CompCount = SwapCount = 0
selectionSort()
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


print("\n\n--- BUBBLE SORT ---")
restoreValues()
print("BEFORE")
showValues()
CompCount = SwapCount = 0
bubbleSort()
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


print("\n\n--- BETTER BUBBLE SORT ---")
restoreValues()
print("BEFORE")
showValues()
CompCount = SwapCount = 0
betterBubble()
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


print("\n\n--- INSERTION SORT ---")
restoreValues()
print("BEFORE")
showValues()
CompCount = SwapCount = 0
insertionSort()
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


print("\n\n--- MERGE SORT ---")
restoreValues()
print("BEFORE")
showValues()
CompCount = SwapCount = 0
mergeSort(0, len(values) - 1)
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


print("\n\n--- QUICK SORT ---")
restoreValues()
print("BEFORE")
showValues()
CompCount = SwapCount = 0
quickSort(0, len(values) - 1)
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


print("\n\n--- HEAP SORT ---")
restoreValues()
print("BEFORE")
showValues()
CompCount = SwapCount = 0
heapSort()
print("AFTER")
showValues()
print(" ")
print("{:>5} comparisons".format(CompCount))
print("{:>5} swaps".format(SwapCount))


