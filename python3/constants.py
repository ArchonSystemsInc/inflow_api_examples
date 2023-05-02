companyId = ""
apiKey = ""
apiVersion = "2021-04-26"

headers = {
    "Authorization": f"Bearer {apiKey}",
    "Content-Type": "application/json",
    "Accept": f"application/json;version={apiVersion}"
}

baseUrl = f"https://cloudapi.inflowinventory.com/{companyId}/products"
