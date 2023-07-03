using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TI_NET_2023_HeroesVsMonsters.Models.Maps;
using TI_NET_2023_HeroesVsMonsters.Models.Properties.Statistics;

namespace TI_NET_2023_HeroesVsMonsters.Models.Characters
{
    public abstract class Character
    {
        public Action<Character>? DieEvent;
        private int _currentHp; 
        private int _currentMp;
        public Character(string sprite)
        {
            Stats = new Stats();
            Sprite = sprite;
        }
        protected Stats Stats { get; }
        public Position Position { get; set; }
        public string Sprite { get; }
        public int CurrentHp
        {
            get
            {
                return _currentHp;
            }
            set
            {
                _currentHp = value < 0 ? 0 : value > Hp ? Hp : value;
            }
        }
        public int CurrentMp
        {
            get
            {
                return _currentMp;
            }
            set
            {
                _currentMp = value < 0 ? 0 : value > Mp ? Mp : value;
            }
        }
        public int Hp => GetStatValue(StatType.Hp);
        public int Mp => GetStatValue(StatType.Mp);
        public int Strength => GetStatValue(StatType.Strength);
        public int Defence => GetStatValue(StatType.Defence);
        public int Inteligence => GetStatValue(StatType.Inteligence);
        public int Resistance => GetStatValue(StatType.Resistance);
        public int Speed => GetStatValue(StatType.Speed);
        public bool IsAlive => CurrentHp > 0;
        
        public virtual int GetStatValue(StatType stat)
        {
            return Stats[stat];
        }

        public virtual void Attack(Character target)
        {
            if (!target.IsAlive)
            {
                target.DieEvent?.Invoke(this);
            }
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0)
            {
                return;
            }
            _currentHp -= amount;
        }

        public void UseMp(int amount)
        {
            if(amount < 0)
            {
                return;
            }
            _currentMp -= amount;
        }

        public void RegenHp(int amount)
        {
            if (amount < 0)
            {
                return;
            }
            _currentHp += amount;
        }

        public void RegenMp(int amount)
        {
            if(amount < 0)
            {
                return;
            }
            _currentMp += amount;
        }

        public void FullRegen()
        {
            RegenHp(Hp);
            RegenMp(Mp);
        }

        public override string ToString()
        {
            return
                $"Hp : {CurrentHp} / {Hp}\n" +
                $"Mp : {CurrentMp} / {Mp}\n" +
                $"Force : {Strength}\n" +
                $"Defence : {Defence}\n" +
                $"Inteligence : {Inteligence}\n" +
                $"Resistance : {Resistance}\n" +
                $"Vitesse : {Speed}";
        }
    }
}
