using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    float ScanningRadius = 1.5f;

    [SerializeField]
    BallInfo ballInfo;

    state ballState;
    NavMeshAgent agent;
    bool readyToSwitchState = false;
    GameObject toChase = null;

    // Start is called before the first frame update
    private void OnEnable()
    {
        ballInfo = this.GetComponent<BallInfo>();
        agent = this.GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        ballState = state.Scan;
        StartCoroutine(CheckStatus());
    }
    IEnumerator CheckStatus()
    {
        while (true)
        {

            print(ballState);
            switch (ballState)
            {
                case state.Scan:
                    toChase = ScanForEnemy();
                    break;
                case state.Chase:
                    if (toChase == null)
                    {
                        ballState = state.Scan;
                        break;
                    }
                    Seeking(toChase);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1); // WaitUntil(() => readyToSwitchState == true) ||
        }
    }

    GameObject ScanForEnemy()
    {
        readyToSwitchState = false;
        Collider[] touching = Physics.OverlapSphere(this.transform.position, ScanningRadius);

        foreach (Collider touch in touching)
        {
            if (touch.gameObject != this && (touch.gameObject.CompareTag("Enemy") || touch.gameObject.CompareTag("Player")))
            {
                //print(this.gameObject.name + " seeing " + touch.gameObject.name);
                if (touch.GetComponent<BallInfo>().levelNo < ballInfo.levelNo)
                {
                    ballState = state.Chase;
                    readyToSwitchState = true;
                    return touch.gameObject;
                }
            }
        }
        return null;
    }

    void Seeking(GameObject target)
    {
        if (target == null)
        {
            print("target is null");
            return;
        }
        agent.autoRepath = true;
        //if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        //{
        //    ballState = state.Scan;
        //    readyToSwitchState = true;
        //}
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Player"))
            && ballInfo.levelNo > collision.collider.GetComponent<BallInfo>().levelNo)
        {
            ballInfo.UpdateBallsLevel();
            if (collision.collider.CompareTag("Player"))
            {
                collision.collider.GetComponent<PlayerBeh>().OnPlayerDeath();
                Time.timeScale = 0.0f;
                return;
            }
            Destroy(collision.collider.gameObject);
        }
    }

}
public enum state
{
    Scan, Chase
}
