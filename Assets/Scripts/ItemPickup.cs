using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
        ItemA,
        ItemB,
        ItemC
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombControllerUI>().AddBomb();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombControllerUI>().explosionRadius++;
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<JoystickAnimateV2>().speed++;
                break;
            
            case ItemType.ItemA: //Decrease Speed
                player.GetComponent<JoystickAnimateV2>().speed--;
                break;
            
            case ItemType.ItemB: //Speedx2
                player.GetComponent<JoystickAnimateV2>().speed*=2;
                break;

            case ItemType.ItemC: //Freeze for 3 secs
                player.GetComponent<JoystickAnimateV2>().Freeze();
                break;

        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            OnItemPickup(other.gameObject);
        }
    }
}
