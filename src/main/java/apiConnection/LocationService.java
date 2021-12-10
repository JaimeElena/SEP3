package apiConnection;

import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
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
    private final String API_URL_STREETNAME = "https://maps.googleapis.com/maps/api/geocode/json?address=Fussingsvej8,8700HorsensA&key=AIzaSyCSEWcCV-DTiIsJU2NsMHM41RlbU5w6AQM";
    private HttpClient client;

    public LocationService()
    {
        client = HttpClient.newHttpClient();
    }

    @Override
    public double GetDistance(Location loc1, Location loc2) throws IOException, InterruptedException
    {
        String formatedURL = String.format(API_URL_LATLNG, loc1.getLat(), loc2.getLat());
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(API_URL_LATLNG))
                .build();
        HttpResponse<String> response = client.send(request, HttpResponse.BodyHandlers.ofString());
        System.out.println(response.body());
        JsonParser jsonParser = new JsonParser();
        JsonObject jsonObject = (JsonObject) jsonParser.parse(response.body());

        System.out.println(jsonObject.toString());
        return 0;
    }



    @Override
    public String GetStreetName(Location location)
    {

        return null;
    }

    @Override
    public String GetEstimatedTime(Location loc1, Location loc2)
    {
        return null;
    }

    @Override
    public Location GetLocationFromStreetName(String streetName) throws IOException, InterruptedException {
        HttpRequest request = HttpRequest.newBuilder()
                .GET()
                .header("accept", "application/json")
                .uri(URI.create(API_URL_STREETNAME))
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
