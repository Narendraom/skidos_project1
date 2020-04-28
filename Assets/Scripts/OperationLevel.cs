using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OperationLevel : MonoBehaviour
{
    [SerializeField]
    GameObject levelButtonPrefab;

    [SerializeField]
    GameObject dropdownPrefab;

    [SerializeField]
    Transform contentParent;

    [SerializeField]
    Text titleText;

    private Item[][] selectedData;


    private GameObject subtopicDropdown;

    private Transform lastButton=null;


    private void OnEnable()
    {
        if (contentParent.childCount > 0)
        {
            for (int i = contentParent.childCount - 1; i >= 0; i--)
            {
                Destroy(contentParent.GetChild(i).gameObject);
            }
        }
        titleText.text = DataHelper.operationsTitle[GameManager.Instance.operationId - 1];
        FillData();
        lastButton = null;
    }

    void FillData()
    {
        switch(GameManager.Instance.operationId)
        {
            case 1://Addition
                {
                    selectedData = GameManager.Instance.creatorData[0].Addition.data;
                    break;
                }
            case 2://Geometry
                {
                    selectedData = GameManager.Instance.creatorData[0].Geometry.data;
                    break;
                }
            case 3://MixedOperations
                {
                    selectedData = GameManager.Instance.creatorData[0].MixedOperations.data;
                    break;
                }
            case 4://Numbersense
                {
                    selectedData = GameManager.Instance.creatorData[0].Numbersense.data;
                    break;
                }
            case 5://Subtraction
                {
                    selectedData = GameManager.Instance.creatorData[0].Subtraction.data;
                    break;
                }
        }
        for(int i=0;i<selectedData.Length;i++)
        {
            GameObject levelbutton = Instantiate(levelButtonPrefab, contentParent);
            levelbutton.GetComponent<LevelButton>().title.text = "Level " + (i + 1);
            int index = i;
            levelbutton.GetComponent<Button>().onClick.AddListener(() => LevelButtonClicked(index, levelbutton.transform));
        }
        subtopicDropdown = Instantiate(dropdownPrefab, contentParent);
        subtopicDropdown.SetActive(false);
    }

    void LevelButtonClicked(int index, Transform levelButtons)
    {
        if (subtopicDropdown.activeSelf && lastButton==levelButtons)
        {
            subtopicDropdown.SetActive(false);
            lastButton.GetChild(2).gameObject.SetActive(false);
            lastButton.GetChild(1).gameObject.SetActive(true);
            lastButton = null;
            return;
        }
        else if(subtopicDropdown.activeSelf)
        {
            lastButton.GetChild(2).gameObject.SetActive(false);
            lastButton.GetChild(1).gameObject.SetActive(true);
        }
        subtopicDropdown.transform.SetAsLastSibling();
        lastButton = levelButtons;
        lastButton.GetChild(2).gameObject.SetActive(true);
        lastButton.GetChild(1).gameObject.SetActive(false);

        List<string> options = new List<string>();
        foreach (var option in selectedData[index])
        {
            options.Add(option.subtopic_name);
        }
        subtopicDropdown.GetComponent<Dropdown>().Hide();
        subtopicDropdown.GetComponent<Dropdown>().ClearOptions();
        subtopicDropdown.GetComponent<Dropdown>().AddOptions(options);
        subtopicDropdown.GetComponent<Dropdown>().value = 0;
        int childIndex = levelButtons.GetSiblingIndex();
        subtopicDropdown.transform.SetSiblingIndex(childIndex + 1);
        subtopicDropdown.SetActive(true);
    }
}
