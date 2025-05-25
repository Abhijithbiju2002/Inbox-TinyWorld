using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailInboxManager : MonoBehaviour
{
    [SerializeField] List<EmailData> EmailList;
    [SerializeField] Transform inboxContentPanel;

    [SerializeField] GameObject Officebutton;
    [SerializeField] GameObject spamEmailPrefab;
    [SerializeField] GameObject scamEmailPrefab;
    [SerializeField] GameObject lotterymailPrefab;
    [SerializeField] GameObject incomeEmailPrefab;
    [SerializeField] GameObject VirusEmailPrefab;
    [SerializeField] GameObject defaultprefab;

    [SerializeField] int maxCountInbox = 12;
    private int remainingToSpawn;

    [SerializeField] private EmailPanelText workPanel;
    [SerializeField] private EmailPanelText scamPanel;
    [SerializeField] private EmailPanelText spamPanel;
    [SerializeField] private EmailPanelText salaryPanel;
    [SerializeField] private EmailPanelText lotteryPanel;
    [SerializeField] private EmailPanelText virusPanel;

    private void Start()
    {
        while (EmailList.Count < maxCountInbox)
        {
            EmailList.Add(EmailList[0]); // Duplicate first entry
        }
        GenerateInbox();
    }
    private GameObject GetPrfabForCategory(CategoryEmail category)
    {
        switch (category)
        {
            case CategoryEmail.Work: return Officebutton;
            case CategoryEmail.Spam: return spamEmailPrefab;
            case CategoryEmail.Scam: return scamEmailPrefab;
            case CategoryEmail.Lottrey: return lotterymailPrefab;
            case CategoryEmail.Salary: return incomeEmailPrefab;
            case CategoryEmail.Virus: return VirusEmailPrefab;

            default: return defaultprefab;
        }

    }
    private EmailPanelText GetPanelForCategory(CategoryEmail category)
    {
        switch (category)
        {
            case CategoryEmail.Work: return workPanel;
            case CategoryEmail.Spam: return spamPanel;
            case CategoryEmail.Scam: return scamPanel;
            case CategoryEmail.Lottrey: return lotteryPanel;
            case CategoryEmail.Salary: return salaryPanel;
            case CategoryEmail.Virus: return virusPanel;
            default: return null;
        }

    }
    void GenerateInbox()
    {
        int existingEmails = inboxContentPanel.childCount;
        int remainingToSpawn = maxCountInbox - existingEmails;

        if (remainingToSpawn <= 0 || EmailList.Count == 0) return;

        List<EmailData> shuffledList = new List<EmailData>(EmailList);
        for (int i = 0; i < shuffledList.Count; i++)
        {
            int rand = Random.Range(i, shuffledList.Count);
            (shuffledList[i], shuffledList[rand]) = (shuffledList[rand], shuffledList[i]);
        }


        int count = Mathf.Min(remainingToSpawn, EmailList.Count);


        for (int i = 0; i < count; i++)
        {
            SpawnEmailCard(shuffledList[i]);
        }
    }
    void SpawnEmailCard(EmailData Data)
    {
        GameObject prefab = GetPrfabForCategory(Data.category);
        GameObject card = Instantiate(prefab, inboxContentPanel);

        EmailCardUI emailCardUI = card.GetComponent<EmailCardUI>();
        if (emailCardUI != null)
        {
            EmailPanelText targetPanel = GetPanelForCategory(Data.category);
            emailCardUI.Setup(Data, this, targetPanel);
        }
    }
    public void OnEmailDeleted()
    {

        StartCoroutine(SpawnNewEmailWithDelay(5f));
    }
    IEnumerator SpawnNewEmailWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        while (inboxContentPanel.childCount < maxCountInbox && EmailList.Count > 0)
        {
            SpawnOneRandomEmail();
            yield return new WaitForSeconds(0.1f); // Slight delay between spawns (optional)
        }
    }
    void SpawnOneRandomEmail()
    {
        Debug.Log("Inbox Count: " + inboxContentPanel.childCount);
        if (inboxContentPanel.childCount >= maxCountInbox || EmailList.Count == 0) return;

        EmailData randomEmail = EmailList[Random.Range(0, EmailList.Count)];
        SpawnEmailCard(randomEmail);
    }
}
