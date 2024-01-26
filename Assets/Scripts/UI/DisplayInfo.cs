using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfo : MonoBehaviour,IObserver
{
    [SerializeField] Text killsOfPlayerTxt;

    public void OnPlayerKillUp(int kill)
    {
        killsOfPlayerTxt.text = kill.ToString();
    }
}