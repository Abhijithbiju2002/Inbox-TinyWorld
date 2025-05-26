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

    [SerializeField] GameObject miniRewardPanel;
    [SerializeField] TextMeshProUGUI miniRewardText;

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
        AudioManager.Instance.PlayClick();// WILL CHANGE IN FUTURE
        gameObject.SetActive(false);
    }
    public void DeletePage()
    {
        AudioManager.Instance.PlayDeleteSound();// WILL CHANGE IN FUTURE
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
    public void ConfrimButton()
    {
        switch (emailData.category)
        {
            case CategoryEmail.Salary:
                GameManger.Instance.AddMoney(200);
                GameManger.Instance.AddMorale(10);
                showMiniPanel("You received $200 and Morale!");
                AudioManager.Instance.PlayGoodSound();// WILL CHANGE IN FUTURE
                break;

            case CategoryEmail.Work:
                GameManger.Instance.AddMorale(10);
                showMiniPanel("Morale increased!");
                AudioManager.Instance.PlayGoodSound();// WILL CHANGE IN FUTURE// WILL CHANGE IN FUTURE

                break;

            case CategoryEmail.Virus:
                GameManger.Instance.AddMoney(-100);
                GameManger.Instance.AddMorale(-15);
                showMiniPanel("You lost $100 and Morale!");
                AudioManager.Instance.PlayBadSound();// WILL CHANGE IN FUTURE
                break;

            case CategoryEmail.Scam:
                GameManger.Instance.AddMoney(-200);
                GameManger.Instance.AddMorale(-15);
                showMiniPanel("scammed! Lost $200 and Morale");
                AudioManager.Instance.PlayBadSound();// WILL CHANGE IN FUTURE
                break;

            case CategoryEmail.Lottrey:
                GameManger.Instance.AddMoney(500);
                GameManger.Instance.AddMorale(15);
                showMiniPanel("You won $500 and Morale!");
                AudioManager.Instance.PlayGoodSound();// WILL CHANGE IN FUTURE
                break;

            case CategoryEmail.Spam:
                GameManger.Instance.AddMorale(-5);
                showMiniPanel("Spam! Morale Dropped");
                AudioManager.Instance.PlayBadSound();// WILL CHANGE IN FUTURE
                break;

        }
        AudioManager.Instance.PlayClick();// WILL CHANGE IN FUTURE
        closepanel();

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
    void showMiniPanel(string message)
    {
        miniRewardText.text = message;
        miniRewardPanel.SetActive(true);
        Invoke(nameof(HideMiniPanel), 2f);

    }
    void HideMiniPanel()
    {
        miniRewardPanel.SetActive(false);
    }
}
