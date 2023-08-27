using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenu : MonoBehaviour
{
    protected GameObject MainMenuObject;

    public void SetMainMenuObject(GameObject Menu)
    {
        MainMenuObject = Menu;
    }
}
