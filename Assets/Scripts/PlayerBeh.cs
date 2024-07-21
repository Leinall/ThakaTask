using UnityEngine;

public class PlayerBeh : MonoBehaviour
{
    [SerializeField]
    FeedbackUIHandler UIhandler;

    BallInfo ballInfo;

    private void OnEnable()
    {
        ballInfo = GetComponent<BallInfo>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy")
            && ballInfo.levelNo >= collision.collider.GetComponent<BallInfo>().levelNo)
        {
            print("player is hitting");
            ballInfo.UpdateBallsLevel();
            Destroy(collision.collider.gameObject);
        }
    }

    public void OnPlayerDeath()
    {
        UIhandler.OnPlayerLose();
    }
}
