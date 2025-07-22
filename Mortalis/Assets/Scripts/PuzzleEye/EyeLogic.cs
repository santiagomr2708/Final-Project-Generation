using UnityEngine;

public class EyeLogic : MonoBehaviour
{
    PuzzleEyeManager puzzleEyeManager;
    Interactable interactable;

    void Start()
    {
        puzzleEyeManager = GameObject.Find("Puzzle Eye Manager").GetComponent<PuzzleEyeManager>(); 
        
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EyePressed()
    {
        puzzleEyeManager.eyeCount++;
        Destroy(this);
    }
}
