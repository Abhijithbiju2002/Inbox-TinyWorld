using UnityEngine;

[CreateAssetMenu(fileName = "Email Deatils", menuName = "Emails/Office Mail")]
public class EmailData : ScriptableObject
{
    [SerializeField] string sender;
    [SerializeField] string sender_mailID;
    [SerializeField] string subject;

    [TextArea(3, 10)]
    [SerializeField] string message = "Enter Mail Message here";

    public EmailRisk risk_level;
    public CategoryEmail category;

    public int moneyEffect;
    public int moralEffect;
    public bool cointansVirus;

    public string GetMessage()
    {
        return message;
    }
    public string GetSender()
    {
        return sender;
    }
    public string GetSenderMailId()
    {
        return sender_mailID;
    }
    public string GetSubject()
    {
        return subject;
    }

    public int GetMoneyEffect()
    {
        return moneyEffect;
    }
    public int GetMoralEffect()
    {
        return moralEffect;
    }
}
