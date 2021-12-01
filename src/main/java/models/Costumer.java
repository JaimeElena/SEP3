package models;

import java.sql.Date;

public class Costumer
{
    private int id;
    private String username;
    private String password;
    private Date birthday;
    private String firstName;
    private String secondName;

    public Costumer(int id, String username, String password)
    {
        this.id = id;
        this.username = username;
        this.password = password;
    }

    public Costumer( String username, String password)
    {

        this.username = username;
        this.password = password;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setUsername(String username)
    {
        this.username = username;
    }

    public void setPassword(String password)
    {
        this.password = password;
    }

    public void setBirthday(Date birthday)
    {
        this.birthday = birthday;
    }

    public void setFirstName(String firstName)
    {
        this.firstName = firstName;
    }

    public void setSecondName(String secondName)
    {
        this.secondName = secondName;
    }

    public int getId()
    {
        return id;
    }

    public String getUsername()
    {
        return username;
    }

    public String getPassword()
    {
        return password;
    }

    public Date getBirthday()
    {
        return birthday;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getSecondName()
    {
        return secondName;
    }

    public String toString()
    {
        return "Id: " + id + "Username: " + username;
    }
}
