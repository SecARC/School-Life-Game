using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void Call()
    {
        for (int i = listeners.Count-1; i >= 0; i--)
        {
            listeners[i].onSignalCalled();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void deRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
