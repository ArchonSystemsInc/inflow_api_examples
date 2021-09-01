const apiKey = "";
const companyId = "";
const apiVersion = "";

const headers = new Headers({
  "Authorization": `Bearer ${apiKey}`,
  "Content-Type": "application/json",
  "Accept": `application/json;version=${apiVersion}`,
});

const url = `https://cloudapi.inflowinventory.com/${companyId}/sales-orders`;
const response = await fetch(url, { headers });

console.log(response);
