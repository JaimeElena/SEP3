package socketServer;

import apiConnection.*;
import com.google.gson.Gson;
import data.IOrderParsingService;
import data.OrderParsingService;
import models.*;
import org.json.JSONObject;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class ClientThread extends Thread
{
    private static Socket socket;
    private Gson gson;
    private IApiCustomerService apiCustomerService;
    private IApiDriverService apiDriverService;
    private ILocationService locationService;
    private IOrderParsingService parsingService;

    public ClientThread(Socket socket)
    {
        this.socket = socket;
        gson = new Gson();
        apiCustomerService = new ApiCustomerService();
        apiDriverService = new ApiDriverService();
        locationService = new LocationService();
        parsingService = new OrderParsingService();
        System.out.println("Connection started");
    }

    public void StartThread()
    {
        try {
            String json = "";
            InputStream in = socket.getInputStream();
            OutputStream out = socket.getOutputStream();


            byte[] byteStream = new byte[1024];
            System.out.println("im in the connection");
            int byteCount;


            while (true)
            {
                while ((byteCount = in.read(byteStream)) != 0)
                {
                    json = new String(byteStream, 0, byteCount);
                    break;
                }
                System.out.println(json);

                JSONObject jsonObject = new JSONObject(json);
                Request request = new Request((String) jsonObject.get("Type"), jsonObject.get("Body"), (String) jsonObject.get("RequestEntity"));
                System.out.println(request.toString());

                if (request.getType().equals("register"))
                {
                    if (request.getRequestEntity().equals("costumer"))
                    {
                        Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                        System.out.println(costumer.toString());
                        String apiResponse = apiCustomerService.Register(costumer);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                    else if (request.getRequestEntity().equals("driver"))
                    {
                        Driver driver = gson.fromJson(request.getBody().toString(), Driver.class);
                        System.out.println(driver.toString());
                        String apiResponse = apiDriverService.Register(driver);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                } else if (request.getType().equals("login"))
                {
                    if (request.getRequestEntity().equals("costumer"))
                    {
                        Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                        Costumer costumerTemp = new Costumer(costumer.getUsername(), costumer.getPassword());
                        System.out.println(costumer.toString());
                        String apiResponse = apiCustomerService.Login(costumerTemp);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                    else if (request.getRequestEntity().equals("driver"))
                    {
                        Driver driver = gson.fromJson(request.getBody().toString(), Driver.class);
                        Driver driverTemp = new Driver(driver.getUsername(), driver.getPassword());
                        System.out.println(driver.toString());
                        String apiResponse = apiDriverService.Login(driverTemp);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                }
                else if (request.getType().equals("logout"))
                {
                    if (request.getRequestEntity().equals("costumer"))
                    {
                        Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                        Costumer costumerTemp = new Costumer(costumer.getUsername(), costumer.getPassword());
                        System.out.println(costumer.toString());
                        String apiResponse = apiCustomerService.Logout(costumerTemp);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                    else if (request.getRequestEntity().equals("driver"))
                    {
                        Driver driver = gson.fromJson(request.getBody().toString(), Driver.class);
                        Driver driverTemp = new Driver(driver.getUsername(), driver.getPassword());
                        System.out.println(driver.toString());
                        String apiResponse = apiDriverService.Logout(driverTemp);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }

                }
                else if (request.getType().equals("edit"))
                {
                    if (request.getRequestEntity().equals("costumer"))
                    {
                        Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                        String apiResponse = apiCustomerService.EditCostumer(costumer);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                    else if (request.getRequestEntity().equals("driver"))
                    {
                        Driver driver = gson.fromJson(request.getBody().toString(), Driver.class);
                        String apiResponse = apiDriverService.EditDriver(driver);
                        out.write(apiResponse.getBytes());
                        json = "";
                    }
                }
                else if (request.getType().equals("requestvehicle"))
                {
                    CustomerOrder customerOrder = gson.fromJson(request.getBody().toString(), CustomerOrder.class);
                    System.out.println(customerOrder.getCustomerLocation().toString());
                    System.out.println(customerOrder.getCustomer().toString());
                    Order order = parsingService.ParseCustomerOrder(customerOrder, locationService);
                    String apiResponse = apiCustomerService.RequestOrder(order);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("getPendingOrders"))
                {
                    String apiResponse = apiDriverService.GetAllPendingRequests();
                    System.out.println(apiResponse);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("acceptOrder"))
                {
                    String apiResponse = apiDriverService.GetAllPendingRequests();
                    System.out.println(apiResponse);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
