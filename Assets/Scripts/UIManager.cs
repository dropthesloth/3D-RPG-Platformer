using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    public void Menu()
    {
        menu.SetActive(true);
    }
}
