using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pi_Bar : MonoBehaviour
{
    public float spawnTime = 5;
    public Pi_Stack stack;
    public List<Pi_Bar_Emp> slots = new List<Pi_Bar_Emp>(3);

    private float timeLeft;
    private GameObject newPi;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("Add");
            AddPiece();
            timeLeft = spawnTime;
        }
    }

    private void AddPiece()
    {
        for (int i = 0; i < 3; ++i)
        {
            if (!slots[i].taken)
            {
                if ((newPi = stack.getPiece()) != null)
                {
                    slots[i].taken = true;

                    newPi = Instantiate(newPi, slots[i].getPos(), new Quaternion(0, 0, 0, 0));
                    newPi.transform.SetParent(slots[i].transform);
                    return;
                }
                else
                    return;

            }
        }
        FindObjectOfType<GameEvent>().GameOver();
    }
}
