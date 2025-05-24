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

    [SerializeField] EmailPanelText emailPanel;
    [SerializeField] EmailInboxManager inboxManager;

    bool isOpened = false;

    //[SerializeField] Button EmailButton;


    public void Setup(EmailData data)
    {
        emailData = data;

        senderText.text = emailData.GetSender();
        subjectText.text = emailData.GetSubject();
        isOpened = false;

        UpdateVisual();

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (contentRoot != null)
        {
            contentRoot.SetActive(false);
        }
        OpenEmail();

    }
    void OpenEmail()
    {
        isOpened = true;
        if (emailPanel != null)
        {
            emailPanel.ShowEmail(emailData);
            emailPanel.Initialize(inboxManager, gameObject); // Link back to this card
        }
        UpdateVisual();

    }
    void UpdateVisual()
    {
        if (button != null)
        {
            button.color = isOpened ? new Color(0.65f, 0.65f, 0.65f) : Color.white;
        }
    }
    public void ResetVisual()
    {
        isOpened = false;
        UpdateVisual();
    }
    //public void OnClickOpenEmail()
    //{
    //     emailPanel.ShowEmail(emailData);                  // Show the data
    //    emailPanel.Initialize(inboxManager, gameObject);  // Set manager and THIS card as linked
    //}




}


