using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] Move playerMove;
    [SerializeField] Jump playerJump;
    [SerializeField] Shoot playerShoot;
    [SerializeField] Info playerInfo;
    [SerializeField] GetDamage playerGetDamage;

    [SerializeField] DisplayInfo playerDisplayInfo;

    [SerializeField] Bullet bullet1;

    public void Start()
    {
        playerInfo.AddObserver(playerDisplayInfo);
    }

    private void Update()
    {
        playerMove.Moving(inputManager);
        playerJump.Jumping(inputManager);
        playerShoot.Shooting(bullet1, inputManager);
        playerGetDamage.Die(playerInfo);
    }

    
}
