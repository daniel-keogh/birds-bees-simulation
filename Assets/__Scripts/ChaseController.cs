using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// The ChaseController singleton.
//
// The ShowUIMessage method should get called by State objects
// when an event has taken place (e.g. When a bee is eaten) and a message should 
// be printed on the screen.
// 
// The remaining behaviour isn't fully implemented.
public class ChaseController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text infoText;
    [SerializeField] private float messageDuration = 3f;

    private static ChaseController instance;

    void Awake()
    {
        SetupSingleton();
    }

    void Start()
    {

    }

    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    public void ShowUIMessage(string message)
    {
        StartCoroutine(ShowTimedMessage(message));
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
