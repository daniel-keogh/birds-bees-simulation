using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The ChaseController singleton.
//
// The ShowUIMessage method is called by State objects
// when an event has taken place (e.g. When a bee is eaten) and a message will 
// be printed on the screen.
//
// The Chase/Flee functionality is implemented in the BeginChase() method.
//
// Lastly, if a Bee escapes (by reaching the Hive) the BeeEscaped() method
// is called by the OnTriggerEnter2D() method in the Bee's Fleeing State.
public class ChaseController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text infoText;
    [SerializeField] private float messageDuration = 2f;

    private static ChaseController instance;

    void Awake()
    {
        SetupSingleton();
    }

    public void ShowUIMessage(string message)
    {
        StartCoroutine(ShowTimedMessage(message));
    }

    public void BeginChase(Bee bee, Bird bird)
    {
        State beeState = bee.StateMachine.CurrentState;

        if (beeState is Dancing)
        {
            return;
        }

        bird.StateMachine.CurrentState = new Chasing(bird.gameObject, bird.StateMachine, bee.gameObject);
        bee.StateMachine.CurrentState = new Fleeing(bee.gameObject, bee.StateMachine);
    }

    public void BeeEscaped(Bee bee)
    {
        var birds = FindObjectsOfType<Bird>();

        foreach (var bird in birds)
        {
            var target = bird.GetComponent<Moveable>().Target;

            if (target == bee.transform)
            {
                bird.StateMachine.CurrentState = new Resting(bird.gameObject, bird.StateMachine);
                StartCoroutine(ShowTimedMessage("Bee escaped..."));
            }
        }
    }

    private IEnumerator ShowTimedMessage(string message)
    {
        infoText.text = message;

        yield return new WaitForSeconds(messageDuration);

        // Hide the message
        infoText.text = "";
    }

    private void SetupSingleton()
    {
        // Make this object a singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // if `instance` does not reference this object destroy it
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
