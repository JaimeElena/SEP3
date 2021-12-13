package data;

import apiConnection.ILocationService;
import models.CustomerOrder;
import models.Order;

import java.io.IOException;

public class OrderParsingService implements IOrderParsingService
{
    public OrderParsingService(){};

    @Override
    public Order ParseCustomerOrder(CustomerOrder customerOrder, ILocationService locationService) throws IOException, InterruptedException
    {
        String cStreetName = locationService.GetStreetNameFromLocation(customerOrder.getCustomerLocation());
        Order order = new Order(cStreetName, customerOrder.getDestinationName(), customerOrder.getCustomer().getUsername(), null, "Pending");
        System.out.println(order.toString());
        return order;
    }

    @Override
    public CustomerOrder ParseDriverOrder(Order order)
    {
        return null;
    }


}
