package apiConnection;

import com.google.gson.JsonArray;
import models.*;

import java.io.IOException;

public interface IApiDriverService
{
    String Register(Driver driver) throws IOException, InterruptedException;
    String Login(Driver driver) throws IOException, InterruptedException;
    JsonArray GetAllDrivers() throws IOException, InterruptedException;
    Driver GetDriverByUsername(String username) throws IOException, InterruptedException;
    String EditDriver(Driver driver) throws IOException, InterruptedException;
    String Logout(Driver driver) throws IOException, InterruptedException;
    String GetAllPendingRequests() throws IOException, InterruptedException;
    String AcceptOrder(Order order) throws IOException, InterruptedException;
    String CompleteOrder(Order order) throws IOException, InterruptedException;
}
