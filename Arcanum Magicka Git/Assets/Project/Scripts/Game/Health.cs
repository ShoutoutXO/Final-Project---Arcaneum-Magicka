using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* http://www.Mousawi.Dev By @AbdullaMousawi*/
public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar, ringHealthBar;
    public Image[] healthPoints;
    private bool isHurt;
    public float health, maxHealth = 100;
    public float knockbackForce = 100f;
    public float lerpSpeed;
    public float hurtDuration = 0.5f;

    private bool killed;
    public bool Killed { get { return killed; } }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "Health: " + health + "%";
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);
        ringHealthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), lerpSpeed);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }
    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
        ringHealthBar.color = healthColor;
    }

    bool DisplayHealthPoint(float _health, int pointNumber)
    {
        return ((pointNumber * 10) >= _health);
    }


    void OnTriggerEnter(Collider otherCollider)
    {

        if (isHurt == false)
        {
            GameObject hazard = null;

            if (otherCollider.GetComponent<Enemy>() != null)
            {
                // Get Enemy and ready for it use
                Enemy enemy = otherCollider.GetComponent<Enemy>();
                // Taking a damage
                health -= enemy.damage;
                // is Hurt is triggering
                hazard = enemy.gameObject;
            }
            else if (otherCollider.GetComponent<Bullet>() != null)
            {
                Bullet bullet = otherCollider.GetComponent<Bullet>();
                if (bullet.ShotByPlayer == false)
                {
                    hazard = bullet.gameObject;
                    health -= bullet.damage;
                    bullet.gameObject.SetActive(false);
                }
            }
            if (hazard != null)
            {
                isHurt = true;

                // Perform the knockback effect
                Vector3 hurtDirection = (transform.position - hazard.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;
                GetComponent<ForceReceiver>().AddForce(knockbackDirection, knockbackForce);

                StartCoroutine(HurtRoutine());
            }
            if (health <= 0)
            {

                SceneManager.LoadScene(2);

                //if (killed == false)
                //{
                //  killed = true;
                //OnKill();
                //}
            }
        }
    }

    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtDuration);
        isHurt = false;
    }

    private void OnKill()
    {

    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;
    }
}
