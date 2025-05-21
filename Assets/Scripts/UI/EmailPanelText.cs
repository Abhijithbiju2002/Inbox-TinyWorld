using TMPro;
using UnityEngine;

public class EmailPanelText : MonoBehaviour
{
    [SerializeField] EmailData emailData;
    [SerializeField] TextMeshProUGUI senderText;
    [SerializeField] TextMeshProUGUI subjectText;
    [SerializeField] TextMeshProUGUI senderMailId;
    [SerializeField] TextMeshProUGUI senderMessage;

    void Start()
    {
        senderText.text = emailData.GetSender();
        subjectText.text = emailData.GetSubject();
        senderMailId.text = emailData.GetSenderMailId();
        senderMessage.text = emailData.GetMessage();
    }


}
