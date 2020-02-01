using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelection : MonoBehaviour
{
    [SerializeField] private GameObject prefabAxe;
    [SerializeField] private GameObject prefabPick;
    [SerializeField] private GameObject prefabRamp;
    [SerializeField] private GameObject prefabBridge;
    
    public void OnSelectionAxe()
    {
        Instantiate(prefabAxe);
    }
    
    public void OnSelectionPick()
    {
        Instantiate(prefabPick);
    }
    
    public void OnSelectionRamp()
    {
        Instantiate(prefabRamp);
    }
    
    public void OnSelectionBridge()
    {
        Instantiate(prefabBridge);
    }
}
