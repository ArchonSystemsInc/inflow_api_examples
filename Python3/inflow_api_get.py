import requests

companyId = ""
apiKey = ""
apiVersion = "2021-04-26"

headers = {
    "Authorization": f"Bearer {apiKey}",
    "Content-Type": "application/json",
    "Accept": f"application/json;version={apiVersion}"
}

url = f"https://cloudapi.inflowinventory.com/{companyId}/sales-orders"

response = requests.get(url, headers=headers)
print(response)
