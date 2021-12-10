package models;

public class Driver
{
    private int id;
    private String username;
    private String password;
    private String birthday;
    private String firstname;
    private String secondname;
    private String sex;
    private String numberPlate;
    private boolean isFree;
    private boolean isLogged;

    public Driver(String username, String password)
    {
        this.username = username;
        this.password = password;
    }

    public Driver(int id,  String username, String password, String birthday, String firstname, String secondname, String sex, String numberPlate)
    {
        this.id = id;
        this.username = username;
        this.password = password;
        this.birthday = birthday;
        this.firstname = firstname;
        this.secondname = secondname;
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
        return secondname;
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
        this.secondname = lastname;
    }

    public void setSex(String sex)
    {
        this.sex = sex;
    }

    public void setFree(boolean free)
    {
        isFree = free;
    }

    public String toString()
    {
        return username + id + password + birthday + firstname + secondname + sex + numberPlate;
    }
}
