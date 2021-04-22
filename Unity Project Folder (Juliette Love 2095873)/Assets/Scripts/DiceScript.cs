using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceScript : MonoBehaviour
{
    public float NumberRolled;
    public float EnemyNumberRolled;
    public float FinalNumberRolled;
    public bool ButtonPressed = false;
    public GameObject DiceText;
    public GameObject EnemyDiceText;
    public Text ConsoleText;
    public float ChanceToHit = 0;

    public Image playerHealth;

    public GameObject playerMissExplanation;
    public bool FirstTimePlayerMiss = true;

    public void ButtonClicked() //CODE DEALING WITH PLAYER ROLL
    {
        ButtonPressed = true;

        CombatSystem combatSystem = GameObject.FindWithTag("CombatSystem").GetComponent<CombatSystem>();

        if (ButtonPressed == true && combatSystem.CanRoll == true)
        {
            combatSystem.CanRoll = false;
            NumberRolled = Random.Range(1, 6);

            FinalNumberRolled = NumberRolled + ChanceToHit;

            if (FinalNumberRolled >= 6) //To make sure it does not show a larger value. 
            {
                FinalNumberRolled = 6;
            }

            DiceText.GetComponent<UnityEngine.UI.Text>().text = FinalNumberRolled.ToString("F0");
            ButtonPressed = false;
            
            Enemy enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();

            if (enemy.defenceNumber >= FinalNumberRolled) //Enemy defends itself. Player misses
            {
                if (ChanceToHit == 0)
                {
                    ChanceToHit += 1;
                }

                Invoke("EnemyTurn", 2f);
                combatSystem.PlayerMissText.SetActive(true);
                Invoke("FeedbackTextDisappear", 2f);

                if (FirstTimePlayerMiss == true && playerMissExplanation != null)
                {
                    playerMissExplanation.SetActive(true);
                    Invoke("MissTextDisappear", 3f);
                    FirstTimePlayerMiss = false;
                }

                AttackScript attackScript = GameObject.FindWithTag("CombatSystem").GetComponent<AttackScript>();
                attackScript.PlayerCanAttack = true;
                combatSystem.CanRoll = false;
            }
            
            if (enemy.defenceNumber < FinalNumberRolled) 
            {
                if (ChanceToHit == 1)
                {
                    ChanceToHit = 0;
                }

                combatSystem.state = CombatState.PLAYERCOMBAT;
                ConsoleText.text = "Your turn";

                AttackScript attackScript = GameObject.FindWithTag("CombatSystem").GetComponent<AttackScript>();
                attackScript.PlayerCanAttack = true;

                combatSystem.fillAmountFireball = (attackScript.BurnChance - 1) / 3; //Because the BurnChance is a value between 2 and 4, I am subtracting 1 to make it out of 3.
                combatSystem.FireballCharge.fillAmount = combatSystem.fillAmountFireball / 1;
            }
        }
    }

    public void EnemyTurn()
    {
        CombatSystem combatSystem = GameObject.FindWithTag("CombatSystem").GetComponent<CombatSystem>();
        combatSystem.state = CombatState.ENEMYTURN;
        combatSystem.EnemyCanRoll = true;

        ConsoleText.text = "Enemy Turn";
    }

    public void ReplayLvl1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ReplayLvl2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ReplayLvl3()
    {
        SceneManager.LoadScene("Level3");
    }

    void MissTextDisappear()
    {
        playerMissExplanation.SetActive(false);
    }

    void FeedbackTextDisappear()
    {
        CombatSystem combatSystem = GameObject.FindWithTag("CombatSystem").GetComponent<CombatSystem>();
        combatSystem.PlayerMissText.SetActive(false);
    }
}
