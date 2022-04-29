using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game:")]
    public Player player;
    public GameObject enemyspawner;
    public GameObject path;
    [Header("UI:")]
    public Text ammoText;
    //public Image healthBar;
    public Text healthText;
    public Text enemyText;
    public Text winText;
    public Text loseText;

    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + player.Ammo;
        //healthBar.initialHealth = player.Health;
        healthText.text = "Health: " + player.Health;
        
        int killedenemies = 0;
        foreach (Enemy enemy in enemyspawner.GetComponentsInChildren<Enemy>())
        {
            if(enemy.Killed == false)
            {
                killedenemies++;
            }
        }
        enemyText.text = "Enemies: " + killedenemies;

        // Win Condition
        if(killedenemies == 0)
        {
            winText.gameObject.SetActive(true);
            Destroy(path);
        }

        // Lose Condition
        if (player.Killed == true)
        {
            loseText.gameObject.SetActive(true);
            loseText.text = "You Lose!";
        }
    }
}
