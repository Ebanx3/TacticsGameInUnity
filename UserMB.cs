using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserMB : MonoBehaviour
{
    [SerializeField] private string userName;
    [SerializeField] private int userExp = 0;
    [SerializeField] private int userLvl = 0;
    [SerializeField] private int coins = 0;
    [SerializeField] private int diamonds = 0;
    [SerializeField] private List<Character> characters = new List<Character>();
    [SerializeField] private List<Item> inventory = new List<Item>();

    public string GetUsername()
    {
        return userName;
    }

    public int GetUserExp()
    {
        return userExp;
    }

    public int GetUserLvl()
    {
        return userLvl;
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetDiamonds()
    {
        return diamonds;
    }

    public List<Character> GetCharacters()
    {
        return characters;
    }

    public List<Item> GetInventory()
    {
        return inventory;
    }

    public void SetUserName(string s)
    {
        userName = s;
    }

    public void SetUserExp(int cant)
    {
        userExp += cant;
        SetUserLvl();
    }

    private void SetUserLvl()
    {
        userLvl = Exp.LvlByExp(userExp);
    }

    public void SetCoins(int cant)
    {
        coins += cant;
    }

    public void SetDiamonds(int cant)
    {
        diamonds += cant;
    }

    public void AddCharacter(Character character)
    {
        character.positionIntoUserList = characters.Count;
        characters.Add(character);
    }

    //RemoveCharacter

    public void SortCharactersByPosition()
    {
        characters.OrderBy(ch => ch.positionIntoUserList);
    }
}
