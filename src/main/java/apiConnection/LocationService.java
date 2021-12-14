package apiConnection;

import models.Location;
import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class LocationService implements  ILocationService
{
    private final String API_URL_LATLNG = "https://maps.googleapis.com/maps/api/geocode/json?latlng=55.872559066987634,9.88610200179567&key=AIzaSyCSEWcCV-DTiIsJU2NsMHM41RlbU5w6AQM";
    private final String API_URL_STREETNAME = "https://maps.googleapis.com/maps/api/geocode/json?address=%sA&key=AIzaSyCSEWcCV-DTiIsJU2NsMHM41RlbU5w6AQM";
    private final String API_URL_DISTANCE = "https://maps.googleapis.com/maps/api/distancematrix/json?&units=imperial&origins=%s&destinations=%s&key=AIzaSyCSEWcCV-DTiIsJU2NsMHM41RlbU5w6AQM";
    private HttpClient client;

    public LocationService()
    {
        client = HttpClient.newHttpClient();
    }


    @Override
    public String GetDistance(String loc1, String loc2) throws IOException, InterruptedException
    {
        //String formatedURL = String.format(API_URL_LATLNG, loc1.getLat(), loc2.getLat());
        //HttpRequest request = HttpRequest.newBuilder()
        //      .GET()
        //    .header("accept", "application/json")
        //  .uri(URI.create(API_URL_LATLNG))
        //.build();
        //HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        //System.out.println(response.body());
        //JsonParser jsonParser = new JsonParser();
        //JsonObject jsonObject = (JsonObject) jsonParser.parse(response.body());

        //System.out.println(jsonObject.toString());
        String formatted_URL = String.format(API_URL_DISTANCE, loc1.replace(" ", ""), loc2);
        System.out.println(formatted_URL);

        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(formatted_URL))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JSONObject jsonObject =  new JSONObject(response.body());
        JSONArray params = jsonObject.getJSONArray("rows");
        String distance = params.getJSONObject(0).getJSONArray("elements").getJSONObject(0).getJSONObject("distance").getString("text");
      //  Location location = new Location(object.getDouble("lat"), object.getDouble("lng"));


        System.out.println("Distance: " + distance);
        return distance;
    }


    @Override
    public String GetStreetNameFromLocation(Location location) throws IOException, InterruptedException {

        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(API_URL_LATLNG))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JSONObject jsonObject =  new JSONObject(response.body());
        JSONArray params = jsonObject.getJSONArray("results");
        String object = params.getJSONObject(0).getString("formatted_address");

        System.out.println(object);

        return object;
    }

    @Override
    public String GetEstimatedTime(String loc1, String loc2) throws IOException, InterruptedException {
        String formatted_URL = String.format(API_URL_DISTANCE, loc1.replace(" ", ""), loc2);

        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(formatted_URL))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JSONObject jsonObject =  new JSONObject(response.body());
        JSONArray params = jsonObject.getJSONArray("rows");
        String duration = params.getJSONObject(0).getJSONArray("elements").getJSONObject(0).getJSONObject("duration").getString("text");
        //  Location location = new Location(object.getDouble("lat"), object.getDouble("lng"));

        System.out.println("Estimated time: " + duration);
        return duration;
    }

    @Override
    public Location GetLocationFromStreetName(String streetName) throws IOException, InterruptedException {
        String formatted_Url = String.format(API_URL_STREETNAME, streetName.replace(" ", ""));
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(formatted_Url))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JSONObject jsonObject =  new JSONObject(response.body());
        JSONArray params = jsonObject.getJSONArray("results");
        JSONObject object = params.getJSONObject(0).getJSONObject("geometry").getJSONObject("location");
        Location location = new Location(object.getDouble("lat"), object.getDouble("lng"));

        System.out.println(location.toString());

        return location;
    }
}
