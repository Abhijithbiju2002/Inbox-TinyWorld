using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EmailCardUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] EmailData emailData;
    [SerializeField] TextMeshProUGUI senderText;
    [SerializeField] TextMeshProUGUI subjectText;
    [SerializeField] EmailPanelText EmailPanelText;
    [SerializeField] GameObject contentRoot;
    //[SerializeField] Button EmailButton;


    public void Setup(EmailData data)
    {
        emailData = data;



        senderText.text = data.GetSender();
        subjectText.text = data.GetSubject();


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
        }

    }




}


