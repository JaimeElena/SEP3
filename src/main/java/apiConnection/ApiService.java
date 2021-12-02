package apiConnection;

import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonParser;
import models.Costumer;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class ApiService implements IApiService
{
    public static final String API_URL = "https://localhost:5001/Costumer";
    Gson gson = new Gson();
    HttpClient client;

    public ApiService()
    {
        client = HttpClient.newHttpClient();
    }

    @Override
    public synchronized String Register(Costumer costumer) throws IOException, InterruptedException
    {
        String costumerGson = gson.toJson(costumer);
        System.out.println(costumerGson);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL))
                .header("Content-Type", "application/json")
                .POST(HttpRequest.BodyPublishers.ofString(costumerGson))
                .build();

        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.statusCode());
        System.out.println(response.body());

        return String.valueOf(response.statusCode());
    }

    @Override
    public String Login(Costumer costumer) throws IOException, InterruptedException
    {
        String jsonChangeAttribute = "{\"isLogged\": [\"true\"]";

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL))
                .method("PATCH", HttpRequest.BodyPublishers.ofString(jsonChangeAttribute))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());

        return String.valueOf(response.statusCode());
    }

    @Override
    public synchronized JsonArray GetAllCostumers() throws IOException, InterruptedException
    {
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
    }
}