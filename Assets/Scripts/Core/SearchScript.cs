using TMPro;
using UnityEngine;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject[] Elemenets;
    public GameObject SearchBar;

    public int totalElement;

    // Start is called before the first frame update
    void Start()
    {
        totalElement = ContentHolder.transform.childCount;

        Elemenets = new GameObject[totalElement];

        for (int i = 0; i < totalElement; i++)
        {
            Elemenets[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
    }
    public void Search()
    {
        string searchText = SearchBar.GetComponent<TMP_InputField>().text;
        int searchLength = searchText.Length;

        int searchElement = 0;

        foreach (GameObject ele in Elemenets)
        {
            searchElement += 1;

            if (ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length >= searchLength)
            {
                if (searchText == ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0, searchLength).ToLower())
                {
                    ele.SetActive(true);
                }
                else
                {
                    ele.SetActive(false);
                }
            }
        }
    }


}
