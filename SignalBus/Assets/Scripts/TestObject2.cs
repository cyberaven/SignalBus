using UnityEngine;
using System.Collections;

public class TestObject2 : MonoBehaviour, IListen
{
    
    

    private void Start()
    {
        //Подписались и какой сигнал ждем
        SignalBus.INSTANCE.RegListener(this, new Signal(111, "FrstSignal"));      
    }
   
    public void ItIsMySignal(Signal signal) //ждем нашего сигнала
    {
        Debug.Log("I work.");
        DoWork();        
    }

    private void DoWork()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }   
}
