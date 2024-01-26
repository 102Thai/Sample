using System.Collections;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    [SerializeField] int hp, resetHP, revivalTime;

    private void Awake()
    {
        resetHP = hp;
    }

    public void DeductHP(int damage)
    {
        hp -= damage;
    }

    public void Die(Info info)
    {
        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
            info.KillUp();
            StartCoroutine(Revive());
        }
    }

    IEnumerator Revive()
    {
        yield return new WaitForSeconds(revivalTime);
        this.gameObject.SetActive(true);
        hp = resetHP;
    }
}