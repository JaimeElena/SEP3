package socketServer;

import apiConnection.ApiService;
import apiConnection.IApiService;
import com.google.gson.Gson;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import models.Costumer;
import models.Request;

import java.io.InputStream;
import java.io.OutputStream;
import java.net.Socket;

public class ClientThread extends Thread
{
    private static Socket socket;
    private Gson gson;
    private IApiService apiService;

    public ClientThread(Socket socket)
    {
        this.socket = socket;
        gson = new Gson();
        apiService = new ApiService();
        System.out.println("Connection started");
    }

    public void StartThread()
    {
        try
        {
            String json = "";
            InputStream in = socket.getInputStream();
            OutputStream out = socket.getOutputStream();

            byte[] byteStream = new byte[1024];
            int bytesRead;

            while(true)
            {
                while((bytesRead = in.read(byteStream)) != 0)
                {
                    json = new String(byteStream, 0, bytesRead);
                }
                System.out.println("Im here");
                JsonParser jsonParser = new JsonParser();
                JsonObject jsoNRequest = (JsonObject) jsonParser.parse(json);
                Request request = new Request(jsoNRequest.get("Type").getAsString(), jsoNRequest.get("Body"));
                System.out.println("Im here 2");
                if(request.getType().equals("Register"))
                {
                    System.out.println("Im here 3");
                    Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                    System.out.println("Costumer Received: " + costumer.toString());
                }
            }
        }
        catch (Exception e)
        {

        }
    }
}
