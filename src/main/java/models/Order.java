package models;

public class Order
{
    private int id;
    private String customerStreetName;
    private String destinationStreetName;
    private String customer;
    private String driver;
    private String status;

    public Order() { }

    public Order(int id, String customerStreetName, String destinationStreetName, String customer, String driver, String status)
    {
        this.id = id;
        this.customerStreetName = customerStreetName;
        this.destinationStreetName = destinationStreetName;
        this.customer = customer;
        this.driver = driver;
        this.status = status;
    }

    public int getId()
    {
        return id;
    }

    public String getCustomerStreetName()
    {
        return customerStreetName;
    }

    public String getDestinationStreetName()
    {
        return destinationStreetName;
    }

    public String getCustomer() {
        return customer;
    }

    public String getDriver() {
        return driver;
    }

    public String getStatus() {
        return status;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setCustomerStreetName(String customerStreetName) {
        this.customerStreetName = customerStreetName;
    }

    public void setDestinationStreetName(String destinationStreetName) {
        this.destinationStreetName = destinationStreetName;
    }

    public void setCustomer(String customer) {
        this.customer = customer;
    }

    public void setDriver(String driver) {
        this.driver = driver;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String toString()
    {
        return status;
    }
}
