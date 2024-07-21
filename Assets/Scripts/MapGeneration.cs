using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject Ground;
    [SerializeField]
    Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate() // threshold
    {
        //Vector3 direction = playerPos.position - this.transform.position;
        //print(direction);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 direction = playerPos.position - this.transform.position;
            Vector3 newGRoundPos = this.transform.position;
            if (direction.x > direction.z && direction.x > 16)
            {
                newGRoundPos += new Vector3(50, 0, 0);
            }
            else if (direction.x < -16)
            {
                newGRoundPos += new Vector3(-50, 0, 0);
            }
            else if (direction.z > 16)
            {
                newGRoundPos += new Vector3(0, 0, 50);
            }
            else if (direction.z < -16)
            {
                newGRoundPos += new Vector3(0, 0, -50);
            }
            var ground = GameObject.Instantiate(Ground, newGRoundPos, Quaternion.identity);
        }
    }
}
