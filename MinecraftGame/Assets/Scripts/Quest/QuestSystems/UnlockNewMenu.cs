using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockNewMenu : MonoBehaviour
{
    [SerializeField] Button _menuToUnlock;

    public void Unlock()
    {
        _menuToUnlock.interactable = true;
    }
}
