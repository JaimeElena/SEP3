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
            serverSocket = new ServerSocket(5000);
            System.out.println("Server started...");
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }

    public static void main(String[] args)
    {
        Socket socket;
        try
        {

            while(true)
            {
                socket = serverSocket.accept();
                ClientThread clientThread = new ClientThread(socket);
                clientThread.StartThread();
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
