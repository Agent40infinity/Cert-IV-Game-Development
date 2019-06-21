//in this script  you will only need using UnityEngine as we just need the script to connect to unity
using UnityEngine;
//this public class doent inherit from MonoBehaviour
//this script is also referenced by other scripts but never attached to anything
public class Item
{
    //basic variables for items that we need are 
    #region Private Variables
    private int _id; //Identification Number
    private string _name; //Object Name
    private int _value; //Value of the Object
    private string _description; //Description of what the Object is
    private Texture2D _icon; //Icon that displays when that Object is in an Inventory
    private GameObject _mesh;//Mesh of that object when it is equipt or in the world
    private ItemType _type; //Enum ItemType which is the Type of object so we can classify them
    private int _heal;
    private int _damage;
    private int _armour;
    private int _amount;
    #endregion
    #region Constructors
    //A constructor is a bit of code that allows you to create objects from a class. You call the constructor by using the keyword new 
	//followed by the name of the class, followed by any necessary parameters.
    //the Item needs Identification Number, Object Name, Icon and Type
        //here we connect the parameters with the item variables
    #endregion
    #region Public Variables
    //here we are creating the public versions or our private variables that we can reference and connect to when interacting with items
    public int ID //public Identification Number 
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name //public Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Value //public Value 
    {
        get { return _value; }
        set { _value = value; }
    }
    public string Description //public Description 
    {
        get { return _description; }
        set { _description = value; }
    }
    public Texture2D Icon //public Icon 
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject Mesh //public Mesh 
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public ItemType Type //public Type 
    {
        get { return _type; }
        set { _type = value; }
    }
    public int Heal //public Name
    {
        get { return _heal ; }
        set { _heal = value; }
    }
    public int Damage //public Identification Number 
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int Armour //public Name
    {
        get { return _armour; }
        set { _armour = value; }
    }
    public int Amount //public Name
    {
        get { return _amount; }
        set { _amount = value; }
    }
    #endregion
}
#region Enums
public enum ItemType //The Global Enum ItemType that we have created categories in
{
    Food,
    Weapon,
    Apparel,
    Crafting,
    Quest,
    Money,
    Ingredient,
    Potion,
    Scroll
}
#endregion
