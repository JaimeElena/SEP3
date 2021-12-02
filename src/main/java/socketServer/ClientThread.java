package socketServer;

import apiConnection.ApiService;
import apiConnection.IApiService;
import com.google.gson.Gson;
import models.Costumer;
import models.Request;
import org.json.JSONObject;

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
            System.out.println("im in the connection");
            int byteCount ;


            while(true)
            {
                while((byteCount =  in.read(byteStream)) != 0)
                {
                    System.out.println("jere");
                    json = new String(byteStream, 0, byteCount);
                    break;
                }
                System.out.println(json);

                JSONObject jsonObject = new JSONObject(json);
                Request request = new Request((String)jsonObject.get("Type"), jsonObject.get("Body"));
                System.out.println(request.toString());

                if(request.getType().equals("register"))
                {
                    Costumer costumer = gson.fromJson(request.getBody().toString(), Costumer.class);
                    System.out.println(costumer.toString());
                    String apiResponse = apiService.Register(costumer);
                    out.write(apiResponse.getBytes());
                    json = "";
                }
                else if(request.getType().equals("edit"))
                {

                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
