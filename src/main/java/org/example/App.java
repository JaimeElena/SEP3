package org.example;

import apiConnection.ApiService;
import apiConnection.IApiService;
import models.Costumer;

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


        Costumer temp = new Costumer(2,"Randomnn", "1234", "22-07-00", "Randy", "Andom", "Male");
        apiService.EditCostumer(temp);
    }
}
