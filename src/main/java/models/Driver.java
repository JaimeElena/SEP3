package models;

public class Driver
{
    private int id;
    private String username;
    private String password;
    private String birthday;
    private String firstname;
    private String lastname;
    private String sex;
    private String numberPlate;
    private boolean isFree;
    private boolean isLogged;

    public Driver(int id,  String username, String password, String birthday, String firstname, String lastname, String sex, String numberPlate)
    {
        this.id = id;
        this.username = username;
        this.password = password;
        this.birthday = birthday;
        this.firstname = firstname;
        this.lastname = lastname;
        this.numberPlate = numberPlate;
        this.sex = sex;
        isFree = true;
        isLogged = false;
    }

    public String getUsername()
    {
        return username;
    }

    public String getPassword()
    {
        return password;
    }

    public String getBirthday()
    {
        return birthday;
    }

    public String getFirstname()
    {
        return firstname;
    }

    public String getLastname()
    {
        return lastname;
    }

    public String getSex()
    {
        return sex;
    }

    public boolean isFree()
    {
        return isFree;
    }

    public void setUsername(String username)
    {
        this.username = username;
    }

    public void setPassword(String password)
    {
        this.password = password;
    }

    public void setBirthday(String birthday)
    {
        this.birthday = birthday;
    }

    public void setFirstname(String firstname)
    {
        this.firstname = firstname;
    }

    public void setLastname(String lastname)
    {
        this.lastname = lastname;
    }

    public void setSex(String sex)
    {
        this.sex = sex;
    }

    public void setFree(boolean free)
    {
        isFree = free;
    }
}
