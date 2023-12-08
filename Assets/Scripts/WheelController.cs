using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{

    public int Id;
    private Animator ani;
    public string itemName;
    // public TextMeshProGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;


    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (selected)
        {
            selectedItem.sprite = icon;
            // itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
        UiWheelController.statusID = Id;
    }

    public void DeSelected()
    {
        selected = false;
        UiWheelController.statusID = 0;
    }

    public void HoverEnter()
    {
        ani.SetBool("Hover", true);
        // itemText.text = itemName;
    }

    public void HoverExit()
    {
        ani.SetBool("Hover", false);
        // itemText.text = "";
    }
}
