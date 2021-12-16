package apiConnection;

import models.Order;

import java.io.IOException;

public interface IApiOrderService
{
    String GetAllPendingRequests() throws IOException, InterruptedException;
    String AcceptOrder(Order order) throws IOException, InterruptedException;
    String CompleteOrder(Order order) throws IOException, InterruptedException;
    String RequestOrder(Order order) throws  IOException, InterruptedException;
    String GetOrder(int id) throws  IOException, InterruptedException;
    String GetOrderById(int id) throws IOException, InterruptedException;
    String GetOrderHistory(String username) throws  IOException, InterruptedException;
    String CancelOrder(Order order) throws IOException, InterruptedException;
}
