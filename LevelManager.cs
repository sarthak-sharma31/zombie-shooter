using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public RectTransform levelButtonParent;
    public GameObject levelButtonPrefab; // Prefab for level buttons
    public TextMeshProUGUI levelNameText; // UI Text for level name
    public TextMeshProUGUI LevelMission_1;
    public TextMeshProUGUI LevelMission_2;
    public TextMeshProUGUI LevelMission_3;
    public Button startButton; // Start button

    private Level selectedLevel;

    void Start()
    {
        PopulateLevelButtons();
        startButton.onClick.AddListener(StartLevel);
        startButton.interactable = false; // Disable start button initially
    }

    void PopulateLevelButtons()
    {
        foreach (Level level in levels)
        {
            GameObject buttonObject = Instantiate(levelButtonPrefab, levelButtonParent);
            Button button = buttonObject.GetComponent<Button>();
            TextMeshProUGUI buttonText = buttonObject.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = level.levelName;
            button.onClick.AddListener(() => OnLevelSelected(level));
        }
    }

    void OnLevelSelected(Level level)
    {
        selectedLevel = level;
        levelNameText.text = level.levelName;
        LevelMission_1.text = level.levelMission1;
        LevelMission_2.text = level.levelMission2;
        LevelMission_3.text = level.levelMission3;
        startButton.interactable = true;
    }

    void StartLevel()
    {
        if (selectedLevel != null)
        {
            SceneManager.LoadScene(selectedLevel.sceneName);
        }
    }
}
