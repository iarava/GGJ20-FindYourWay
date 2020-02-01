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

    private void Start()
    {
        manager = GameManager.Instance;
        
        manager.OnAmountChangeAxe += HandleChangeAxe;
        manager.OnAmountChangePick += HandleChangePick;
        manager.OnAmountChangeRamp += HandleChangeRamp;
        manager.OnAmountChangeBridge += HandleChangeBrigde;
        
        amoutAxeText.text = manager.AmountAxe.ToString();
        amoutPickText.text = manager.AmountPick.ToString();
        amoutRampText.text = manager.AmountRamp.ToString();
        amoutBridgeText.text = manager.AmountBridge.ToString();
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
    
    public void OnSelectionAxe()
    {
        GameManager.Instance.OnSelectionAxe();
    }
    
    public void OnSelectionPick()
    {
        GameManager.Instance.OnSelectionPick();
    }
    
    public void OnSelectionRamp()
    {
        GameManager.Instance.OnSelectionRamp();
    }
    
    public void OnSelectionBridge()
    {
        GameManager.Instance.OnSelectionBridge();
    }

    private void OnDestroy()
    {
        manager.OnAmountChangeAxe -= HandleChangeAxe;
        manager.OnAmountChangePick -= HandleChangePick;
        manager.OnAmountChangeRamp -= HandleChangeRamp;
        manager.OnAmountChangeBridge -= HandleChangeBrigde;
    }
}
