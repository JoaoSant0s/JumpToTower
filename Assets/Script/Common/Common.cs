using UnityEngine;
using System.Collections;

public class Common {

	public enum TAGS{
		Player
	}

	public enum LEVEL{
		Level1,
		Level2,
		Level3,
		Level4,
		Level5
	}

    public static bool IsPlayer(Collider player) {
        return player.gameObject.tag.Equals(TAGS.Player.ToString());
    }
}
