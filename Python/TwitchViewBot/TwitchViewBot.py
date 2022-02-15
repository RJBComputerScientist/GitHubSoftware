import concurrent.futures, time, random, os

# Channel To Bot
Channel_Url = 'https://www.twitch.tv/'
# Number Of Bots
botcount = 5
# Path To Proxy List
Proxy_Path = "/Users/kingbrooks/Desktop/Proxy1.txt"
#Path To VLC
PlayerPath = r'"/Applications/VLC.app/Contents/MacOS"'

#import os
#dirname = os.path.dirname(__file__)
#filename = os.path.join(dirname, 'relative/path/to/file/you/want')
#^^^ maybe this if PlayerPath doesnt work

#Takes Proxies From Proxies file and return to list
def create_proxy_list(proxyfile, shared_list):
    with open(proxyfile, 'r') as file:
        proxies = [line.strip() for line in file]
    for i in proxies:
        shared_list.append((i))
    return shared_list

# Takes Random Proxies From The Proxies List And Adds Them To Another List
def randProxy(proxyList, BotCount):
    randomproxyList = list()
    for _ in range(BotCount):
        proxy = random.choice(proxyList)
        randomproxyList.append(proxy) 
        proxyList.remove(proxy)
    return (randomproxyList)

#Launches A Viewer Bot After A Short-Delay
def LaunchBots(proxy):
    time.sleep(random.randint(5, 20))
    os.system(f'streamlink --player={PlayerPath} --player-no-close --player-http  --hls-segment-timeout 30 --hls-segment-attempts 3 --retry-open 1 --retry-streams 1 --retry-max 1 --http-stream-timeout 3600 --http-proxy {proxy} {Channel_Url} worst')

#Calls The LaunchBots Function Asynchronously
def main(randomProxyList):
    with concurrent.futures.ThreadPoolExecutor() as executer:
        executer.map(LaunchBots, randomProxyList)

if __name__ == "__main__":
    main(randProxy(create_proxy_list(Proxy_Path, shared_list=list()), botcount))