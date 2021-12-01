package apiConnection;

import com.google.gson.JsonArray;
import com.google.gson.JsonObject;
import models.Costumer;

import java.io.IOException;

public interface IApiService
{
    JsonObject Register(Costumer costumer) throws IOException, InterruptedException;
    JsonArray GetAllCostumers() throws IOException, InterruptedException;
}
