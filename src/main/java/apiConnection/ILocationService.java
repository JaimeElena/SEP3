package apiConnection;

import models.Location;

import java.io.IOException;

public interface ILocationService
{
    String GetDistance(String loc1, String loc2) throws IOException, InterruptedException;
    String GetStreetNameFromLocation(Location location) throws IOException, InterruptedException;
    String GetEstimatedTime(String loc1, String loc2) throws IOException, InterruptedException;
    Location GetLocationFromStreetName(String streetName) throws IOException, InterruptedException;
}
