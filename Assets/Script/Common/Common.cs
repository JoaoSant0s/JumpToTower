using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public static class Common {

	public enum TAGS{
		Player
	}

	public enum LEVEL{
		Level1,
		Level2,
		Level3,
		Level4,
		Level5 ,
        endGame
	}

    public static void DestroyChildren(Transform currentTransform) {
        for(var child = 0; child < currentTransform.childCount; child++) {
            var childTransform = currentTransform.GetChild(child);
            GameObject.DestroyObject(childTransform.gameObject);
        }
    }

    public static bool IsPlayer(Collider player) {
        return player.gameObject.tag.Equals(TAGS.Player.ToString());
    }

    public static List<T> Clone<T>(this IList<T> listToClone) where T : ICloneable {
        return listToClone.Select(item => (T)item.Clone()).ToList();
    }

    public static void TimeZone(bool isActive) {
        Time.timeScale = (!isActive)? 1f: 0f;
    }
}
