using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour, IListen
{
    private void Start()
    {
        //Подписались и какой сигнал ждем
        SignalBus.INSTANCE.RegListener(this, new Signal(ESignalSelfName.SSpecialSignalID1));
        //ждем нашего сигнала
       
        //отправили сигнал
        SignalBus.INSTANCE.ThrowSignal(new Signal(ESignalSelfName.SFrstSignalID1));
    }
   
    public void ItIsMySignal(Signal signal)
    {
        DoWork();

        if (signal.SelfName == ESignalSelfName.SDestroySignalID2)
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
