package apiConnection;

import models.Location;

import java.io.IOException;

public interface ILocationService
{
    double GetDistance(Location loc1, Location loc2) throws IOException, InterruptedException;
    String GetStreetName(Location location);
    String GetEstimatedTime(Location loc1, Location loc2);
    Location GetLocationFromStreetName(String streetName) throws IOException, InterruptedException;
}
