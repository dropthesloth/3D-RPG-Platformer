using System.Collections;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField]TextMeshProUGUI inputText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CloseMenu(string choice)
    {
        inputText.gameObject.SetActive(true);
        StartCoroutine(ShowChoiceInput(choice));
    }
    IEnumerator ShowChoiceInput(string choice)
    {
        if (choice == "Flame Dash")
            inputText.text = "Press E to use Flame Dash";
        else if (choice == "Wind Jump")
            inputText.text = "Press Q to use WindJump";
        menu.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        inputText.gameObject.SetActive(false);
    }
}
