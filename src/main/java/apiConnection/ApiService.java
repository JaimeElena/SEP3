package apiConnection;

import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonObject;
import models.Costumer;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class ApiService implements IApiService
{
    public static final String API_URL = "https://localhost:5001/Costumer";//"https://localhost:5003/Customers"
    Gson gson = new Gson();

    @Override
    public synchronized JsonObject Register(Costumer costumer) throws IOException, InterruptedException
    {
        String costumerGson = gson.toJson(costumer);
        System.out.println(costumerGson);
        /*
        URL url = new URL(API_URL);
        HttpURLConnection conn = (HttpURLConnection) url.openConnection();
        conn.setRequestMethod("POST");
        conn.setRequestProperty("Content-Type", "application/json; utf-8");
        conn.setRequestProperty("Accept", "application/json");
        conn.setDoOutput(true);
        try(OutputStream os = conn.getOutputStream())
        {
            byte[] input = costumerGson.getBytes("utf-8");
            os.write(input, 0, input.length);
        }

        try(BufferedReader br = new BufferedReader(
                new InputStreamReader(conn.getInputStream(), "utf-8"))) {
            StringBuilder response = new StringBuilder();
            String responseLine = null;
            while ((responseLine = br.readLine()) != null) {
                response.append(responseLine.trim());
            }
            System.out.println(response.toString());
        }

        System.out.println("Im here");




        CloseableHttpClient client = HttpClients.createDefault();
        HttpPost httpPost = new HttpPost(API_URL);
        StringEntity requestEntity = new StringEntity(costumerGson, ContentType.APPLICATION_JSON);
        httpPost.setHeader("Accept", "application/json");
        httpPost.setHeader("Content-type", "application/json");
        httpPost.setEntity(requestEntity);

        HttpResponse response = client.execute(httpPost);
        HttpEntity entity = response.getEntity();

        System.out.println("Im here");

         */
        HttpClient client = HttpClient.newHttpClient();

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(costumerGson))
                .build();

        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.statusCode());
        System.out.println(response.body());

        return null;
    }

    @Override
    public synchronized JsonArray GetAllCostumers() throws IOException, InterruptedException
    {
        /*
        HttpClient client = HttpClient.newHttpClient();
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(API_URL))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JsonParser jsonParser = new JsonParser();
        JsonArray jsonArray = (JsonArray) jsonParser.parse(response.body());

        System.out.println(jsonArray.toString());
        return jsonArray;

         */
        return null;
    }
}
