using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [SerializeField] private GameObject prefabAxe;
    [SerializeField] private GameObject prefabPick;
    [SerializeField] private GameObject prefabRamp;
    [SerializeField] private GameObject prefabBridge;
    
    public event Action<int> OnAmountChangeAxe = delegate { };
    public event Action<int> OnAmountChangePick = delegate { };
    public event Action<int> OnAmountChangeRamp = delegate { };
    public event Action<int> OnAmountChangeBridge = delegate { };

    public int AmountAxe { get; private set; }
    public int AmountPick { get; private set; }
    public int AmountRamp { get; private set; }
    public int AmountBridge { get; private set; }

    private bool isSnapped = false;

    private GameObject selectedTool = null;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        LevelManager.Instance.NewLevelReady += LoadNewLevel;
    }

    private void LoadNewLevel(int axes, int picks, int ramps, int bridges)
    {
        setAmountAxe(axes);
        setAmountPick(picks);
        setAmountRamp(ramps);
        setAmountBridge(bridges);
    }

    private void setAmountAxe(int amount)
    {
        AmountAxe = amount;
        OnAmountChangeAxe(amount);
    }
    
    private void setAmountPick(int amount)
    {
        AmountPick = amount;
        OnAmountChangePick(amount);
    }
    
    private void setAmountRamp(int amount)
    {
        AmountRamp = amount;
        OnAmountChangeRamp(amount);
    }
    
    private void setAmountBridge(int amount)
    {
        AmountBridge = amount;
        OnAmountChangeBridge(amount);
    }
    
    public void OnSelectionAxe()
    {
        if (AmountAxe <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabAxe);
        isSnapped = false;    
    }
    
    public void OnSelectionPick()
    {
        if (AmountPick <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabPick);
        isSnapped = false;
    }
    
    public void OnSelectionRamp()
    {
        if (AmountRamp <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabRamp);
        isSnapped = false;  
    }
    
    public void OnSelectionBridge()
    {
        if (AmountBridge <= 0) return;
            
        if(selectedTool != null & !isSnapped)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabBridge);
        isSnapped = false;  
    }

    public void UpdateAmountAxe()
    {
        setAmountAxe(AmountAxe-1);
    }
    
    public void UpdateAmountPick()
    {
        setAmountPick(AmountPick-1);
    }
    
    public void UpdateAmountRamp()
    {
        isSnapped = true;
        setAmountRamp(AmountRamp-1);
    }
    
    public void UpdateAmountBrdige()
    {
        isSnapped = true;
        setAmountBridge(AmountBridge-1);
    }
}
