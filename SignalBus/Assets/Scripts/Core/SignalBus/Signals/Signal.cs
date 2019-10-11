using UnityEngine;
using System.Collections;

public class Signal
{
    private int id = 0;
    public int Id { get => id;}
        
    private string selfName = "";
    public string SelfName { get => selfName;}
    
    private bool onceTime = true;
    public bool OnceTime { get => onceTime; set => onceTime = value; }


    public Signal(int id, string selfName, bool onceTime = true)
    {
        this.id = id;
        this.selfName = selfName;
        this.onceTime = onceTime;
    }    
    private void Start()
    {
        CheckSignalData();
    }


    private void CheckSignalData()
    {
        if(id == 0)
        {
            DestroySelf();
        }
        if(selfName == "")
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Debug.Log("I'am DestroySelf. ");// TO DO : Доделать        
    }


}
