using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class CompanionScript : MonoBehaviour
{

    [Header("AI Companion")]
    public NavMeshAgent ai;
    public Transform player;
    public Animator companionAni;
    Vector3 dest;
    Vector3 local;

    public enum State
    {
        follow,
        idle,
        going,
        talking
    }

    public State state;


    [Header("Crosshair")]
    public Image crossHair;
    public Sprite onLookUI;

    [Header("UI Menu")]
    public UiWheelController uiWheelController;
    public static int statusID;

    [Header("Audio")]
    //public AudioSource audioData;
    public AudioSource whistle;

    //public ControllerMode Mode;
    public Transform goal;

    public void Start()
    {
        //SetMode(ControllerMode.Play);
        state = State.idle;

    }

    void Update()
    {

        /*
         Animation
        if (!ai.pathPending)
        {
            if(ai.remainingDistance <= ai.stoppingDistance)
            {
                companionAni.ResetTrigger("walk");
                companionAni.SetTrigger("idle");
            }
        }
        else
        {
            companionAni.ResetTrigger("idle");
            companionAni.SetTrigger("walk");
        }

        if (Mode == ControllerMode.Menu)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetMode(ControllerMode.Play);
                Debug.Log(Mode);

            }

            
        }
        */
        if (Input.GetKeyDown("f"))
        {
            whistle.Play();
            dest = player.position;
            ai.destination = dest;
            Debug.Log("Following");


        }



        switch(state)
        {
            // Follow player
            case State.follow:
                dest = player.position;
                ai.destination = dest;
                Debug.Log("Following");
                break;

            // Idle
            case State.idle:
                Debug.Log("Idling");
                break;

            // Going to location
            case State.going:
                //ai.SetDestination(goal.position);
                local = goal.position;
                ai.destination = local;
                Debug.Log("Going");
                break;

            // Talking audio
            case State.talking:
                //audioData.Play();
                Debug.Log("Talking");
                break;
        }
    }

    // Menu on companion
    public void OnMouseOver()
    {
        crossHair.sprite = onLookUI;
        crossHair.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //UiWheelController.
            uiWheelController.uiWheelSelected = !uiWheelController.uiWheelSelected;
            //UiSwitch = true;
        }

    }

    public void OnMouseExit()
    {
        crossHair.sprite = onLookUI;
        crossHair.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    }
}
