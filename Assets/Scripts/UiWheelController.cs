using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiWheelController : MonoBehaviour
{
    public Animator ani;
    public bool uiWheelSelected = false;
    public Image selectedAction;
    public Sprite noImage;
    public static int statusID;

    [Header("Player Information")]
    public GameObject player;
    //public GameObject companionScript;
    public CompanionScript companionScript;
    public void Start()
    {

    }

    void Update()
    {
        if (uiWheelSelected)
        {
            ani.SetBool("OpenUiWheel", true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

            //player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
        else
        {
            ani.SetBool("OpenUiWheel", false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


            player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        }


        // Call for function here;
        switch (statusID)
        {
            case 0: // nothing is selected
                selectedAction.sprite = noImage;
                break;
            case 1: // Follow
                Debug.Log("Case Follow");
                companionScript.state = CompanionScript.State.follow;
                break;
            case 2: // Stop
                Debug.Log("Case Stop");
                companionScript.state = CompanionScript.State.idle;
                break;
            case 3: // Go to
                Debug.Log("Case going");
                companionScript.state = CompanionScript.State.going;
                break;
            case 4: // Interact
                Debug.Log("Case Talk that talk");
                companionScript.state = CompanionScript.State.talking;
                break;
        }
    }
}
