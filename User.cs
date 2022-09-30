using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class User
{
    public User(string name)
    {
        userName = name;
        userExp = 0;
        userLvl = 1;
        coins = 0;
        diamonds = 0;
        characters = new List<Character>();
        inventory = new List<Item>();
    }

    public string userName;
    public int userExp;
    public int userLvl;
    public int coins;
    public int diamonds;

    //Historial battles
    public List<Character> characters;
    public List<Item> inventory;

}
