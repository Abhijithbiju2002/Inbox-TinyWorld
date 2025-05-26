using TMPro;
using UnityEngine;


public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    public int morale = 100;
    public int money = 500;



    [SerializeField] private TextMeshProUGUI moraleText;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        UpdateUI();
    }
    public void AddMorale(int value)
    {
        morale += value;
        if (morale >= 100)
        {
            morale = 100;
        }
        UpdateUI();
        FindAnyObjectByType<GameOverManager>().CheckGmeOver(morale, money);
    }
    public void AddMoney(int value)
    {
        money += value;
        UpdateUI();
        FindAnyObjectByType<GameOverManager>().CheckGmeOver(morale, money);
    }

    private void UpdateUI()
    {
        moraleText.text = "MORALE: " + morale;
        moneyText.text = "MONEY: $" + money;
    }
}
