using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    [SerializeField] List<IObserver> observers = new List<IObserver>();

    [SerializeField] int kill = 0;

   
    public void KillUp()
    {
        kill++;
        OnKillUp();
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    void OnKillUp()
    {
        foreach (IObserver observer in observers)
        {
            observer.OnPlayerKillUp(kill);
        }
    }

}