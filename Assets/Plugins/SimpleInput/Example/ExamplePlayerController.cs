using UnityEngine;

public class ExamplePlayerController : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public float speed;


    private float inputHorizontal;
    private float inputVertical;
    private int direction = 0;
    private Vector2 movement;

    void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        //check input
        inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        inputVertical = SimpleInput.GetAxis(verticalAxis);

        if (inputHorizontal > 0)
        { direction = 1; };

        if (inputHorizontal < 0)
        { direction = 2; };

        if (inputVertical > 0)
        { direction = 3; };

        if (inputVertical < 0)
        { direction = 4; };
        if (inputHorizontal == inputVertical)
        {
            direction = 0;
        }

        //1 = right 2 = left 3 = up 4 = down

        switch (direction)
        {
            case 0:
                return;
                break;

            case 1:

                movement = (Vector2)transform.position + (Vector2.right * Time.deltaTime * 10);

                break;
            case 2:

                movement = (Vector2)transform.position + (Vector2.left * Time.deltaTime * 10);

                break;
            case 3:

                movement = (Vector2)transform.position + (Vector2.up * Time.deltaTime * 10);

                break;

            case 4:

                movement = (Vector2)transform.position + (Vector2.down * Time.deltaTime * 10);

                break;

        }

        transform.position = Vector2.MoveTowards(transform.position, movement, speed);
        

    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // transform.Translate(0f, 0f, 0f);
    }


}