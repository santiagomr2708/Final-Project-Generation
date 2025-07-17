using UnityEngine;

public class EyeLogic : MonoBehaviour
{
    PuzzleEyeManager puzzleEyeManager;
    Interactable interactable;
    GameObject parentEye;

    void Start()
    {
        puzzleEyeManager = GameObject.Find("Puzzle Eye Manager").GetComponent<PuzzleEyeManager>();
        parentEye = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void EyePressed()
    {
        puzzleEyeManager.eyeCount++;
        Destroy(gameObject);
        Destroy(parentEye);
        Destroy(this);
       
        
    }
}
