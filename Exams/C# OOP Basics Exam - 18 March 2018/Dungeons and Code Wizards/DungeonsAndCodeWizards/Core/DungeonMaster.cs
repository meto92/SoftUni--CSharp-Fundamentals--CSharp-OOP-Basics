using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using DungeonsAndCodeWizards.Core.Factories;
using DungeonsAndCodeWizards.Interfaces;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private const string JoinedCharacterMessage = "{0} joined the party!";
        private const string AddedItemMessage = "{0} added to pool.";
        private const string CharacterNotFoundExceptionMessage = "Character {0} not found!";
        private const string EmptyPoolMessage = "No items left in pool!";
        private const string PickedUpItemMessage = "{0} picked up {1}!";

        private Dictionary<string, Character> characterByName;
        private Stack<Item> items;
        private int lastSurvivorRounds;
        private Character prevSurvivor;
        private Character lastSurvivor;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.characterByName = new Dictionary<string, Character>();
            this.items = new Stack<Item>();
            this.lastSurvivorRounds = 0;
            this.prevSurvivor = null;
            this.lastSurvivor = null;
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characterByName[name] = character;

            return string.Format(JoinedCharacterMessage, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.items.Push(item);

            return string.Format(AddedItemMessage, itemName);
        }

        private Character GetCharacter(string characterName)
        {
            if (!this.characterByName.TryGetValue(characterName, out Character character))
            {
                throw new ArgumentException(string.Format(
                    CharacterNotFoundExceptionMessage,
                    characterName));
            }

            return character;
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(EmptyPoolMessage);
            }

            Item item = this.items.Pop();

            character.Bag.AddItem(item);

            return string.Format(PickedUpItemMessage, characterName, item.Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = GetCharacter(characterName);
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }       

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.GetCharacter(giverName);
            Character receiver = this.GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.GetCharacter(giverName);
            Character receiver = this.GetCharacter(receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            IEnumerable<Character> characters = this.characterByName.Values
                .OrderByDescending(character => character.IsAlive)
                .ThenByDescending(character => character.Health);

            string result = string.Join(Environment.NewLine, characters);

            return result;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.GetCharacter(attackerName);
            Character receiver = this.GetCharacter(receiverName);

            if (!attacker.GetType()
                .GetInterfaces()
                .Contains(typeof(IAttackable)))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            IAttackable attackableCharacter = (IAttackable) attacker;

            attackableCharacter.Attack(receiver);

            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0} attacks {1} for {2} hit points! {1} has {3}/{4} HP and {5}/{6} AP left!{7}",
                attackerName,
                receiverName,
                attacker.AbilityPoints,
                receiver.Health,
                receiver.BaseHealth,
                receiver.Armor,
                receiver.BaseArmor,
                Environment.NewLine);

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiverName} is dead!");
            }

            return result.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.GetCharacter(healerName);
            Character healingReceiver = this.GetCharacter(healingReceiverName);

            if (!healer.GetType()
                .GetInterfaces()
                .Contains(typeof(IHealable)))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            IHealable healableCharacter = (IHealable) healer;

            healableCharacter.Heal(healingReceiver);

            string result = string.Format("{0} heals {1} for {2}! {3} has {4} health now!",
                healer.Name,
                healingReceiverName,
                healer.AbilityPoints,
                healingReceiverName,
                healingReceiver.Health);

            return result;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder result = new StringBuilder();

            IEnumerable<Character> aliveCharacters = this.characterByName
                .Values
                .Where(c => c.IsAlive);

            foreach (Character character in aliveCharacters)
            {
                double healthBeforeRest = character.Health;

                character.Rest();

                result.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (aliveCharacters.Count() <= 1)
            {
                this.lastSurvivorRounds++;

                if (aliveCharacters.Count() == 1)
                {
                    this.prevSurvivor = this.lastSurvivor;
                    this.lastSurvivor = aliveCharacters.First();
                }
            }

            return result.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return
                this.lastSurvivorRounds > 0 &&
                this.prevSurvivor == this.lastSurvivor;
        }
    }
}