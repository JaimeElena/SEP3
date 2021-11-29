package org.example;

import apiConnection.ApiService;
import apiConnection.IApiService;

import java.io.IOException;




/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args ) throws IOException, InterruptedException
    {
        IApiService apiService = new ApiService();

        apiService.GetAllCostumers();

    }
}
