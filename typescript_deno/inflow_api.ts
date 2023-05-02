import { baseUrl, headers } from "./constants";

async function getProduct(productId: string) {
    console.log('getting product');
    const url = `${baseUrl}/${productId}`
    const response = await fetch(url, { headers });
    console.log(response);
}

async function createProduct(productId: string) {
    console.log('creating product');
    const product = { productId, itemType: "StockedProduct", trackSerials: false, name: productId };
    const response = await fetch(baseUrl, { headers, method: "put", body: JSON.stringify(product) });
    console.log(response);
}

async function updateProduct(productId: string) {
    console.log('creating product');
    const product = { productId, description: "updated" };
    const response = await fetch(baseUrl, { headers, method: "put", body: JSON.stringify(product) });
    console.log(response);
}

const productId = crypto.randomUUID()
await createProduct(productId)
await getProduct(productId)
await updateProduct(productId)