using TMPro;
using UnityEngine;

public class UIEyeCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eyeText;
    [SerializeField] PuzzleEyeManager puzzleEyeManager;

    void Start()
    {
        puzzleEyeManager = GetComponent<PuzzleEyeManager>();
    }

    void Update()
    {
        eyeText.text = $"Ojos activados: {puzzleEyeManager.totalEyesCount}";
    }
}
