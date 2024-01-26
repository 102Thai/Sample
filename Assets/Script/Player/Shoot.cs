using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float timer, delayTime;
    [SerializeField] Transform bulletSpawnPoint;
    private void Awake()
    {
        timer = delayTime;
    }

    public void Shooting(Bullet bullet, InputManager input)
    {
        if (!input.isShoot) return;
        timer -= Time.fixedDeltaTime;
        if (timer > 0) return;
        timer = delayTime;
        Bullet newBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        newBullet.gameObject.SetActive(true);
    }
}