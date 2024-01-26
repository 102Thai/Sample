using System.Collections;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] float speed = 1;

    public void Flying()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    public void Update()
    {
        Flying();
    }

}