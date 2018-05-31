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
                break;

            case 1:

                transform.Translate(speed * Time.deltaTime, 0f, 0f);

                break;
            case 2:

                transform.Translate(-speed * Time.deltaTime, 0f, 0f);

                break;
            case 3:

                transform.Translate(0f, speed * Time.deltaTime, 0f);

                break;

            case 4:

                transform.Translate(0f, -speed * Time.deltaTime, 0f);

                break;

        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // transform.Translate(0f, 0f, 0f);
    }


}