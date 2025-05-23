using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EmailCardUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] EmailData emailData;
    [SerializeField] TextMeshProUGUI senderText;
    [SerializeField] TextMeshProUGUI subjectText;
    [SerializeField] EmailPanelText EmailPanelText;
    [SerializeField] GameObject contentRoot;
    [SerializeField] Image button;

    bool isOpened = false;

    //[SerializeField] Button EmailButton;


    public void Setup(EmailData data)
    {
        data = emailData;

        senderText.text = emailData.GetSender();
        subjectText.text = emailData.GetSubject();
        isOpened = false;




    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (contentRoot != null)
        {
            contentRoot.SetActive(false);
        }
        if (EmailPanelText != null)
        {
            EmailPanelText.ShowEmail(emailData);
            OpenEmail();

        }

    }
    void OpenEmail()
    {
        isOpened = true;
        UpdateVisual();

    }
    void UpdateVisual()
    {
        if (button != null)
        {
            button.color = isOpened ? new Color(0.65f, 0.65f, 0.65f) : Color.white;
        }
    }




}


