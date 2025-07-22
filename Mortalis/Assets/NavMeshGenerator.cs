using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshGenerator : MonoBehaviour
{
    public RoomTemplates templates;

    void Start()
    {
        StartCoroutine(EsperarYGenerarNavMesh());
    }

    IEnumerator EsperarYGenerarNavMesh()
    {
        yield return new WaitForSeconds(12f);

        if (templates != null && templates.salasContenedor != null)
        {
            NavMeshSurface surface = templates.salasContenedor.AddComponent<NavMeshSurface>();
            surface.collectObjects = CollectObjects.Children;

            
            surface.BuildNavMesh();
        }
    }
}