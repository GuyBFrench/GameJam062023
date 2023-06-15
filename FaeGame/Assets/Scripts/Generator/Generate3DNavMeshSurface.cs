using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Generate3DNavMeshSurface : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;
    public List<string> navLayersToMask;

    public void BuildNavMeshSurfaceToParent(float width, float height, float length, GameObject parentObj)
    {
        _navMeshSurface = parentObj.GetComponent<NavMeshSurface>();
        if (_navMeshSurface == null) _navMeshSurface = parentObj.AddComponent<NavMeshSurface>();
        _navMeshSurface.collectObjects = CollectObjects.Volume;
        _navMeshSurface.size = new Vector3(width, height, length);
        _navMeshSurface.center = new Vector3(0, 1, 0);
        if (navLayersToMask.Count != 0)
        {
            _navMeshSurface.layerMask = LayerMask.GetMask(navLayersToMask.ToArray());
        }
        _navMeshSurface.BuildNavMesh();
    }
}
