using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Od : MonoBehaviour
{
    private static Od instance;
    public static Od Instance { get { return instance; } }
    public GameObject MagicPrefab;
    public int bulletAmount = 20;

    private List<GameObject> bullets;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        // Preload bullets
        bullets = new List<GameObject>(bulletAmount);

        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject prefabInstance = Instantiate(MagicPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);
            bullets.Add(prefabInstance);
        }
    }

    // Update is called once per frame
    public GameObject GetBullet(bool shotByPlayer)
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                bullet.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
                return bullet;
            }
        }

        GameObject prefabInstance = Instantiate(MagicPrefab);
        prefabInstance.transform.SetParent(transform);
        prefabInstance.GetComponent<Bullet>().ShotByPlayer = shotByPlayer;
        bullets.Add(prefabInstance);

        return prefabInstance;
    }
}