using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 10;
    // which layers this projectile will collide
    public LayerMask collisionMask;
    public void Setspeed (float newSpeed)
    {
        speed = newSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //cast a ray out with the distance  about to move and see if it hits anything
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);


        //projectile movement
        transform.Translate (Vector3.forward * Time.deltaTime * speed);
    }


    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }
}
