using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RingElement", menuName = "RingMenu/Element", order = 2)]
public class RingElement : ScriptableObject
{
    public string Name;
    public Sprite Icon;

    public string Text;

    //public Ring NextRing;
    public void start()
    {
        Debug.Log(Text);
    }

}
