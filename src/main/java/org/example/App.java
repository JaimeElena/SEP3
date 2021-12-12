package org.example;

import apiConnection.*;
import data.IOrderParsingService;
import data.OrderParsingService;
import models.*;

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
        IApiDriverService apiDriverService = new ApiDriverService();
        IOrderParsingService orderParsingService = new OrderParsingService();

        Location loc1 = new Location();
        Location loc2 = new Location();
        Costumer costumer = new Costumer("Random", "1234");
        Driver driver  = new Driver("Tim", "1234");

        //CustomerOrder customerOrder = new CustomerOrder("Fussingsvej8,8700Horsens", loc1, costumer, driver, "pending", "" );
        //Order order = orderParsingService.ParseCustomerOrder(customerOrder, locationService);

        //locationService.GetDistance(loc1, loc2);
        //apiService.RequestOrder(order);
        //apiDriverService.GetAllPendingRequests();
        locationService.GetDistance(null, null);

    }
}
