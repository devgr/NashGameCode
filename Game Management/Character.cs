/*
File: Character.cs
Author: Jason Foley
Updated: 11/10/2015

Description: 
Set of classes showing how to organize characters for an RPG game.
Note the good use of encapsulation between the GameSession class and the Character class.
Only the necessary functions are provided for working with characters, and each
character's energy, health, etc belongs to that character.
*/

public struct Location
{
    public int x;
    public int y;
    public int z;
}

public class Character
{
     protected short m_Energy;
     protected short m_Health; //do you really need more than 32,767 health?
     protected unsigned int XP;
     protected unsigned char level; //255 max level?
     public Location spawnPoint;
     public Location currentPosition;

     protected int Str;
     protected int Agi;
     protected int Dex;
     protected int Int;

     protected Character()
     {
         //default constructor - do not use to promote use of Create()
     }
     public static Character Create(int level)
     {
         var toReturn = new Character();
         //todo set stats from an algorithm here.

        return toReturn;
     }
     public static Character Create(int level, Location spawnPoint)
     {
         var toReturn = new Character();
         toReturn.spawnPoint = spawnPoint;
         toReturn.currentPosition = spawnPoint;
         //todo set stats from an algorithm here.
        return toReturn;
     }
     public bool IsAlive()
     {
        return this.m_Health > 0;
     }
    public void ApplyDamage(int damageAmt)
    {
       int healthReduction = 0;
       //calculate true damage from stats
       //todo implement items, effects, and armor classes
       this.m_Health -= healthReduction;
    }
}


public class GameSession : MonoBehavior
{
       public static List<Character> charactersInGame;
       public static List<Character> LivingCharacters
       {
          get
          {
              //lambdas are cool - save a ton of time
              return (from chars in charactersInGame where chars.IsAlive() select chars.ToList());
          };
          private: set;
       }
}