package models;

public class CustomerOrder
{
    private String destinationName;
    private Location customerLocation;
    private Costumer customer;
    private Driver driver;
    private String status;
    private String estimatedTime;

    public CustomerOrder(String destinationName, Location customerLocation, Costumer customer, Driver driver, String status, String estimatedTime)
    {
        this.destinationName = destinationName;
        this.customerLocation = customerLocation;
        this.customer = customer;
        this.driver = driver;
        this.status = status;
        this.estimatedTime = estimatedTime;
    }

    public String getDestinationName()
    {
        return destinationName;
    }

    public Location getCustomerLocation()
    {
        return customerLocation;
    }

    public Costumer getCustomer()
    {
        return customer;
    }

    public Driver getDriver()
    {
        return driver;
    }

    public String getStatus()
    {
        return status;
    }

    public String getEstimatedTime()
    {
        return estimatedTime;
    }

    public void setDestinationName(String destinationName)
    {
        this.destinationName = destinationName;
    }

    public void setCustomerLocation(Location customerLocation)
    {
        this.customerLocation = customerLocation;
    }

    public void setCustomer(Costumer customer)
    {
        this.customer = customer;
    }

    public void setDriver(Driver driver)
    {
        this.driver = driver;
    }

    public void setStatus(String status)
    {
        this.status = status;
    }

    public void setEstimatedTime(String estimatedTime)
    {
        this.estimatedTime = estimatedTime;
    }
}
