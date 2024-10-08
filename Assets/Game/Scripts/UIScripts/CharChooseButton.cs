using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharChooseButton : MonoBehaviour
{
    // Very basic code for UI
    public static CharChooseButton Instance { get; private set; } 

    [NonSerialized] public bool isLevisSelected = false;

    [SerializeField] private GameObject levisBorder;
    [SerializeField] private GameObject levisInfoPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            levisBorder.SetActive(false);
        }
    }
    public void LevisSelected()
    {
        isLevisSelected = true;
        levisBorder.SetActive(true);        
    }
    public void OnEnterLevisInfoPanel()
    {
        levisInfoPanel.SetActive(true);
    }
    public void OnExitLevisInfoPanel()
    {
        levisInfoPanel.SetActive(false);
    }

}
