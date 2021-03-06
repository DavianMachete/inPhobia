using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Public Fields

    public static UIManager instance;

    #endregion

    #region Serialized Fields

    [Header("Main scenes")]

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject cutscene_1;
    [SerializeField] private GameObject cutscene_2;
    [SerializeField] private GameObject desctop;
    [SerializeField] private GameObject novel;
    [SerializeField] private GameObject cardCollecter;
    [SerializeField] private GameObject fight;
    [SerializeField] private GameObject cardsCanvas;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private GameObject Bar;

    [Header("Main Menu")]
    [SerializeField] private GameObject continueButton;

    [Header("Desctop")]
    [SerializeField] private DesctopController desctopController;

    [Header("Dialogs")]
    [SerializeField] private DialogController dialogController;

    [Header("Progress Bar")]
    [SerializeField] private ProgressBarController progressBarController;

    [Header("Therapist Deck Collecter")]
    [SerializeField] private TherapistDeckCollecter therapistDeckCollecter;

    [Header("Canvas Settings")]
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Fight Scene")]
    [SerializeField] private RectTransform card_sCanvasRT;

    [Header("Test settings")]
    [SerializeField] private IdeaController ideaController;

    [Header("Game end settings")]
    [SerializeField] private GameObject gameComplete;
    [SerializeField] private GameObject gameFailed;

    #endregion

    #region Unity Behaviour

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
    }

    #endregion

    #region Public Methods

    public RectTransform GetCard_sCanvas()
    {
        return card_sCanvasRT;
    }

    public void Initialize()
    {
        OpenMainMenu(false);
    }

    public void OpenMainMenu(bool withPause)
    {
        AudioManager.instance.PlayMainMenuPhaseAudios();
        mainMenu.SetActive(true);
        if (withPause)
        {
            continueButton.SetActive(true);
        }
        else
        {
            cutscene_1.SetActive(false);
            cutscene_2.SetActive(false);
            desctop.SetActive(false);
            novel.SetActive(false);
            cardCollecter.SetActive(false);
            fight.SetActive(false);
            cardsCanvas.SetActive(false);
            gameEnd.SetActive(false);
            Bar.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        continueButton.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void OpenCutSceneOne()
    {
        AudioManager.instance.StopAll();
        mainMenu.SetActive(false);
        cutscene_1.SetActive(true);
        cutscene_2.SetActive(false);
        desctop.SetActive(false);
        novel.SetActive(false);
        cardCollecter.SetActive(false);
        fight.SetActive(false);
        cardsCanvas.SetActive(false);
        gameEnd.SetActive(false);
        Bar.SetActive(false);
    }

    public void OpenCutSceneTwo()
    {
        AudioManager.instance.StopAll();
        mainMenu.SetActive(false);
        cutscene_1.SetActive(false);
        cutscene_2.SetActive(true);
        desctop.SetActive(false);
        novel.SetActive(false);
        cardCollecter.SetActive(false);
        fight.SetActive(false);
        cardsCanvas.SetActive(false);
        gameEnd.SetActive(false);
        Bar.SetActive(false);
    }

public void OpenDesctop()
    {
        AudioManager.instance.PlayMainMenuPhaseAudios();
        desctopController.ShowNextPatient(true);

        mainMenu.SetActive(false);
        cutscene_1.SetActive(false);
        cutscene_2.SetActive(false);
        desctop.SetActive(true);
        novel.SetActive(false);
        cardCollecter.SetActive(false);
        fight.SetActive(false);
        cardsCanvas.SetActive(false);
        gameEnd.SetActive(false);
        Bar.SetActive(false);
    }

    public void OpenNovel()
    {
        AudioManager.instance.PlayNovelPhaseAudios();
        progressBarController.InitializeProgressBar();
        dialogController.InitializeDiolog();

        mainMenu.SetActive(false);
        cutscene_1.SetActive(false);
        cutscene_2.SetActive(false);
        desctop.SetActive(false);
        novel.SetActive(true);
        cardCollecter.SetActive(false);
        fight.SetActive(false);
        cardsCanvas.SetActive(false);
        gameEnd.SetActive(false);
        Bar.SetActive(true);
    }

    [ContextMenu("Open Card collector (5trust, 9 idea)")]
    public void OpenCardCollecterImmidiatly()
    {
        GameManager.instance.InitialiseGame();

        progressBarController.InitializeProgressBar();
        ideaController.Initialize();

        progressBarController.AddPoint(3);
        ideaController.AddIdea(9);

        OpenCardCollecter();
    }

    public void OpenCardCollecter()
    {
        AudioManager.instance.PlayDeckBuildingPhaseAudios();
        therapistDeckCollecter.InitializeCollecter();

        mainMenu.SetActive(false);
        cutscene_1.SetActive(false);
        cutscene_2.SetActive(false);
        desctop.SetActive(false);
        novel.SetActive(false);
        cardCollecter.SetActive(true);
        fight.SetActive(false);
        cardsCanvas.SetActive(false);
        gameEnd.SetActive(false);
        Bar.SetActive(true);
    }

    public void OpenFightScene()
    {
        AudioManager.instance.PlayBattlePhaseAudios();
        mainMenu.SetActive(false);
        cutscene_1.SetActive(false);
        cutscene_2.SetActive(false);
        desctop.SetActive(false);
        novel.SetActive(false);
        cardCollecter.SetActive(false);
        fight.SetActive(true);
        cardsCanvas.SetActive(true);
        gameEnd.SetActive(false);
        Bar.SetActive(false);
    }

    public void OpenGameEndScene()
    {
        mainMenu.SetActive(false);
        cutscene_1.SetActive(false);
        cutscene_2.SetActive(false);
        desctop.SetActive(false);
        novel.SetActive(false);
        cardCollecter.SetActive(false);
        fight.SetActive(false);
        cardsCanvas.SetActive(false);
        gameEnd.SetActive(false);
        Bar.SetActive(false);
    }

    public void SetCanvasGroupActive(bool value)
    {
        canvasGroup.interactable = value;
        canvasGroup.interactable = value;
    }

    public void OpenGameEndPanel(bool completed)
    {
        if(completed)
            AudioManager.instance.PlayGameEndAudios();

        gameFailed.SetActive(!completed);
        gameComplete.SetActive(completed);

        gameEnd.SetActive(true);
    }

    #endregion

    #region Private Fields

    #endregion

    #region Private Methods

    #endregion

    #region Coroutines
    #endregion
}
