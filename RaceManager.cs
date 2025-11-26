using UnityEngine;

public class RaceManager : MonoBehaviour
{
    // Now looking for the NEW script
    public SimpleAI aiSpider; 
    
    private bool raceStarted = false;

    void Update()
    {
        // Press Space to start
        if (!raceStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartRace();
        }
    }

    void StartRace()
    {
        raceStarted = true;
        print("RACE STARTED!"); // Check the console for this message
        
        // Call the new command
        if (aiSpider != null)
        {
            aiSpider.GoGoGo();
        }
    }
}