using TMPro;
using UnityEngine;

public class EmailCardUI : MonoBehaviour
{
    [SerializeField] EmailData emailData;
    [SerializeField] TextMeshProUGUI senderText;
    [SerializeField] TextMeshProUGUI subjectText;

    private void Start()
    {
        senderText.text = emailData.GetSender();
        subjectText.text = emailData.GetSubject();
    }

}
