package data;

import apiConnection.ILocationService;
import models.CustomerOrder;
import models.Order;

import java.io.IOException;

public interface IOrderParsingService
{
    Order ParseCustomerOrder(CustomerOrder customerOrder, ILocationService locationService) throws IOException, InterruptedException;
    CustomerOrder ParseDriverOrder(Order order);
}
