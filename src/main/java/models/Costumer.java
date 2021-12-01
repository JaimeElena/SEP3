package models;

import java.sql.Date;

public class Costumer
{
    private int id;
    private String name;
    private String password;
    private Date birthday;
    private String firstName;
    private String secondName;

    public Costumer(int id, String name, String password)
    {
        this.id = id;
        this.name = name;
        this.password = password;
    }

    public Costumer( String username, String password)
    {

        this.name = username;
        this.password = password;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public void setUsername(String username)
    {
        this.name = username;
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
        return name;
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
        return "Id: " + id + "Username: " + name;
    }
}
