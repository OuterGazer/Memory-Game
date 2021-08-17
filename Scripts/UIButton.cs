using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    //public Color highlightColor = Color.cyan;

    /*public void OnMouseEnter()
    {
        SpriteRenderer sprite = this.gameObject.GetComponent<SpriteRenderer>();
        if (sprite != null)
            sprite.color = this.highlightColor;
    }*/

    /*public void OnMouseExit()
    {
        SpriteRenderer sprite = this.gameObject.GetComponent<SpriteRenderer>();
        if (sprite != null)
            sprite.color = Color.white;
    }*/

    /*public void OnMouseDown()
    {
        this.gameObject.GetComponent<RectTransform>().parent.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }*/

    /*public void OnMouseUp()
    {
        this.gameObject.GetComponent<RectTransform>().parent.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        //this.gameObject.GetComponent<RectTransform>().sizeDelta.Scale(Vector2.one);

        if (this.targetObject != null)
            this.targetObject.SendMessage(this.targetMessage);
    }*/

    public void OnMouseClick()
    {
        SceneManager.LoadScene("Main Menu");

        /*if (this.targetObject != null)
            this.targetObject.SendMessage(this.targetMessage);*/
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
