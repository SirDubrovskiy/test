using UnityEngine;
using UnityEngine.UI;

public class MapLocButtonsReaction : MonoBehaviour
{
    [SerializeField] Image loc_logo;
    [SerializeField] Color defaultColor;
    [SerializeField] Color hoveredColor;


    private void Start()
    {
        loc_logo = GetComponent<Image>();
    }


    public void Hovered(bool hovered)
    {
        loc_logo.color = hovered == true ? hoveredColor : defaultColor;
    }

    
}
