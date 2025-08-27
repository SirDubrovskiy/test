using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{

    [SerializeField] private GameObject notificationSlotPrefab;
    [SerializeField] private RectTransform notificationPanel;
    [SerializeField] private SO_Notification notificationSo;

    public static NotificationController Instance { get; private set; }
    
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
    
    public void AddNotification(int nID)
    {
        GameObject newNotification = Instantiate(notificationSlotPrefab ,notificationPanel);
        TextMeshProUGUI newTextNotification = newNotification.GetComponent<TextMeshProUGUI>();
        newTextNotification.text = notificationSo.nArray[nID];
    }
}
