using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class BallInfo : MonoBehaviour
{
    public int levelNo;
    [SerializeField]
    Material material;
    [SerializeField]
    TextMeshProUGUI LevelIndicator;

    // Start is called before the first frame update
    void Start()
    {
        if (material != null)
        {
            material.color = UnityEngine.Random.ColorHSV();
            this.GetComponent<Renderer>().material = material;
        }

        if (levelNo == 0)
        {
            levelNo = UnityEngine.Random.Range(1, 6);
            LevelIndicator.text = "Level " + levelNo;
            if (this.GetComponent<NavMeshAgent>() != null)
            {
                this.GetComponent<NavMeshAgent>().speed = levelNo / 10.0f + 0.2f;
            }
        }
        else
        {
            LevelIndicator.text = "Level " + levelNo;
        }
    }

    public void UpdateBallsLevel()
    {
        this.levelNo++;
        this.transform.localScale *= 1.1f;
        LevelIndicator.text = "Level " + levelNo;
        if (this.GetComponent<NavMeshAgent>() != null)
        {
            this.GetComponent<NavMeshAgent>().speed *= 1.5f;
        }
    }
}
