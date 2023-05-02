use std::error::Error;
use std::sync::Arc;
use std::time::Duration;

use reqwest::header::{HeaderMap, ACCEPT, AUTHORIZATION, USER_AGENT};
use reqwest::Client;
use serde_json::json;

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let api_key = "";
    let company_id = "";
    let api_version = "2021-04-26";
    let base_url = format!(
        "https://cloudapi.inflowinventory.com/{}/products",
        company_id
    );

    let client = Arc::new(
        Client::builder()
            .timeout(Duration::from_secs(60))
            .default_headers(create_headers(api_key, api_version)?)
            .build()?,
    );

    let product_id = uuid::Uuid::new_v4();
    create_product(&client, &base_url, &product_id).await?;
    get_product(&client, &base_url, &product_id).await?;
    update_product(&client, &base_url, &product_id).await?;

    let product_ids = vec![
        uuid::Uuid::new_v4(),
        uuid::Uuid::new_v4(),
        uuid::Uuid::new_v4(),
        uuid::Uuid::new_v4(),
        uuid::Uuid::new_v4(),
    ];
    create_products(&client, &base_url, &product_ids).await?;

    Ok(())
}

fn create_headers(api_key: &str, api_version: &str) -> Result<HeaderMap, Box<dyn Error>> {
    let mut headers = HeaderMap::new();
    headers.insert(USER_AGENT, "Rust reqwest app".parse().unwrap());
    headers.insert(
        AUTHORIZATION,
        format!("Bearer {}", api_key).parse().unwrap(),
    );
    headers.insert(
        ACCEPT,
        format!("application/json;version={}", api_version)
            .parse()
            .unwrap(),
    );

    Ok(headers)
}

async fn get_product(
    client: &Client,
    base_url: &str,
    product_id: &uuid::Uuid,
) -> Result<(), Box<dyn Error>> {
    println!("GetProduct");

    let url = format!("{}/{}", base_url, product_id);
    let response = client.get(&url).send().await?;

    println!("{:?}", response);

    Ok(())
}

async fn create_product(
    client: &Client,
    base_url: &str,
    product_id: &uuid::Uuid,
) -> Result<(), Box<dyn Error>> {
    println!("CreateProduct {}", product_id.to_string());

    let product = json!({
        "ProductId": product_id.to_string(),
        "ItemType": "StockedProduct",
        "TrackSerials": false,
        "Name": product_id.to_string()
    });

    let response = client.put(base_url).json(&product).send().await?;

    println!("{:?}", response);

    Ok(())
}

async fn create_products(
    client: &Client,
    base_url: &str,
    product_ids: &[uuid::Uuid],
) -> Result<(), Box<dyn Error>> {
    println!("CreateProducts {}", product_ids.len());

    let products: Vec<_> = product_ids
        .iter()
        .map(|product_id| {
            json!({
                "ProductId": product_id.to_string(),
                "ItemType": "StockedProduct",
                "TrackSerials": false,
                "Name": product_id.to_string()
            })
        })
        .collect();

    let response = client.put(base_url).json(&products).send().await?;

    println!("{:?}", response);

    Ok(())
}

async fn update_product(
    client: &Client,
    base_url: &str,
    product_id: &uuid::Uuid,
) -> Result<(), Box<dyn Error>> {
    println!("UpdateProduct {}", product_id.to_string());

    let product = json!({
        "ProductId": product_id.to_string(),
        "Description": "Blah",
    });

    let response = client.put(base_url).json(&product).send().await?;

    println!("{:?}", response);

    Ok(())
}
