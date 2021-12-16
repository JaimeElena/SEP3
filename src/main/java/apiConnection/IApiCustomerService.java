package apiConnection;

import com.google.gson.JsonArray;
import models.Costumer;
import models.Order;

import java.io.IOException;

public interface IApiCustomerService
{
    String Register(Costumer costumer) throws IOException, InterruptedException;
    String Login(Costumer costumer) throws IOException, InterruptedException;
    JsonArray GetAllCostumers() throws IOException, InterruptedException;
    Costumer GetCostumerByUsername(String username) throws IOException, InterruptedException;
    String EditCostumer(Costumer costumer) throws IOException, InterruptedException;
    String Logout(Costumer costumer) throws IOException, InterruptedException;
    String RequestOrder(Order order) throws  IOException, InterruptedException;
    String GetOrder(int id) throws  IOException, InterruptedException;
    String GetOrderById(int id) throws IOException, InterruptedException;
    String GetOrderHistory(String username) throws  IOException, InterruptedException;
}
