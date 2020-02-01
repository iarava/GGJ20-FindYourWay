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

    private int amountAxe;
    private int amountPick;
    private int amountRamp;
    private int amountBridge;

    private GameObject selectedTool = null;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadNewLevel();
    }

    public void LoadNewLevel()
    {
        setAmountAxe(2);
        setAmountPick(1);
        setAmountRamp(0);
        setAmountBridge(0);
    }

    private void setAmountAxe(int amount)
    {
        amountAxe = amount;
        OnAmountChangeAxe(amount);
    }
    
    private void setAmountPick(int amount)
    {
        amountPick = amount;
        OnAmountChangePick(amount);
    }
    
    private void setAmountRamp(int amount)
    {
        amountRamp = amount;
        OnAmountChangeRamp(amount);
    }
    
    private void setAmountBridge(int amount)
    {
        amountBridge = amount;
        OnAmountChangeBridge(amount);
    }
    
    public void OnSelectionAxe()
    {
        if (amountAxe <= 0) return;
            
        if(selectedTool != null)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabAxe);
            
    }
    
    public void OnSelectionPick()
    {
        if (amountPick <= 0) return;
            
        if(selectedTool != null)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabPick);
    }
    
    public void OnSelectionRamp()
    {
        if (amountRamp <= 0) return;
            
        if(selectedTool != null)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabRamp);
    }
    
    public void OnSelectionBridge()
    {
        if (amountBridge <= 0) return;
            
        if(selectedTool != null)
            Destroy(selectedTool);
        
        selectedTool = Instantiate(prefabBridge);
    }

    public void UpdateAmountAxe()
    {
        setAmountAxe(amountAxe-1);
    }
    
    public void UpdateAmountPick()
    {
        setAmountPick(amountPick-1);
    }
    
    public void UpdateAmountRamp()
    {
        setAmountRamp(amountRamp-1);
    }
    
    public void UpdateAmountBrdige()
    {
        setAmountBridge(amountBridge-1);
    }
}
