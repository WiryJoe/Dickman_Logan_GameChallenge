using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dickman_Logan_GameChallenge
{
    public class Character
    {
        //@Shawn, @Sean, @Brian - got lazy here and don't want to change to comments - Murphy
        protected string name = "Default";
        protected float HPMax = 10;
        protected float HP = 10;
        protected float Strength = 3;
        protected float Mana = 10;
        protected float Defense = 0;
        protected string Trinket;
        protected string Ability;

        public void SetMana(float NewMana)
        {
            Mana = NewMana;
        }

        public void SetTrinket(String NewTrinket)
        {
            Trinket = NewTrinket;
        }

        public void SetAbility(String NewAbility)
        {
            Ability = NewAbility;
        }

        public void SetDefense(float NewDefense)
        {
            Defense = NewDefense;
        }

        public void SetName(string NewName)
        {
            name = NewName;
        }

        public void SetHealth(int NewHealth)
        {
            HPMax = NewHealth;
            HP = NewHealth;
        }

        public void FortifyHealth(int NewHealth)
        {
            HPMax += NewHealth;
            HP += NewHealth;
        }

        public void FortifyMana(int NewMana)
        {
            Mana += NewMana;
        }
        public void FortifyStrength(int NewStrength)
        {
            Strength += NewStrength;
        }

        public void SetStrength(int NewStrength)
        {
            Strength = NewStrength;
        }

        public float GetDefense()
        {
            return Defense;
        }

        public string GetTrinket()
        {
            return Trinket;
        }

        public string GetAbility()
        {
            return Ability;
        }

        public string Name()
        {
            return name;
        }


        // Accessor/Getter for the current hit points
        public float GetHP()
        {
            return HP;
        }
        public float HPmax()
        {
            return HPMax;
        }

        // Accessor/Getter for the attack points
        public float GetStrength()
        {
            return Strength;
        }

        // Modifying the health by subtracting the damage passed in
        public void ApplyDamage(float damage)
        {
            damage -= Defense;
            HP -= damage;
            HP = MathF.Max(0, HP); //prevents health below 0
        }
        public void HealApplyDamage(float damage)
        {
            HP -= damage;
            HP = MathF.Max(0, HP); //prevents health below 0
        }

        public float GetMana()
        {
            return Mana;
        }

        public void LoseMana(int _cost)
        {
            Mana -= _cost;
            Mana = MathF.Max(0, Mana);
        }

        // Prints the different stats in a readable output, changes color to 
        // green when full health, yellow for damaged, and black for dead
        public void PrintStats()
        {
            string output = "";
            output += name;
            output += " HP:" + HP;
            output += " Strength:" + Strength;
            output += " Mana:" + Mana;
            output += "\nDefense:" + Defense;
            output += " Trinket:" + Trinket;
            output += " Ability:" + Ability;

            //end the line after each character
            output += "\n";
            // change background color based on health
            if (HP == HPMax)//full health
                Console.ForegroundColor = ConsoleColor.Green;
            else if (HP > 0)// partial health
                Console.ForegroundColor = ConsoleColor.Yellow;
            else// no health
                Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write(output);
            //reset color after
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintEnemy()
        {
            string output = "";
            output += name;
            output += " HP:" + HP;
            output += " Strength:" + Strength;
            output += " Mana:" + Mana;
            output += "\nDefense:" + Defense;
            output += " Ability:" + Ability;

            //end the line after each character
            output += "\n";
            // change background color based on health
            if (HP == HPMax)//full health
                Console.ForegroundColor = ConsoleColor.Green;
            else if (HP > 0)// partial health
                Console.ForegroundColor = ConsoleColor.Yellow;
            else// no health
                Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write(output);
            //reset color after
            Console.ForegroundColor = ConsoleColor.White;
        }


        //virtual so children can override
        public virtual ConsoleColor GetTeamColor()
        {
            return ConsoleColor.Black;
        }

    }

    public class Player : Character
    {
        //Override with the player's team color
        public override ConsoleColor GetTeamColor()
        {
            return ConsoleColor.Blue;
        }

        // overloaded constructor
        public Player(string _n, float _HP, float _A, float _M, float _D, string _T, string _AB)
        {
            name = _n;
            HPMax = _HP;
            HP = HPMax;
            Strength = _A;
            Mana = _M;
            Defense = _D;
            Trinket = _T;
            Ability = _AB;
        }
    }

    public class Enemy : Character
    {
        public override ConsoleColor GetTeamColor()
        {
            return ConsoleColor.DarkRed;
        }

        // overloaded constructor
        public Enemy(string _n, float _HP, float _A, float _M, float _D, string _AB)
        {
            name = _n;
            HPMax = _HP;
            HP = HPMax;
            Strength = _A;
            Mana = _M;
            Defense = _D;
            Ability = _AB;
        }
    }
}
