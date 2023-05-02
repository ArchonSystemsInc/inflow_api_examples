import uuid
import requests
import constants
import json

def get_product(productId: uuid.UUID):
    print("getting product")
    print("")
    url = f'{constants.baseUrl}/{str(productId)}'
    response = requests.get(url, headers=constants.headers)
    print(response.json())
    print("")


def create_product(productId: uuid.UUID):
    print("creating product")
    print("")
    product = {"productId": str(productId), "itemType": "stockedProduct",
               "trackSerials": False, "name": str(productId)}
    response = requests.put(constants.baseUrl, data=json.dumps(
        product), headers=constants.headers)
    print(response.json())
    print("")


def update_product(productId: uuid.UUID):
    print("updating product")
    print("")
    product = {"productId": str(productId), "description": "updated"}
    response = requests.get(constants.baseUrl, data=json.dumps(
        product), headers=constants.headers)
    print(response.json())
    print("")

productId = uuid.uuid4()
create_product(productId)
get_product(productId)
update_product(productId)
