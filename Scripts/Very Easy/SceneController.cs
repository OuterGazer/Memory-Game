using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int playerScore = 0;
    public int PlayerScore
    {
        get { return this.playerScore; }
    }
    private int turns = 0;
    public int Turns
    {
        get { return this.turns; }
    }
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI turnText;

    [SerializeField] private GameObject targetObject;
    private int numberOfMatches = 0;

    public const int GRID_ROWS = 2;
    public const int GRID_COLS = 4;
    public const float OFFSET_X = 2f;
    public const float OFFSET_Y = 2.5f;

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] cardImages;

    [SerializeField] private AudioClip cardFlipSound;
    private AudioSource audioSource;

    private MemoryCard firstCardRevealed;
    private MemoryCard secondCardRevealed;

    WaitForSeconds fullFlip;
    WaitForSeconds checkForMatch;

    public bool CanReveal
    {
        get { return this.secondCardRevealed == null; }
    }

    public void CardRevealed(MemoryCard inCard)
    {
        if (this.firstCardRevealed == null)
        {
            this.firstCardRevealed = inCard;
            this.firstCardRevealed.HasBeenRevealedOnce = true;
            this.firstCardRevealed.FlippedCount++;
            this.StartCoroutine(CardFlipAnimation(inCard));
        }
        else
        {
            this.secondCardRevealed = inCard;
            this.secondCardRevealed.HasBeenRevealedOnce = true;
            this.secondCardRevealed.FlippedCount++;
            this.StartCoroutine(CardFlipAnimation(inCard));
            this.StartCoroutine(CheckMatch());
        }
    }    

    private IEnumerator CardFlipAnimation(MemoryCard inCard)
    { 
        Animator cardFlip = inCard.GetComponent<Animator>();

        if (!inCard.CardRear.activeSelf && inCard.IsFlipped)
        {
            inCard.Unreveal();
        }            

        cardFlip.enabled = true;
        this.audioSource.PlayOneShot(this.cardFlipSound);

        yield return this.fullFlip;        

        cardFlip.enabled = false;

        if (inCard.CardRear.activeSelf && !inCard.IsFlipped)
        {
            inCard.CardRear.SetActive(false);
            inCard.IsFlipped = true;
        }
        else
            inCard.IsFlipped = false;

        if (this.numberOfMatches == 4)
            this.targetObject.SetActive(true);
    }

    private IEnumerator CheckMatch()
    {
        if (this.firstCardRevealed.CardId == this.secondCardRevealed.CardId)
        {
            this.playerScore += 100;
            this.numberOfMatches++;            
        }
        else
        {
            yield return this.checkForMatch;

            //this.firstCardRevealed.Unreveal();
            if (this.firstCardRevealed.HasBeenRevealedOnce && this.firstCardRevealed.FlippedCount > 1)
                this.playerScore -= 25;
            this.StartCoroutine(CardFlipAnimation(this.firstCardRevealed));

            //this.secondCardRevealed.Unreveal();
            if (this.secondCardRevealed.HasBeenRevealedOnce && this.secondCardRevealed.FlippedCount > 1)
                this.playerScore -= 25;
            this.StartCoroutine(CardFlipAnimation(this.secondCardRevealed));
        }

        this.scoreText.text = "Score: " + this.playerScore.ToString();
        this.turns++;
        this.turnText.text = "Turns: " + this.turns.ToString();

        this.firstCardRevealed = null;
        this.secondCardRevealed = null;
    }


    private int[] ShuffleArray(int[] inArray)
    {
        int[] shuffledArray = inArray.Clone() as int[];

        for (int i = 0; i < shuffledArray.Length; i++)
        {
            int temp = shuffledArray[i];
            int rnd = Random.Range(i, shuffledArray.Length);
            shuffledArray[i] = shuffledArray[rnd];
            shuffledArray[rnd] = temp;
        }

        return shuffledArray;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.gameObject.GetComponent<AudioSource>();

        this.fullFlip = new WaitForSeconds(0.824f);
        this.checkForMatch = new WaitForSeconds(1.0f);

        Vector3 startCard = this.originalCard.transform.position;

        int[] cardNumbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        cardNumbers = this.ShuffleArray(cardNumbers);

        for (int i = 0; i < GRID_COLS; i++)
        {
            for(int j = 0; j < GRID_ROWS; j++)
            {
                MemoryCard currentCard;

                if((i == 0) && (j == 0))
                {
                    currentCard = this.originalCard;
                }
                else
                {
                    currentCard = GameObject.Instantiate<MemoryCard>(this.originalCard);
                }

                int index = j * GRID_COLS + i; //This line further randomizes card images by not making a liner pick order to the cardNumbers array: 0, 4, 1, 5, 2, 6, 3, 7.
                int cardId = cardNumbers[index];
                currentCard.SetCard(cardId, this.cardImages[cardId]);

                float posX = (OFFSET_X * i) + startCard.x;
                float posY = - (OFFSET_Y * j) + startCard.y;
                currentCard.transform.position = new Vector3(posX, posY, startCard.z);
            }
        }

        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
