using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GameObjectExtensions
{
    public static GameObject GetParentObject(this GameObject child, string target)
    {
        Transform currentParent = child.transform.parent;

        while (currentParent != null)
        {
            if (currentParent.name == target)
            {
                return currentParent.gameObject;
            }
            currentParent = currentParent.parent;
        }

        ErrorLogs.LogErrorInConsole($"Could not locate Gameobject \"{target}\" in scene", LogTypes.Error);

        return null;
    }

    public static GameObject FindChildByName(this GameObject parent, string childName)
    {
        GameObject target = parent.transform
            .DescendantsAndSelf() // Get all descendants and the parent itself
            .FirstOrDefault(t => t.name == childName)?.gameObject;

        if (target == null) 
            ErrorLogs.LogErrorInConsole($"Could not locate button \"{childName}\" in {parent.name}", LogTypes.Error);

        return target;
    }

    public static IEnumerable<Transform> DescendantsAndSelf(this Transform parent)
    {
        yield return parent; // Include the parent itself

        foreach (Transform child in parent)
        {
            yield return child;
            foreach (Transform grandChild in child.DescendantsAndSelf())
            {
                yield return grandChild;
            }
        }
    }
}