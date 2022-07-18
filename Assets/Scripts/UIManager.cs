using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _livesText;

    // Start is called before the first frame update
    void Start()
    {
        _coinText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int coins)
    {
        _coinText.text = "Score: " + coins.ToString();
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
