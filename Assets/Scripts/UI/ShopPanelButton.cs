using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelButton : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    private bool isOpened = false;
    public void ProcessButton()
    {

        Debug.Log(isOpened);
        if(isOpened)
        {
            isOpened = false;
            Panel.GetComponent<Animator>().SetTrigger("Close");
        }
        else
        {
            isOpened = true;
            Panel.GetComponent<Animator>().SetTrigger("Open");
        }
        
    }
}
