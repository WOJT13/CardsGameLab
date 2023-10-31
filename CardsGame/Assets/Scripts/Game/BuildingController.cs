using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public List<ParameterWithPoints> points = new List<ParameterWithPoints>(); // Points to be subtracted when this object is destroyed
    public Vector2Int coordinates = new Vector2Int();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    OnMouseDown();
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (GameBoardController.Instance.canDestroy == true && GameBoardController.Instance.bombsLeft > 0)
        {
            GameBoardController.Instance.coordinatesList.RemoveFromList(coordinates);

            GameBoardController.Instance.bombsLeft--;

            foreach (var parameter in points)
            {
                var parameterToUpdate = PointsManager.Instance.Parameters.Find(p => p.name == parameter.name);

                if (parameterToUpdate != null)
                {
                    parameterToUpdate.points -= parameter.points;
                }
            }

            Destroy(gameObject);
        }
    }
}
