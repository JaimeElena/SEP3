package models;

public class Request
{
    private String type;
    private Object body;

    public Request(String type, Object body)
    {
        this.type = type;
        this.body = body;
    }

    public void setType(String type)
    {
        this.type = type;
    }

    public void setBody(Object body)
    {
        this.body = body;
    }

    public String getType()
    {
        return type;
    }

    public Object getBody()
    {
        return body;
    }

    public String toString()
    {
        return "Type: " + type + " Object: " + body.toString();
    }
}
