using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    float xVelocity;
    float zVelocity;

    bool buttonUpisClicked;
    bool buttonDownisClicked;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            LeftMove();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RightMove();
        }
        else if (Input.GetKey(KeyCode.UpArrow) || buttonUpisClicked)
        {
            UpMove();
        }
        else if (Input.GetKey(KeyCode.DownArrow) || buttonDownisClicked)
        {
            DownMove();
        }
        else
        {
            zVelocity = 0;
        }


        transform.position += zVelocity * this.transform.forward * Time.deltaTime;
    }

    public void LeftMove()
    {
        //xVelocity = moveSpeed;
        transform.Rotate(0, -moveSpeed / 4, 0);
    }
    public void RightMove()
    {
        //xVelocity = moveSpeed;
        transform.Rotate(0, moveSpeed / 4, 0);
    }
    public void DownMove()
    {
        //print("down");
        zVelocity = -1 * moveSpeed;
    }
    public void UpMove()
    {
        //print("Up");
        zVelocity = 1 * moveSpeed;
    }

    public void UpButtonIsClicked()
    {
        buttonUpisClicked = true;
    }
    public void UpButtonIsUnClicked()
    {
        buttonUpisClicked = false;
    }
    public void DownButtonIsClicked()
    {
        buttonDownisClicked = true;
    }
    public void DownButtonIsUnClicked()
    {
        buttonDownisClicked = false;
    }

}
