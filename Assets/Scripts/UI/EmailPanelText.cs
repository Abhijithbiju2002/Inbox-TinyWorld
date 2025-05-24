using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailPanelText : MonoBehaviour
{
    [SerializeField] EmailData emailData;
    [SerializeField] TextMeshProUGUI senderText;
    [SerializeField] TextMeshProUGUI subjectText;
    [SerializeField] TextMeshProUGUI senderMailId;
    [SerializeField] TextMeshProUGUI senderMessage;
    [SerializeField] Button deleteButton;
    [SerializeField] Button confrim_button;

    [SerializeField] GameObject linkedEmailCard;
    private EmailInboxManager inboxManager;

    public void Initialize(EmailInboxManager manager, GameObject card)
    {
        inboxManager = manager;
        linkedEmailCard = card;

        deleteButton.onClick.AddListener(DeletePage);
        confrim_button.onClick.AddListener(ConfrimButton);
    }

    public void ShowEmail(EmailData data)
    {
        emailData = data;

        senderText.text = data.GetSender();
        subjectText.text = data.GetSubject();
        senderMailId.text = data.GetSenderMailId();
        senderMessage.text = data.GetMessage();
        linkedEmailCard = null;
        gameObject.SetActive(true);
    }
    public void closepanel()
    {
        gameObject.SetActive(false);
    }
    public void DeletePage()
    {
        closepanel();

        if (linkedEmailCard != null)
        {
            Destroy(linkedEmailCard);

        }
        if (inboxManager != null)
        {
            inboxManager.OnEmailDeleted();

        }

    }
    void ConfrimButton()
    {
        //after pressing confrim button ...
        //good or bad may happen acccording to the category

    }
    public void ResetLinkedCardVisual()
    {
        if (linkedEmailCard != null)
        {
            EmailCardUI cardUI = linkedEmailCard.GetComponent<EmailCardUI>();
            if (cardUI != null)
            {
                cardUI.ResetVisual();
            }
        }
    }
}
