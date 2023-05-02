export const apiKey = "";
export const companyId = "";
export const apiVersion = "2021-04-26";

export const headers = new Headers({
  "Authorization": `Bearer ${apiKey}`,
  "Content-Type": "application/json",
  "Accept": `application/json;version=${apiVersion}`,
});

export const baseUrl = `https://cloudapi.inflowinventory.com/${companyId}/products`;