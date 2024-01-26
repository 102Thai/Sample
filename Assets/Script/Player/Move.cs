using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class Move :MonoBehaviour
{
    [SerializeField] float speed = 1;
    
    public void Moving(InputManager input)
    {
        transform.Translate(new Vector3(input.horizontal, 0, 0)*speed*Time.deltaTime);
    }



}