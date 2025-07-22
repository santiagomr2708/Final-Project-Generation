using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContadorPuzzles : MonoBehaviour
{
    public static int puzzlesCompletados = 0;
    public static int totalPuzzles = 0;

    void Start()
    {
        StartCoroutine(ContarPuzzles());
    }

    IEnumerator ContarPuzzles()
    {
        yield return new WaitForSeconds(12f);

        GameObject[] puzzles = GameObject.FindGameObjectsWithTag("Puzzle");
        totalPuzzles = puzzles.Length;

        Debug.Log("Puzzles total: " + totalPuzzles);
    }

    /// <summary>
    /// para llamar el completado sdolo toca colocar "ContadorPuzzles.Completar();"
    /// y este le coloca un +1 del puzle completado
    /// </summary>/
    public static void Completar()
    {
        puzzlesCompletados++;

        if (puzzlesCompletados >= totalPuzzles && totalPuzzles > 0)
        {
            SceneManager.LoadScene("");
        }
    }
}