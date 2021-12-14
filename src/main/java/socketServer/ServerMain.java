package socketServer;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class ServerMain
{
    public static ServerSocket serverSocket = null;

    static
    {
        try
        {
            serverSocket = new ServerSocket(5201);
            System.out.println("Server started...");
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    public static void main(String[] args)
    {
        Socket socket = new Socket();
        try
        {

            while(true)
            {
                socket = serverSocket.accept();
                new ClientThread(socket).start();
                System.out.println("New thread created...");
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
