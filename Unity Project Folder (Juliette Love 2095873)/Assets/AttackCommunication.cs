using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackCommunication : MonoBehaviour
{
    public Image FireballUIImage;

    public GameObject FireballAttackUI;
    public GameObject MeleeAttackUI;
    public GameObject HealUI;
    public GameObject DefendUI;

    public Text FireballChanceText;

    public GameObject FireballDamageText;
    public GameObject FireballDamageText2;
    public GameObject FireballPercentageText;
    public GameObject MeleeDamageText;
    public GameObject HealText;
    public GameObject DefendText;

    void Update()
    {
        AttackScript attackScript = GameObject.FindWithTag("CombatSystem").GetComponent<AttackScript>();
        if (attackScript.BurnChance == 4)
        {
            FireballChanceText.text = "33.33% backfire chance";
            FireballUIImage.color = new Color(1, 0, 0, 1);
        }
        if (attackScript.BurnChance == 3)
        {
            FireballChanceText.text = "50% backfire chance";
            FireballUIImage.color = new Color(1, 1, 1, 1);
        }
        if (attackScript.BurnChance == 2)
        {
            FireballChanceText.text = "66.67% backfire chance";
            FireballUIImage.color = new Color(1, 1, 1, 1);
        }
    }

    void OnMouseOver()
    {
        if (gameObject.name == "FireballUI")
        {
            FireballDamageText.SetActive(true);
            FireballDamageText2.SetActive(true);
            FireballPercentageText.SetActive(true);
            Debug.Log("Over Fire UI");
        }

        if (gameObject.name == "MeleeUI")
        {
            MeleeDamageText.SetActive(true);
            Debug.Log("Over Melee UI");
        }

        if (gameObject.name == "HealUI")
        {
            HealText.SetActive(true);
            Debug.Log("Over Heal UI");
        }

        if (gameObject.name == "DefendUI")
        {
            DefendText.SetActive(true);
            Debug.Log("Over Defend UI");
        }
    }

    void OnMouseExit()
    {
        if (gameObject.name == "FireballUI")
        {
            FireballDamageText.SetActive(false);
            FireballDamageText2.SetActive(false);
            FireballPercentageText.SetActive(false);
        }

        if (gameObject.name == "MeleeUI")
        {
            MeleeDamageText.SetActive(false);
        }

        if (gameObject.name == "HealUI")
        {
            HealText.SetActive(false);
        }

        if (gameObject.name == "DefendUI")
        {
            DefendText.SetActive(false);

        }
    }
}
