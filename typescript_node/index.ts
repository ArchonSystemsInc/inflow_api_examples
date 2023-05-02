import { v4 as uuidv4 } from "uuid"
import axios, { AxiosError, isAxiosError } from "axios"

const apiKey = ""
const companyId = ""
const apiVersion = "2021-04-26"


const headers = {
  Authorization: `Bearer ${apiKey}`,
  "Content-Type": "application/json",
  Accept: `application/json;version=${apiVersion}`,
}

const baseUrl = `https://cloudapi.inflowinventory.com/${companyId}/products`

async function getProduct(productId: string) {
  try {
    console.log(`getting product ${productId}\n`)
    const url = `${baseUrl}/${productId}`
    const response = await axios.get(url, { headers })
    console.log(response.status)
    console.log("\n")
  } catch (error) {
    if (isAxiosError(error)) {
      console.error(error.response)
    }
  }
}

async function createProduct(productId: string) {
  try {

    console.log(`creating product ${productId}\n`)
    const product = {
      productId: productId,
      itemType: "stockedProduct",
      trackSerials: false,
      name: productId,
    }
    const response = await axios.put(baseUrl, product, { headers })
    console.log(response.status)
    console.log("\n")

  } catch (error) {
    if (isAxiosError(error)) {
      console.error(error.response)
    }
  }
}

async function updateProduct(productId: string) {
  try {
    console.log(`updating product ${productId}\n`)
    const product = { productId: productId, description: "updated" }
    const response = await axios.put(baseUrl, product, { headers })
    console.log(response.status)
    console.log("\n")
  } catch (error) {
    if (isAxiosError(error)) {
      console.error(error.response)
    }
  }
}

const productId = uuidv4()
createProduct(productId).then(() => getProduct(productId)).then(() => updateProduct(productId))