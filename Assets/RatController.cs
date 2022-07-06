using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public float move = 0;
    public bool canJump = true;
    public bool isJump = false;
    public float sideSpeed = 0.01f;
    public float movementSpeed = 1;
    public float time = 0;
    public AnimationCurve animation = null;
    public GameObject map;
    public StatusController status;
    
    private void Update()
    {
        movementSpeed = StatusController.getSpeed();

        if (Input.GetKeyDown(KeyCode.A))
        {
            move = -1;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            move = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            move = 0;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!isJump && canJump)
            {
                isJump = true;
                time = 0;
            }
        }
        

        Vector3 pos = transform.position;
        pos.x += move * sideSpeed * Time.deltaTime;
        transform.position = pos;

        if (StatusController.getSpeed() > 70)
        {
            canJump = false;
        }
        else canJump = true;

        if (isJump)
        {
            pos = transform.position;
            pos.y = animation.Evaluate(time) * 4;
            time += Time.deltaTime;
            transform.position = pos;
            if (time > animation.keys[animation.length - 1].time)
            {
                isJump = false;
            }
        }
        PoisonPos();
        /*pos = map.transform.position;
        pos.z += movementSpeed * Time.deltaTime;
        map.transform.position = pos;
        */

    }
    public void PoisonPos()
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-StatusController.getPoisoning(), StatusController.getPoisoning()) * movementSpeed * Time.deltaTime;
        transform.position = pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }


}
