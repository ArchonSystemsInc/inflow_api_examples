import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse.BodyHandlers;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

class inFlowApi {

  private static String _apiVersion = "2021-04-26";
  private static String _apiKey = "";
  private static String _companyId = "";
  private static HttpClient _client = HttpClient.newHttpClient();
  private static String _baseUrl =
    "https://cloudapi.inflowinventory.com/" + _companyId + "/products";

  public static void main(String args[]) {
    UUID productId = UUID.randomUUID();
    createProduct(productId);
  }

  public static void getProduct(UUID productId) {
    // create a request
    var request = HttpRequest
      .newBuilder(URI.create(_baseUrl))
      .header("Accept", "application/json;version=" + _apiVersion)
      .header("User-Agent", "C# console app")
      .header("Authorization", "Bearer " + _apiKey)
      .build();

    // use the client to send the request
    var responseFuture = _client.sendAsync(request, BodyHandlers.ofString());

    // We can do other things here while the request is in-flight

    // This blocks until the request is complete
    try {
      var response = responseFuture.get();
      System.out.println(response.body());
    } catch (Exception e) {
      System.out.println(e.toString());
    }
  }

  public static void createProduct(UUID productId) {
    // create a request
    var request = HttpRequest
      .newBuilder(URI.create(_baseUrl))
      .method("PUT")
      .header("Accept", "application/json;version=" + _apiVersion)
      .header("User-Agent", "C# console app")
      .header("Authorization", "Bearer " + _apiKey)
      .build();

    // use the client to send the request
    var responseFuture = _client.sendAsync(request, BodyHandlers.ofString());

    // We can do other things here while the request is in-flight

    // This blocks until the request is complete
    try {
      var response = responseFuture.get();
      System.out.println(response.body());
    } catch (Exception e) {
      System.out.println(e.toString());
    }
  }
}
