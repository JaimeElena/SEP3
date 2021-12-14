package data;

import apiConnection.IApiCustomerService;
import apiConnection.IApiDriverService;
import apiConnection.ILocationService;
import models.*;

import java.io.IOException;

public class OrderParsingService implements IOrderParsingService
{
    public OrderParsingService(){};

    @Override
    public Order ParseCustomerOrder(CustomerOrder customerOrder, ILocationService locationService) throws IOException, InterruptedException
    {
        String cStreetName = locationService.GetStreetNameFromLocation(customerOrder.getCustomerLocation());
        Order order = new Order(customerOrder.getId(), cStreetName, customerOrder.getDestinationName(), customerOrder.getCustomer().getUsername(), null, "Pending");
        System.out.println(order.toString());
        return order;
    }

    @Override
    public CustomerOrder ParseDriverOrder(Order order, IApiDriverService apiDriverService, ILocationService locationService, IApiCustomerService apiCustomerService) throws IOException, InterruptedException
    {
        Driver driver = null;
        if(order.getDriver() != null)
        {
            driver = apiDriverService.GetDriverByUsername(order.getDriver());
        }
        Costumer customer = apiCustomerService.GetCostumerByUsername(order.getCustomer());
        String distance = locationService.GetDistance(order.getCustomerStreetName(), order.getDestinationStreetName());
        String estimatedTime = locationService.GetEstimatedTime(order.getCustomerStreetName(), order.getDestinationStreetName());
        Location customerLocation = locationService.GetLocationFromStreetName(order.getCustomerStreetName());

        CustomerOrder customerOrder = new CustomerOrder(order.getId(), order.getDestinationStreetName(), customerLocation, customer, driver, order.getStatus(), estimatedTime, distance, "2.09$");
        return customerOrder;
    }


}
