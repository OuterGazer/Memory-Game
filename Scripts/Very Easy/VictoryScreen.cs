using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    private TextMeshProUGUI victoryText;
    private SceneController controller;

    // Start is called before the first frame update
    void Start()
    {
        this.controller = GameObject.Find("Scene Manager").GetComponent<SceneController>();
        this.victoryText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        this.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf)
            this.victoryText.text = "Congratulations! You have matched all pairs! You managed to get " + this.controller.PlayerScore
                + " points in " + this.controller.Turns + " turns. Try to beat your score next time!";
    }
}
