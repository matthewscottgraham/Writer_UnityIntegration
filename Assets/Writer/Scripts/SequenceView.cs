using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SequenceView : MonoBehaviour
{
    public Action OnContinue;
    
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI textLabel;
    [SerializeField] private TextMeshProUGUI characterLabel;
    [SerializeField] private Button continueButton;
    
    private const string CharacterTagKey = "character";
    
    public void DisplayPassage(Passage passage)
    {
        canvas.gameObject.SetActive(true);
        textLabel.text = passage.Text;
        characterLabel.text = SequenceUtilities.GetTagValue(CharacterTagKey, passage.Tags);
    }

    public void Close()
    {
        canvas.gameObject.SetActive(false);
        textLabel.text = "";
        characterLabel.text = "";
    }

    private void OnEnable()
    {
        continueButton.onClick.AddListener(HandleContinue);
        canvas.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(HandleContinue);
    }

    private void HandleContinue()
    {
        OnContinue?.Invoke();
    }

    
}