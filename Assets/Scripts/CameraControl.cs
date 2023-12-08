using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Rigidbody holdObjRB;
    Rigidbody RBG;

    public GameObject player;

    void Start()
    {
        RBG = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CameraLock()
    {
        // Freeze the camera rotation.
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        RBG.constraints = RigidbodyConstraints.FreezeRotationX; // Fixed camera 
    }
}
