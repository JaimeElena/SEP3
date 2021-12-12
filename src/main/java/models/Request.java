package models;

public class Request
{

    private String type;
    private Object body;
    private String RequestEntity;

    public Request(String type, Object body, String requestEntity)
    {
        this.type = type;
        this.body = body;
        this.RequestEntity = requestEntity;
    }

    public void setType(String type)
    {
        this.type = type;
    }

    public void setBody(Object body)
    {
        this.body = body;
    }

    public String getRequestEntity()
    {
        return RequestEntity;
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
        return "Type: " + type + " Object: " + body.toString() + " RequestEntity: " + RequestEntity;
    }
}
