using System.Collections;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] float limitDistance = 10;

    void DespawnByDistance()
    {
        if (Mathf.Abs(transform.position.x - Camera.main.transform.position.x) <= limitDistance) return;
        Destroy(this.gameObject);

    }

    private void Update()
    {
        DespawnByDistance();
    }
}