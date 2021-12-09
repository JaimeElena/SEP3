package models;

public class Order
{
    private int id;
    private Location destination;
    private Location customerLocation;
    private Costumer customer;
    private Driver driver;
    private String status;
    private String estimatedTime;

    public Order(Location destination, Location customerLocation, Costumer customer, Driver driver, String status, String estimatedTime)
    {
        this.destination = destination;
        this.customerLocation = customerLocation;
        this.customer = customer;
        this.driver = driver;
        this.status = status;
        this.estimatedTime = estimatedTime;
    }

    public int getId()
    {
        return id;
    }

    public Location getDestination()
    {
        return destination;
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

    public void setId(int id)
    {
        this.id = id;
    }

    public void setDestination(Location destination)
    {
        this.destination = destination;
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
