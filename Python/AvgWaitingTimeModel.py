import random

class Queue:

    # __init__ is automatically called at object instantiation
    def __init__(self):
        self.list = []

    def enqueue(self, e):
        self.list.append(e)

    def dequeue(self):
        temp = self.list[0]
        del self.list[0]
        return temp

    def isEmpty(self):
        return self.list == []

    def size(self):
        return len(self.list)


class Customer:

    # class level variables (would be declared as static in Java)
    nextCustomerID = 0
    nextCustomerArrivalTime = 0

    # following items allow for a fixed set of
    # arrival times and service durations so that
    # simulation results are reproducible
    randomATsAndSDs = True   # set to False to apply fixed values
    fixedATs = (1, 3, 2, 0)
    atx    = 0
    fixedSDs = (2, 4, 7, 3, 5, 1, 6, 0)
    sdx    = 0

    def __init__(self, interArrivalTime, serviceDurationRange):
        # ID, arrivalTime, serviceStartTime and serviceDuration are Customer attributes
        # aka instance variables
        Customer.nextCustomerID += 1
        self.ID = Customer.nextCustomerID
        self.arrivalTime = Customer.nextCustomerArrivalTime
        self.serviceStartTime = 0  # will be set when customer assigned to server
        if Customer.randomATsAndSDs:
            self.serviceDuration = random.randint(serviceDurationRange[0], serviceDurationRange[1])
            Customer.nextCustomerArrivalTime += random.randint(interArrivalTime[0], interArrivalTime[1])
        else:
            self.serviceDuration = Customer.fixedSDs[Customer.sdx]
            Customer.sdx = (Customer.sdx + 1) % len(Customer.fixedSDs)
            Customer.nextCustomerArrivalTime += Customer.fixedATs[Customer.atx]
            Customer.atx = (Customer.atx + 1) % len(Customer.fixedATs)

        #print("customer #" + str(self.ID) + "   arrival time: " + str(self.arrivalTime) + "   service duration: " + str(self.serviceDuration))


class Server:

    def __init__(self):
        self.customer = None
        # customer is the only member in the Server class and
        # is either None (i.e., null) or is the Customer object
        # currently assigned to that server


def status(t, q, c):
    print("clock: " + str(t) + "   queue: " + str(q) + "    customer #" + str(c.ID) + "   arrived: " + str(c.arrivalTime)
    + "   svc start time: " + str(c.serviceStartTime) + "   svc duration: " + str(c.serviceDuration))


# study parameters: ---------------------------------

customerCount = 100000

IAT = [0, 4]  # inter-arrival time - range of time between customer arrivals
SDR = [0, 10]  # service duration range - min and max time a customer will be at the server

''' First Set
IAT = [0, 1]
SDR = [0, 7]
'''

''' Second Set
IAT = [0, 2]
SDR = [0, 7]
'''

''' third Set
IAT = [0, 3]
SDR = [0, 7]
'''

''' Fourth Set
IAT = [0, 4]
SDR = [0, 7]
'''

''' Fifth Set
IAT = [0, 4]
SDR = [0, 8]
'''

''' Sixth Set
IAT = [0, 4]
SDR = [0, 9]
'''

''' Seventh Set
IAT = [0, 4]
SDR = [0, 10]
'''

numberOfServers = 4

print('~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~')
print(f'Average waiting time simulation for {customerCount} customers\n')
print(f'There are a total of {numberOfServers} servers, each with its own queue.\n')
print(f'The next customer arrives between {IAT[0]} and {IAT[1]} time units after the previous customer\nand is assigned to the server with the least number of customers in its queue.\n')
print(f'Once a customer gets to a server, it takes between {SDR[0]} and {SDR[1]} time units to serve them.\n')

# ---------------------------------------------------

customersArrived = 0
customersServed  = 0
totalTimeInQ     = 0
totalSvcDuration = 0

servers = [Server() for i in range(numberOfServers)]
queues  = [Queue()  for i in range(numberOfServers)]

# first customer arrives at clock == 0
nextCustomer = Customer(IAT, SDR)

clock = 0

# main loop of the simulation
while customersServed < customerCount:

    # process all customers who arrive at this time ---------------------------------------
    while (nextCustomer.arrivalTime == clock) and (customersArrived < customerCount):

        customersArrived += 1

        # add next customer to shortest queue
        # following logic also checks the server of each empty queue
        # to see if it is idle - once an empty queue with an idle server
        # is found, the search is over
        if queues[0].size() == 0 and servers[0].customer is None:
            # look no further
            shortestQueue = 0
            shortestQueueLength = queues[0].size()
        else:
            # assume the first is the shortest, but check the remaining queues
            shortestQueue = 0
            shortestQueueLength = queues[0].size()
            q = 1
            while q < len(queues):
                if queues[q].size() == 0 and servers[q].customer is None:
                    # look no further
                    shortestQueue = q
                    shortestQueueLength = queues[q].size()
                    break
                if queues[q].size() < shortestQueueLength:
                    shortestQueue = q
                    shortestQueueLength = queues[q].size()
                q += 1

        # next customer must wait in line if there is someone else already in line
        # or the associated server is busy
        if (shortestQueueLength > 0) or (servers[shortestQueue].customer is not None):
            queues[shortestQueue].enqueue(nextCustomer)
        else:
            nextCustomer.serviceStartTime = clock
            if nextCustomer.serviceDuration > 0:
                servers[shortestQueue].customer = nextCustomer
            else:
                # customer's serviceDuration == 0, so they are immediately served
                # customer went directly to a server, so no need to increment totalTimeInQ
                # customer's serviceDuration is 0, so no need to increment totalSvcDuration
                customersServed += 1

        # who's next?
        if customersArrived < customerCount:
            nextCustomer = Customer(IAT, SDR)

    # end of next customer loop -----------------------------------------------------------

    # now check the current state of each of the servers ----------------------------------

    s = 0  # index variable to loop through the list of servers

    while s < len(servers):

        if servers[s].customer is not None:
            # if there is a customer assigned to this server check if they are done being served
            if (servers[s].customer.serviceStartTime + servers[s].customer.serviceDuration) == clock:
                totalTimeInQ += servers[s].customer.serviceStartTime - servers[s].customer.arrivalTime
                totalSvcDuration += servers[s].customer.serviceDuration
                customersServed += 1
                servers[s].customer = None

        if servers[s].customer is None:
            # if this server is available see if there is any customer waiting in its queue
            if not queues[s].isEmpty():
                nextInQ = queues[s].dequeue()
                nextInQ.serviceStartTime = clock
                if nextInQ.serviceDuration > 0:
                    servers[s].customer = nextInQ
                else:
                    # it is possible that the customer just brought in from the queue
                    # has a zero serviceDuration time, in which case they are
                    # immediately served and the server becomes available again
                    totalTimeInQ += nextInQ.serviceStartTime - nextInQ.arrivalTime
                    # customer's serviceDuration is 0, so no need to increment totalSvcDuration
                    customersServed += 1
                    s -= 1  # force server while loop to stay on same server
        s += 1

    # end of server loop ------------------------------------------------------------------

    clock += 1

# simulation completed, here are the results:

print(f'{clock:5d} total elapsed time from first customer arrival until all customers served')
print(f'   {(totalTimeInQ / customerCount):6.3f} average wait time')
print(f'   {(totalSvcDuration / customerCount):6.3f} average service time')
print(' ')



