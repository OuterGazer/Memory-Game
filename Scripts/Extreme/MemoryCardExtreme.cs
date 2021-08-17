using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCardExtreme : MonoBehaviour
{

    [SerializeField] private GameObject cardRear;
    public GameObject CardRear
    {
        get { return this.cardRear; }
    }

    [SerializeField] private SceneControllerExtreme manager;

    private int cardId;
    public int CardId
    {
        get { return this.cardId; }
    }
    public void SetCard(int inCardId, Sprite inImage)
    {
        this.cardId = inCardId;   
        this.gameObject.GetComponent<SpriteRenderer>().sprite = inImage;

    }

    private bool isFlipped = false;
    public bool IsFlipped
    {
        get { return this.isFlipped; }
        set { this.isFlipped = value; }
    }

    private bool hasBeenRevealedOnce = false;
    public bool HasBeenRevealedOnce
    {
        get { return this.hasBeenRevealedOnce; }
        set { this.hasBeenRevealedOnce = value; }
    }

    private int flippedCount = 0;
    public int FlippedCount
    {
        get { return this.flippedCount; }
        set { this.flippedCount = value; }
    }

    public void OnMouseDown()
    {
        if ((this.cardRear.activeSelf == true) &&
            (this.manager.CanReveal == true))
        {
            //this.cardRear.SetActive(false);
            this.manager.CardRevealed(this);
        }
    }

    public void Unreveal()
    {        
        this.cardRear.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Animator cardFlip = this.gameObject.GetComponent<Animator>();
        cardFlip.enabled = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
