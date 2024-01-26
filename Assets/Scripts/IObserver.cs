using System.Collections;
using UnityEngine;

public interface IObserver
{
    public void OnPlayerKillUp(int kill); // khi số kills của player tăng lên
    
}