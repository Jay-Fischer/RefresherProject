using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] Stat maxHealth;
    [SerializeField] Stat currentHealth;
    bool inHazard;
    private Coroutine RunningRoutine;

    [SerializeField] bool decreaseHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth.amount = maxHealth.amount;
    }
    
    public void OnHazardEnter(){
        inHazard = true;
        RunningRoutine = StartCoroutine(HazardDamage());
    }
    public void OnHazardExit(){
        inHazard = false;
        StopCoroutine(RunningRoutine);
        RunningRoutine = null;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator HazardDamage(){
        if(inHazard){
            while (currentHealth.amount > 0){
                currentHealth.amount -= 5;

                yield return new WaitForSeconds(1.0f);
            }
        }
    }
}
