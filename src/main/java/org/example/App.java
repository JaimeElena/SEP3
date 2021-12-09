package org.example;

import apiConnection.*;

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

        apiDriverService.GetDriverByUsername("Tim");

        //Location loc1 = new Location();
        //Location loc2 = new Location();

        //Costumer costumer = new Costumer(1,"Buger King","5678", "2001.04.02","Siyu","Xia", "M");
        //Driver driver = new Driver(3,"deee", "1234","22-07-00","ada","as","M", "3245A");
        //Order order = new Order(loc1, loc2, costumer, driver, "Pending", null);

        //apiService.RequestOrder(order);
    }
}
