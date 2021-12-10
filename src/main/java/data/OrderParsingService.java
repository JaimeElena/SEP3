package data;

import apiConnection.ILocationService;
import models.CustomerOrder;
import models.Location;
import models.Order;

import java.io.IOException;

public class OrderParsingService implements IOrderParsingService
{
    public OrderParsingService(){};

    @Override
    public Order ParseCustomerOrder(CustomerOrder customerOrder, ILocationService locationService) throws IOException, InterruptedException
    {
        Location destinationLocation = locationService.GetLocationFromStreetName(customerOrder.getDestinationName());
        Location customerLocation = customerOrder.getCustomerLocation();
        Order order = new Order(destinationLocation.getLat(), destinationLocation.getLng(), customerLocation.getLat(), customerLocation.getLng(), customerOrder.getCustomer().getUsername(), null, "Pending");
        System.out.println(order.toString());
        return order;
    }


}
