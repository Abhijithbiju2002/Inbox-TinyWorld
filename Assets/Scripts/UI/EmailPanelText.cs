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


    public void ShowEmail(EmailData data)
    {
        emailData = data;

        senderText.text = data.GetSender();
        subjectText.text = data.GetSubject();
        senderMailId.text = data.GetSenderMailId();
        senderMessage.text = data.GetMessage();
        gameObject.SetActive(true);
    }
    public void closepanel()
    {
        gameObject.SetActive(false);
    }
    void DeletePage()
    {
        //click button to delete the Emailpanel
        Destroy(gameObject);
    }
    void ConfrimButton()
    {
        //after pressing confrim button ...
        //good or bad may happen acccording to the category

    }
}
