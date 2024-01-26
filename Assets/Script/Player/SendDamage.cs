using System.Collections;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    int damage;
    [SerializeField] int initDamage, kills;

    private void Awake()
    {
        damage = initDamage;
    }

    public void Send(GetDamage getDamage)
    {
        getDamage.DeductHP(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetDamage getDamage= collision.GetComponent<GetDamage>();
        if (getDamage == null) return;
        Send(getDamage);
    }

}