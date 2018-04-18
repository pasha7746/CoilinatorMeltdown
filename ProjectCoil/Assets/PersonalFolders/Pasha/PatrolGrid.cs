using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PatrolGrid : MonoBehaviour ,ICheckForUnsafeChanges
{
    /// <summary>
    /// builder
    /// </summary>
    public bool resetPosition = true;
    public bool resetScale = true;
    public bool resetRotation = true;









#if UNITY_EDITOR
    [ContextMenu("Apply Bulk Prefab Apply")]
    public void CheckForUnsafeChanges()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;

            if (PrefabUtility.GetPrefabParent(go) != null)
            {
                Vector3 pos = go.transform.localPosition;
                Vector3 scale = go.transform.localScale;
                Quaternion rot = go.transform.localRotation;

                if (resetPosition) go.transform.localPosition = Vector3.zero;
                if (resetScale) go.transform.localScale = Vector3.one;
                if (resetRotation) go.transform.localRotation = Quaternion.identity;

                {
                    MonoBehaviour[] behaviours = go.GetComponents<MonoBehaviour>();
                    foreach (MonoBehaviour b in behaviours)
                        if (b is ICheckForUnsafeChanges)
                            (b as ICheckForUnsafeChanges).CheckForUnsafeChanges();
                }

                Debug.Log("Applying changes to " + go.name, go);
                PrefabUtility.ReplacePrefab(go, PrefabUtility.GetPrefabParent(go), ReplacePrefabOptions.ConnectToPrefab);

                if (resetPosition) go.transform.localPosition = pos;
                if (resetScale) go.transform.localScale = scale;
                if (resetRotation) go.transform.localRotation = rot;
            }
        }
    }
#endif
}
public interface ICheckForUnsafeChanges
{
#if UNITY_EDITOR
    void CheckForUnsafeChanges();
#endif


}
