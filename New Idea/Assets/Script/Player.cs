using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (PlayerController))]
[RequireComponent (typeof (GunController))]
//force it to add the player controller scripgt along with it
public class Player : MonoBehaviour
{
    public float moveSpeed = 5;
    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }
 
    // Update is called once per frame
    void Update()
    {
        //Move Input
        //GetAxisRaw make mure it won't have default smoothing for movement
        Vector3 moveInput = new Vector3 (Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        //normalized in order to only get the direction
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);
        
        // Look Input
        //ScreenPointToRay returns a ray going from camera through a screen point
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        //get normal vector of the plane
        Plane groundPlane = new Plane(Vector3.up,Vector3.zero);
        float rayDistance;
        //out: give out a variable(here is rayDistance), assign that Variable a value
        //if statement will be true if the Ray intersects with the ground plane
        if(groundPlane.Raycast(ray,out rayDistance))
        {
           //ray.getpoint Returns a point at distance units along the ray. (here we get the intersection)
            Vector3 point = ray.GetPoint(rayDistance);
            // Debug.DrawLine (ray.origin,point,Color.red);
            controller.LookAt(point);
        }


        //Weapon Input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }

    }
}
