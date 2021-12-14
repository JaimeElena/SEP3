package models;

public class CustomerOrder
{
    private int id;
    private String destinationStreetName;
    private Location customerLocation;
    private Costumer customer;
    private Driver driver;
    private String status;
    private String estimatedTime;
    private String distance;
    private String price;

    public CustomerOrder() {};

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public CustomerOrder(int id, String destinationStreetName, Location customerLocation, Costumer customer, Driver driver, String status, String estimatedTime, String distance, String price)
    {
        this.id = id;
        this.destinationStreetName = destinationStreetName;
        this.customerLocation = customerLocation;
        this.customer = customer;
        this.driver = driver;
        this.status = status;
        this.estimatedTime = estimatedTime;
        this.distance = distance;
        this.price = price;
    }

    public String getDestinationName()
    {
        return destinationStreetName;
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
        this.destinationStreetName = destinationName;
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

    public String toString()
    {
        return "Results: " + status + estimatedTime + customer.toString();
    }
}
