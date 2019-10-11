using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour, IListen
{
    
    

    private void Start()
    {

        //Подписались и какой сигнал ждем
        SignalBus.INSTANCE.RegListener(this, new Signal(666, "SecondSignal"));
        //ждем нашего сигнала
       
        //отправили сигнал
        SignalBus.INSTANCE.ThrowSignal(new Signal(111, "FrstSignal"));
    }
   
    public void ItIsMySignal(Signal signal)
    {
        DoWork();

        if (signal.SelfName == "SecondSignal")
        {
            DoAnotherWork();
        }
        if (signal.Id == 666)
        {
            DoAnotherAnotherWork();
        }
    }

    private void DoWork()
    {
    }
    private void DoAnotherWork()
    {
    }
    private void DoAnotherAnotherWork()
    {
    }   
}
