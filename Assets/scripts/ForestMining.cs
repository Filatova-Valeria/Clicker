using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ForestMining : MonoBehaviour
{
    public LootTable lootTable;
    public TMP_Text feedbackText;
    public float feedbackTime;

    private int axeLevel = 0;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnDisable()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        string resourceId = lootTable.GetRandomItem();
        int count = 1 + axeLevel;
        GameManager.Instance.AddItem(resourceId, count);
        ShowFeedback($"+{count} {GetResourceName(resourceId)}");
    }

    void ShowFeedback(string text)
    {
        feedbackText.text = text;
        feedbackText.gameObject.SetActive(true);
        CancelInvoke(nameof(HideFeedback));
        Invoke(nameof(HideFeedback), feedbackTime);
    }

    void HideFeedback()
    {
        feedbackText.gameObject.SetActive(false);
    }

    string GetResourceName(string id)
    {
        switch (id)
        {
            case "wood_dub": return "дуб";
            case "wood_bereza": return "берёза";
            case "wood_yel": return "ель";
            default: return id;
        }
    }
}