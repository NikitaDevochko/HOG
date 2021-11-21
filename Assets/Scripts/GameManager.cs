using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string LEVEL_KEY = "level_index";
    [SerializeField] private LevelConfig LevelConfig;

    private int currentLevel;
    private Level currentLevelInstance;
    private UIGameScrean gameScrean;

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject winPanel;

    public int CurrentLevel
    {
        get
        {
            return PlayerPrefs.GetInt(LEVEL_KEY, 0);
        }
        set
        {
            PlayerPrefs.SetInt(LEVEL_KEY, value);
            PlayerPrefs.Save();
        }
    }

    private void Start()
    {
        currentLevel = CurrentLevel;
        CreateLevel(currentLevel);
        openMenuPanel();
    }

    private void CreateLevel(int index)
    {
        Level level = LevelConfig.GetLevelByIndex(index);
        InstantiateLevel(level);
    }

    private void InstantiateLevel(Level level)
    {
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance.gameObject);
        }
        if (level != null)
        {
            currentLevelInstance = Instantiate(level);
            currentLevelInstance.Initialize();
            gameScrean = new UIGameScrean();
            gameScrean.Initialize(currentLevelInstance);
        }
    }

    public void openMenuPanel()
    {
        menuPanel.SetActive(true);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void openGamePanel()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void openWinPanel()
    {
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
    }

}
