using UnityEngine;
using UnityEngine.UI;

public class MG_Memory_Card : MonoBehaviour
{
    [SerializeField] private Image CardImage;
    
    public Sprite CardSprite;
    public Sprite hidderCardSprite;
    
    public MG_Memory_CardController cardController;

    public bool isSelected;


    public void OnCardClicked()
    {
        cardController.SelectCard(this);
    }
    public void SetCardImage(Sprite Sprite)
    {
        CardSprite = Sprite;
    }

    public void ShowCard()
    {
        CardImage.sprite = CardSprite;
        isSelected = true;
    }

    public void HideCard()
    {
        CardImage.sprite = hidderCardSprite;
        isSelected = false;
    }
    
}
