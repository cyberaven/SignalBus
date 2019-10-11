using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalBus : MonoBehaviour
{
    public static SignalBus INSTANCE;
   
    [SerializeField] List<Signal> currentsSignal = new List<Signal>();
    [SerializeField] List<ListenerData> listeners = new List<ListenerData>();

    private void Awake()
    {
        INSTANCE = this; //TO DO: переделать
    }

    private void Update()
    {
        CheckListener();
    }
    private void CheckListener()
    {
        if (listeners.Count > 0 && currentsSignal.Count > 0)
        {
            for (int i = 0; i < listeners.Count; i++)
            {
                ListenerData data = listeners[i];
               
                for (int a = 0; a < currentsSignal.Count; a++)
                {
                    Signal signal = currentsSignal[a];
                        
                    if (data.Signal.SelfName == signal.SelfName || data.Signal.Id == signal.Id)
                    {
                        Debug.Log("Signal Bus: Sig Found - " + data.Listener + " : " + signal.Id + " : " + signal.SelfName);

                        data.Listener.ItIsMySignal(signal);

                        if (data.Signal.OnceTime == true)
                        {
                            DeleteListener(data);
                            DeleteSignal(signal);
                        }
                    }                       
                }
            }
        }
      
    }
    

    public void RegListener(IListen listener, Signal signal, bool onceTime = true)
    {
        Debug.Log("Signal Bus: New Reg - " + listener + " : " + signal.Id + " : " + signal.SelfName);
        ListenerData newData = new ListenerData(listener, signal, onceTime);
        listeners.Add(newData);
    }
   
    public void ThrowSignal(Signal signal)
    {
        Debug.Log("Signal Bus: New Sig - " + signal.Id + " : " + signal.SelfName);
        currentsSignal.Add(signal);
    }

    private void DeleteListener(ListenerData data)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            if (listeners[i] == data)
            {
                Debug.Log("Signal Bus: Listener Data Delete - " + data.Listener + " : " + data.Signal);
                listeners.Remove(data);
            }
        }
    }
    private void DeleteSignal(Signal signal)
    {
        for (int i = 0; i < currentsSignal.Count; i++)
        {
            if(signal == currentsSignal[i])
            {
                Debug.Log("Signal Bus: Signal Delete - " + signal);
                currentsSignal.Remove(signal);                
            }
        }
    }    
}
