using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private XROrigin origin;
    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private int maxLives;
    private int lives;

    private int score;

    [SerializeField]
    private Transform trayParent;
    [SerializeField]
    private Transform ticketParent;

    [SerializeField]
    private GameObject trayPrefab;
    [SerializeField]
    private GameObject ticketPrefab;
    private Tray currentTray;
    private Ticket currentTicket;

    [SerializeField]
    private float ticketTime;
    private float currentTicketTime;

    [SerializeField]
    private TMP_Text ticketTimeText;

    [SerializeField]
    private MeshRenderer[] lifeIndicators;
    [SerializeField]
    private Material onMat;
    private int lightIndex;

    [SerializeField]
    private DestroyOrder destroyOrder;

    [SerializeField]
    private TMP_Text scoreText;

    private bool gameStarted;
    private bool gameEnded;

    [Header("Game Status Stuff")]
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private GameObject anchors;
    [SerializeField]
    private GameObject startCanvas;
    [SerializeField]
    private GameObject uiRay;

    [SerializeField]
    private GameObject endCanvas;
    [SerializeField]
    private TMP_Text endScore;
    [SerializeField]
    private Transform endPosition;
    [SerializeField]
    private Transform playerPosition;


    public bool GameStarted { get => gameStarted; private set => gameStarted = value; }

    private void Start()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        lives = maxLives;

        playerPosition.position = spawnPosition.position;
    }

    private void Update()
    {
        if(gameEnded || !gameStarted) return;

        currentTicketTime -= Time.deltaTime;

        float timeFloored = Mathf.Round(currentTicketTime);
        ticketTimeText.text = timeFloored.ToString();

        if(currentTicketTime <= 0)
        {
            RemoveLife();
            StartNewOrder();

            AudioManager.Instance.PlaySFX("Wrong", true);
        }
    }

    public void StartNewOrder()
    {
        if(gameEnded) return;

        if (currentTray != null) Destroy(currentTray.gameObject);
        if(currentTicket != null) Destroy(currentTicket.gameObject);

        destroyOrder.DestroyObjects();

        GameObject tray = Instantiate(trayPrefab, trayParent);
        currentTray = tray.GetComponent<Tray>();

        GameObject ticket = Instantiate(ticketPrefab, ticketParent);
        currentTicket = ticket.GetComponent<Ticket>();

        currentTicketTime = ticketTime;
    }

    public void DeliverOrder()
    {
        if (IsOrderCorrect())
        {
            UpdateScore();

            AudioManager.Instance.PlaySFX("Correct", true);
        }

        else
        {
            RemoveLife();

            AudioManager.Instance.PlaySFX("Wrong", true);
        }

        StartNewOrder();
    }

    private bool IsOrderCorrect()
    {
        FryBox fries = currentTray.FryBox;
        Drink drink = currentTray.Drink;
        Burger burger = currentTray.Burger;

        // Missing fries or drink.
        if(fries == null || drink == null)
        {
            Debug.Log("null");
            return false;
        }

        // Check fries.
        if(!fries.Full || fries.Size != currentTicket.FrySize)
        {
            Debug.Log("Fry issue");
            Debug.Log(fries.Full);
            Debug.Log(fries.Size);
            Debug.Log(currentTicket.FrySize);
            return false;
        }

        // Check drink.
        if(!drink.IsFull || drink.Size != currentTicket.DrinkSize || drink.Type != currentTicket.DrinkType)
        {
            Debug.Log("Drink issues");
            Debug.Log(drink.IsFull);
            Debug.Log(drink.Size);
            Debug.Log(currentTicket.DrinkSize);
            Debug.Log(drink.Type);
            Debug.Log(currentTicket.DrinkType);
            return false;
        }

        // Check burger.
        if(burger.PattyAmount != currentTicket.PattyAmount || burger.LettuceAmount != currentTicket.LettuceAmount || burger.CheeseAmount != currentTicket.CheeseAmount
            || burger.CowTongueAmount != currentTicket.CowTongueAmount || burger.GreenCandyAmount != currentTicket.GreenCandyAmount || burger.BlueRingAmount != currentTicket.BlueRingAmount || burger.BunAmount != 1)
        {
            Debug.Log("Burger issue");
            return false;
        }

        if (burger.TopBunCheck.IngredientAmount > 0) return false;

        // If passed checks order is correct.
        return true;
    }

    private void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void RemoveLife()
    {
        lives--;

        lifeIndicators[lightIndex].material = onMat;
        lightIndex++;

        if (lives <= 0) EndGame();
    }

    /// <summary>
    ///  Necessary steps for starting game.
    /// </summary>
    public void StartGame()
    {
        // Start the initial order.
        StartNewOrder();

        // Enable and disable necessary elements.
        anchors.SetActive(true);

        startCanvas.SetActive(false);
        uiRay.SetActive(false);

        playerPosition.position = startPosition.position;

        // Start music.
        AudioManager.Instance.PlayMusic("MainTheme");

        // Set game as started.
        gameStarted = true;
    }

    /// <summary>
    /// Restarts the game.
    /// </summary>
    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentScene);
    }

    /// <summary>
    /// Necessary steps for ending game.
    /// </summary>
    private void EndGame()
    {
        // Move player to end position.
        playerPosition.position = endPosition.position;

        // Enable and disable necessary elements.
        anchors.SetActive(false);

        endCanvas.SetActive(true);
        uiRay.SetActive(true);

        // Set score text.
        endScore.text = score.ToString();

        // Audio.
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlaySFX("Defeat", true);

        // Set game as ended.
        gameEnded = true;
    }
}
