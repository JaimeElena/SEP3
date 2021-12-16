package apiConnection;

import com.google.gson.Gson;
import models.Order;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class ApiOrderService implements IApiOrderService
{
    public static final String API_URL_ORDERS = "https://localhost:5003/Orders";
    Gson gson = new Gson();
    HttpClient client;

    public ApiOrderService()
    {
        client = HttpClient.newHttpClient();
    }

    @Override
    public String RequestOrder(Order order) throws IOException, InterruptedException
    {
        String orderJson = gson.toJson(order);
        System.out.println("Sending to server: " + orderJson);
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL_ORDERS))
                .POST(HttpRequest.BodyPublishers.ofString(orderJson))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        return response.body().toString();
    }

    @Override
    public String GetOrder(int id) throws IOException, InterruptedException
    {
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(String.format(API_URL_ORDERS + "/SearchOrderByID?id=%s", id)))
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println("API result: " + response.body().toString());
        JSONObject object = new JSONObject(response.body().toString());

        return object.toString();
    }

    @Override
    public String GetOrderById(int id) throws IOException, InterruptedException
    {

        return null;
    }

    @Override
    public String GetOrderHistory(String username) throws IOException, InterruptedException
    {
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(String.format(API_URL_ORDERS + "/GetHistoryOrders?customer=%s", username)))
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONArray object = new JSONArray(response.body().toString());
        System.out.println(object.toString());
        return response.body().toString();
    }

    @Override
    public String CancelOrder(Order order) throws IOException, InterruptedException
    {
        String orderJson = gson.toJson(order);
        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL_ORDERS+"/CancelOrder"))
                .method("PATCH", HttpRequest.BodyPublishers.ofString(orderJson))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());

        JSONObject object = new JSONObject(response.body().toString());
        System.out.println(object.toString());
        return object.getJSONObject("result").toString();
    }
    @Override
    public String GetAllPendingRequests() throws IOException, InterruptedException
    {
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(API_URL_ORDERS + "/GetPendingOrders"))
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONArray object = new JSONArray(response.body().toString());
        System.out.println(object.toString());
        return response.body().toString();
    }

    @Override
    public String AcceptOrder(Order order) throws IOException, InterruptedException
    {
        String orderJson = gson.toJson(order);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL_ORDERS+"/AcceptOrder"))
                .method("PATCH", HttpRequest.BodyPublishers.ofString(orderJson))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONObject object = new JSONObject(response.body().toString());

        return String.valueOf(object.getJSONObject("result"));
    }

    @Override
    public String CompleteOrder(Order order) throws IOException, InterruptedException
    {
        String orderJson = gson.toJson(order);

        HttpRequest request = HttpRequest.newBuilder()
                .uri(URI.create(API_URL_ORDERS+"/CompleteOrder"))
                .method("PATCH", HttpRequest.BodyPublishers.ofString(orderJson))
                .header("Content-Type", "application/json")
                .build();
        HttpResponse response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body().toString());
        JSONObject object = new JSONObject(response.body().toString());

        return String.valueOf(object.getJSONObject("result"));
    }
}
