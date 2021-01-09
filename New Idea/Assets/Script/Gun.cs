using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;

    //fire rate
    public float msBetweenShots = 100;

    //the speed at which the bullet will leave the gun
    public float muzzleVelocity = 35;

    float nextShotTime;
    public void Shoot()
    {
        //only shot if the current time is greater than nextShottime
        if (Time.time > nextShotTime) {
            nextShotTime = Time.time + msBetweenShots/1000;
            Projectile newProjectile = Instantiate(projectile,muzzle.position,muzzle.rotation) as Projectile;
            newProjectile.Setspeed(muzzleVelocity);
        }
        

    }
}
