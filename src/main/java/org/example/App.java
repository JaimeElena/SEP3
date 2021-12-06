package org.example;

import apiConnection.ApiCustomerService;
import apiConnection.IApiCustomerService;
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
        IApiCustomerService apiService = new ApiCustomerService();


        Costumer temp = new Costumer(2,"Randomnn", "1234", "22-07-00", "Randy", "Andom", "Male");
        apiService.EditCostumer(temp);
    }
}
