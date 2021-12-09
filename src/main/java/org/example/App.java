package org.example;

import apiConnection.ApiCustomerService;
import apiConnection.IApiCustomerService;
import apiConnection.ILocationService;
import apiConnection.LocationService;
import models.Costumer;
import models.Driver;
import models.Location;
import models.Order;

import java.io.IOException;




/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws IOException, InterruptedException
    {
        IApiCustomerService apiService = new ApiCustomerService();
        ILocationService locationService = new LocationService();

        Location loc1 = new Location();
        Location loc2 = new Location();

        Costumer costumer = new Costumer("Buger King","5678", "2001.04.02","Siyu","Xia", "M");
        Driver driver = new Driver("deee", "1234","22-07-00","ada","as","M", "3245A");
        Order order = new Order(loc1, loc2, costumer, driver, "Pending", null);

        apiService.RequestOrder(order);
    }
}
