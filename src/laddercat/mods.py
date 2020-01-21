import asyncio
import aiohttp
import json
from .config import pages

infos = []
lock = asyncio.Lock()
done = False

url = "https://addons-ecs.forgesvc.net/api/v2/addon/search"
def params(page, pageSize=25):
    return  {
        "categoryid": 0,
        "gameId": 432,
        "gameVersion": "1.12.2",
        "index": pageSize * page,
        "pageSize": pageSize,
        "sectionId": 6,
        "sort": 0
    }

async def worker(queue: asyncio.Queue, session: aiohttp.ClientSession):
    global done
    while not done:
        page = await queue.get()
        page_params = params(page)
        print(f"开始获取 [{page}] ")
        async with session.get(url, params=page_params) as response:
            data = await response.json()
            print(f"获取 [{page}] 完毕")
            async with lock:
                infos.append(data)

async def proer(queue: asyncio.Queue):
    global done
    for i in range(pages):
        await queue.put(i)
    done = True

async def main():
    queue = asyncio.Queue(3)
    async with aiohttp.ClientSession() as session:
        await asyncio.wait([
            worker(queue, session),
            worker(queue, session),
            worker(queue, session),
            worker(queue, session),
            worker(queue, session),
            proer(queue)
        ])

loop = asyncio.get_event_loop()
loop.run_until_complete(main())

print(len(infos))
json.dump(infos, open("./modinfo.json", "w"))