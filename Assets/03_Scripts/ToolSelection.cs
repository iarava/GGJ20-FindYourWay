using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolSelection : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI amoutAxeText;
    [SerializeField] private TextMeshProUGUI amoutPickText;
    [SerializeField] private TextMeshProUGUI amoutRampText;
    [SerializeField] private TextMeshProUGUI amoutBridgeText;

    private int currentAmountAxe;
    private int currentAmountPick;
    private int currentAmountRamp;
    private int currentAmountBridge;

    private GameManager manager;

    private void Awake()
    {
        manager = GameManager.Instance;
        
        manager.OnAmountChangeAxe += HandleChangeAxe;
        manager.OnAmountChangePick += HandleChangePick;
        manager.OnAmountChangeRamp += HandleChangeRamp;
        manager.OnAmountChangeBridge += HandleChangeBrigde;
    }

    private void HandleChangeAxe(int amount)
    {
        amoutAxeText.text = amount.ToString();
    }

    private void HandleChangePick(int amount)
    {
        amoutPickText.text = amount.ToString();
    }
    
    private void HandleChangeRamp(int amount)
    {
        amoutRampText.text = amount.ToString();
    }

    private void HandleChangeBrigde(int amount)
    {
        amoutBridgeText.text = amount.ToString();
    }

    private void OnDestroy()
    {
        manager.OnAmountChangeAxe -= HandleChangeAxe;
        manager.OnAmountChangePick -= HandleChangePick;
        manager.OnAmountChangeRamp -= HandleChangeRamp;
        manager.OnAmountChangeBridge -= HandleChangeBrigde;
    }
}
