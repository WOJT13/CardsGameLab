using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class displays card and place building model
/// </summary>
public class CardsDisplayer : MonoBehaviour
{
    /// <summary>
    /// Card index
    /// </summary>
    public int index;

    /// <summary>
    /// Card image
    /// </summary>
    public Image cardImgDisplay;

    /// <summary>
    /// Information about first building on grid
    /// </summary>
    public bool isFirst = true;


    void Start()
    {
        Display(index);
    }

    /// <summary>
    /// Method display card
    /// </summary>
    /// <param name="cardIndex"></param>
  
    public void Display(int cardIndex)
    {
        if(cardIndex >=0 && cardIndex < GameBoardController.Instance.cardList.CardCount())
        {
            Card displayedCard = GameBoardController.Instance.cardList.GetCardAtIndex(cardIndex);

            cardImgDisplay.sprite = displayedCard.cardImage;
        }
    }

    /// <summary>
    /// Method used for click on card
    /// </summary>
    public void PlaceOnClick()
    {
        var card = GameBoardController.Instance.cardList.GetAll()[index];
        Vector3 buildingPos = GameBoardController.Instance.coordinatesList.GetFirstElement();
        PlaneSelect plane = FindPlane(buildingPos);
        Debug.Log(plane.isOcccupied);
        if (isFirst)
        {
            Debug.Log(buildingPos);
            GameObject newBuilding = Instantiate(card.buildingModel, buildingPos, Quaternion.identity);
            UnselectPlane(buildingPos);
            plane.isOcccupied = true;

            PlaneSelect[] planes = FindAdjacentPlanes(buildingPos);


            foreach (PlaneSelect neighboplanes in planes)
            {
                neighboplanes.changeColor(Color.blue);
                Vector3 coordinates = neighboplanes.Coordinates;
                GameBoardController.Instance.neigbborList.AddToList(coordinates);
            }
            isFirst = false;
            Debug.Log(GameBoardController.Instance.neigbborList.Count());
        }
        else if (plane != null && GameBoardController.Instance.neigbborList.CheckList(buildingPos))
        {
            Debug.Log(buildingPos);
            GameObject newBuilding = Instantiate(card.buildingModel, buildingPos, Quaternion.identity);
            UnselectPlane(buildingPos);
            plane.isOcccupied = true;
            
            PlaneSelect[] planes = FindAdjacentPlanes(buildingPos);

            
            foreach(PlaneSelect neighboplanes in planes)
            {
                neighboplanes.changeColor(Color.blue);
                Vector3 coordinates = neighboplanes.Coordinates;
                GameBoardController.Instance.neigbborList.AddToList(coordinates);
            }
            Debug.Log(GameBoardController.Instance.neigbborList.Count());
        }
        
    }

    /// <summary>
    /// Method allows unmark plane
    /// </summary>
    /// <param name="coordinates"></param>
    private void UnselectPlane(Vector3 coordinates)
    {
        PlaneSelect[] all = FindObjectsOfType<PlaneSelect>();
        foreach (PlaneSelect plane in all)
        {
            if (plane.isClicked && plane.transform.position == coordinates)
            {
                plane.unselect();
                break;
            }
        }
    }

    /// <summary>
    /// Method finds plane
    /// </summary>
    /// <param name="position"></param>
    /// <returns>Plane</returns>
    private PlaneSelect FindPlane(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        foreach (Collider collider in colliders)
        {
            PlaneSelect plane = collider.GetComponent<PlaneSelect>();
            if (plane != null)
            {
                return plane;
            }
        }
        return null;
    }

    /// <summary>
    /// Method finds buildings neihbor planes
    /// </summary>
    /// <param name="position"></param>
    /// <returns>List of planes</returns>
    private PlaneSelect[] FindAdjacentPlanes(Vector3 position)
    {
        float radius = 10.0f;

        Collider[] colliders = Physics.OverlapSphere(position, radius);

        List<PlaneSelect> adjacentPlanes = new List<PlaneSelect>();

        foreach (Collider collider in colliders)
        {
            PlaneSelect plane = collider.GetComponent<PlaneSelect>();

            if (plane != null && !plane.isOcccupied)
            {
                adjacentPlanes.Add(plane);
            }
        }

        return adjacentPlanes.ToArray();
    }
}
