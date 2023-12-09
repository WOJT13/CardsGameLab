using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Model
{
  /// <summary>
  /// Enumeration representing playing card symbols (suits).
  /// </summary>
  [System.Serializable]
  public enum Symbol
  {
    /// <summary>
    /// The suit of "Pik" (Spades).
    /// </summary>
    Pik,

    /// <summary>
    /// The suit of "Kier" (Hearts).
    /// </summary>
    Kier,

    /// <summary>
    /// The suit of "Trefl" (Clubs).
    /// </summary>
    Trefl,

    /// <summary>
    /// The suit of "Karo" (Diamonds).
    /// </summary>
    Karo
  }

  /// <summary>
  /// Enumeration representing playing card pictographs (face values).
  /// </summary>
  public enum Pictograph
  {
    /// <summary>
    /// The Ace card.
    /// </summary>
    As,

    /// <summary>
    /// The King card.
    /// </summary>
    Krol,

    /// <summary>
    /// The Queen card.
    /// </summary>
    Dama,

    /// <summary>
    /// The Jack card.
    /// </summary>
    Walet,

    /// <summary>
    /// The number 10 card.
    /// </summary>
    n10,

    /// <summary>
    /// The number 9 card.
    /// </summary>
    n9,

    /// <summary>
    /// The number 8 card.
    /// </summary>
    n8,

    /// <summary>
    /// The number 7 card.
    /// </summary>
    n7,

    /// <summary>
    /// The number 6 card.
    /// </summary>
    n6,

    /// <summary>
    /// The number 5 card.
    /// </summary>
    n5,

    /// <summary>
    /// The number 4 card.
    /// </summary>
    n4,

    /// <summary>
    /// The number 3 card.
    /// </summary>
    n3,

    /// <summary>
    /// The number 2 card.
    /// </summary>
    n2
  }

  /// <summary>
  /// Class represent card
  /// </summary>
  [System.Serializable]
  public class Card
  {
    /// <summary>
    /// ID of card
    /// </summary>
    public int cardID;

    /// <summary>
    /// Symbol of card
    /// </summary>
    [FormerlySerializedAs("symbolCard")]
    public Symbol symbol;

    /// <summary>
    /// Pictograph of card
    /// </summary>
    [FormerlySerializedAs("pictographCard")]
    public Pictograph pictograph;

    /// <summary>
    /// List of card parameters
    /// </summary>
    public List<Parameters> parametersList;

    /// <summary>
    /// Model of building from card
    /// </summary>
    public GameObject buildingModel;

    /// <summary>
    /// Model of card
    /// </summary>
    public GameObject cardModel;

    /// <summary>
    /// List of possible tree locations
    /// </summary>
    public List<Vector3> treeLocations;// Potential locations for trees

    /// <summary>
    /// List of possible fountain locations
    /// </summary>
    public List<Vector3> fountainLocations;// Potential locations for fountains

    public Sprite cardImage;

    public bool isDrawed;
  }
}