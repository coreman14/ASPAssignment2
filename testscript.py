import requests

base_url = r"http://192.168.50.179:81/"
urls = [
    (f"{base_url}book", "g"),
    (f"{base_url}book/book/1", "g"),
    (f"{base_url}book/create", "p"),
    (f"{base_url}book/update/3", "u"),
    (f"{base_url}book/delete/4", "d"),
    (f"{base_url}borrowing", "g"),
    (f"{base_url}borrowing/borrowing/1", "g"),
    (f"{base_url}borrowing/create", "p"),
    (f"{base_url}borrowing/update/3", "u"),
    (f"{base_url}borrowing/delete/4", "d"),
    (f"{base_url}reader", "g"),
    (f"{base_url}reader/reader/1", "g"),
    (f"{base_url}reader/create", "p"),
    (f"{base_url}reader/update/3", "u"),
    (f"{base_url}reader/delete/4", "d"),
]

for x in urls:
    if x[1] == "g":
        print(requests.get(x[0]).json())
    elif x[1] == "p":
        print(requests.post(x[0]).json())
    elif x[1] == "u":
        print(requests.put(x[0]).json())
    elif x[1] == "d":
        print(requests.delete(x[0]).json())
