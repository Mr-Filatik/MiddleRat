using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RatController : MonoBehaviour
{
    public float move = 0;
    public bool canJump = true;
    public bool isJump = false;
    public bool isFinish = false;
    public float sideSpeed = 0.01f;
    public float movementSpeed = 1;
    public float time = 0;
    public AnimationCurve animation = null;
    public GameObject map;
    public StatusController status;
    [SerializeField] private TMP_Text moveSpeedText;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
           
        moveController();
        if (isJump)
        {
            anim.SetBool("isJumping", true); 
        } else anim.SetBool("isJumping", false);
    }
    public void moveController()
    {
        movementSpeed = StatusController.getSpeed();
        if (movementSpeed == 0) sideSpeed = 0;
        if (StatusController.getEat() > 70)
        {
            canJump = false;
        }
        else canJump = true;

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
        
        Vector3 prevPos = transform.position;
        Vector3 pos = transform.position;
        pos.x += move * sideSpeed * Time.deltaTime;

        if (pos.x < -8|| pos.x > 8)     //side restriction
        {
            pos.x = prevPos.x;
        }
        transform.position = pos;



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

        pos = map.transform.position;
        pos.z -= movementSpeed * Time.deltaTime;
        map.transform.position = pos;

        moveSpeedText.text = movementSpeed.ToString();
    }
    public void PoisonPos()
    {
        Vector3 prevPos = transform.position;
        Vector3 pos = transform.position;
        
        pos.x += Random.Range(-StatusController.getPoisoning(), StatusController.getPoisoning()) * Time.deltaTime * 1.5f;
        if (pos.x < -1.9 || pos.x > 2.9)
        {
            pos.x = prevPos.x;
        }
        transform.position = pos;
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            status.isFinish = true;
        } 
        if(other.tag == "Poison")
        {
            status.Poisoning(1);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "NotPoison")
        {
            status.Poisoning(-1);
            other.gameObject.SetActive(false);
        }
        if (other.tag == "Food")
        {
            status.Eating(20);
            other.gameObject.SetActive(false);
        }
        if(other.tag == "Obstacle")
        {
            status.isAlive = false;
            anim.SetBool("isCrash", true);
        }
    }


}
