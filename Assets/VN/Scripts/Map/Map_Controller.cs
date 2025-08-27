using UnityEngine;
using UnityEngine.UI;

public class Map_Controller : MonoBehaviour
{
    [SerializeField] GameObject mapButton;
    [SerializeField] GameObject mapUI;
    public static Map_Controller Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void ToggleMapButton(string map)
    {
        switch (map)
        {
            case "Off":
                mapButton.SetActive(false);
                mapUI.SetActive(false);
                break;
            
            case "On":
                mapButton.SetActive(true);
                break;
        }
    }
    public void LockLocation(string location, bool isLocked)
    {
        Transform newMapLocation = mapUI.transform.Find(location);
        Button newLocationButton = newMapLocation.GetComponent<Button>();
        Image newLocationImage = newMapLocation.GetComponent<Image>();
        
        newLocationButton.interactable = isLocked;
        newLocationImage.color = isLocked 
            ? new Color(0.5f, 0.5f, 0.5f, 1f)
            : new Color(1f, 1f, 1f, 1f);
    }
    public void ShowMapUI() 
    {
        mapUI.SetActive(!mapUI.activeInHierarchy);
    }
}
