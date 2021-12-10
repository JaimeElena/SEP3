package models;

public class Order
{
    private int id;
    private double dlat;
    private double dlng;
    private double clat;
    private double clng;
    private String customer;
    private String driver;
    private String status;

    public Order(double dlat, double dlng, double clat, double clng, String customer, String driver, String status)
    {
        this.dlat = dlat;
        this.dlng = dlng;
        this.clat = clat;
        this.clng = clng;
        this.customer = customer;
        this.driver = driver;
        this.status = status;
    }

    public int getId()
    {
        return id;
    }

    public double getDlat()
    {
        return dlat;
    }

    public double getDlng()
    {
        return dlng;
    }

    public double getClat()
    {
        return clat;
    }

    public double getClng() {
        return clng;
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
    public String toString()
    {
        return status;
    }
}
