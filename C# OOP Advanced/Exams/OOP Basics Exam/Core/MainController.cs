using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Core
{
    public class MainController : IMainController
    {
        private List<ICharacter> characters;
        private Stack<IItem> items;
        private int lastSurvivorRound;
        public MainController()
        {
            this.items = new Stack<IItem>();
            this.characters = new List<ICharacter>();
        }

        public void AddCharacter(ICharacter character)
        {
            this.characters.Add(character);
        }

        public void AddItem(IItem item)
        {
            this.items.Push(item);
        }

        public string PickUpItem(string name)
        {
            try
            {
                var findingCharacter = characters.FirstOrDefault(c => c.Name == name);

                if (findingCharacter == null)
                {
                    throw new ArgumentException(String.Format(Messages.CharacterNameNotFound, name));
                }
                if (items.Count == 0)
                {
                    throw new InvalidOperationException(Messages.NoItemsLeftInPool);
                }

                var item = items.Pop();
                var itemName = item.GetType().Name;
                findingCharacter.ReceiveItem(item);

                return String.Format(Messages.PickedUPItem, name, itemName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }           
        }

        public string CharacterUseItem(string characterName, string itemName)
        {
            try
            {
                var findedCharacter = characters.FirstOrDefault(f => f.Name == characterName);

                if (findedCharacter == null)
                {
                    throw new ArgumentException(String.Format(Messages.CharacterNameNotFound, characterName));
                }

                var findedItem = findedCharacter.Bag.GetItem(itemName);
                findedCharacter.UseItem(findedItem);

                return string.Format(Messages.UseItemMessage, characterName, itemName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CharacterUseItemOn(string giverName, string resiverName, string itemName)
        {
            try
            {
                var giverCharacter = characters.FirstOrDefault(c => c.Name == giverName);
                if (giverCharacter == null)
                {
                    throw new ArgumentException(String.Format(Messages.CharacterNameNotFound, giverName));
                }

                var reciverCharacter = characters.FirstOrDefault(c => c.Name == resiverName);
                if (reciverCharacter == null)
                {
                    throw new ArgumentException(String.Format(Messages.CharacterNameNotFound, resiverName));
                }

                if (giverCharacter.Bag.Items.Count == 0)
                {
                    return Messages.BagIsEmpty;
                }

                var item = giverCharacter.Bag.Items.FirstOrDefault(f => f.GetType().Name == itemName);

                if (item == null)
                {
                    return $"No found item - {itemName}";
                }

                giverCharacter.UseItemOn(item, reciverCharacter);

                return string.Format(Messages.ItemUseOnMessage, giverName, itemName, resiverName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CharacterGiveItem(string giverName, string resiverName, string itemName)
        {
            try
            {
                var giverCharacter = characters.FirstOrDefault(c => c.Name == giverName);
                if (giverCharacter == null)
                {
                    throw new ArgumentException(String.Format(Messages.CharacterNameNotFound, giverName));
                }

                var reciverCharacter = characters.FirstOrDefault(c => c.Name == resiverName);
                if (reciverCharacter == null)
                {
                    throw new ArgumentException(String.Format(Messages.CharacterNameNotFound, resiverName));
                }

                if (giverCharacter.Bag.Items.Count == 0)
                {
                    return Messages.BagIsEmpty;
                }

                var item = giverCharacter.Bag.Items.FirstOrDefault(f => f.GetType().Name == itemName);

               giverCharacter.GiveCharacterItem(item, reciverCharacter);

                return string.Format(Messages.GiveCharacterItem, giverName, resiverName, itemName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string CharacterGetStatus()
        {
            var sb = new StringBuilder();
            var sortedCharacters = characters.OrderByDescending(c => c.IsAlive == true)
                .ThenByDescending(s => s.Health);

            foreach (var character in sortedCharacters)
            {
                sb.AppendLine(character.CharacterToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string attackerName, string receiverName)
        {
            try
            {
                var sb = new StringBuilder();
                var attacker = characters.FirstOrDefault(a => a.Name == attackerName);

                if (attacker == null)
                {
                    throw new ArgumentException(String.Format
                        (Messages.CharacterNameNotFound, attackerName));
                }

                var receiver = characters.FirstOrDefault(r => r.Name == receiverName);

                if (receiver == null)
                {
                    throw new ArgumentException(String.Format
                        (Messages.CharacterNameNotFound, receiver.Name));
                }

                if (!(attacker is IAttackable attackingCharacter))
                {
                    throw new ArgumentException(Messages.AttackerCannotAttack, attackerName);
                }

                attackingCharacter.Attack(receiver);

                sb.AppendLine(string.Format(Messages.AfterAttackingMessage, attackerName, receiverName,
                    attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth,
                    receiver.Armor, receiver.BaseArmor));

                if (receiver.IsAlive == false)
                {
                    sb.AppendLine(String.Format
                        (Messages.MessageIfCharacterAttackIsDead, receiverName));
                }

                return sb.ToString().Trim();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Heal(string healerName, string receiverName)
        {
            var healer = characters.FirstOrDefault(h => h.Name == healerName);
            if (healer == null)
            {
                throw new ArgumentException(String.Format
                    (Messages.CharacterNameNotFound, healerName));
            }

            var receiver = characters.FirstOrDefault(r => r.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(String.Format
                    (Messages.CharacterNameNotFound, receiverName));
            }

            if (!(healer is IHealable healableCharacter))
            {
                throw new ArgumentException(string.Format(
                    Messages.CharacterCannotHeal, healerName));
            }

            healableCharacter.Heal(receiver);

            return string.Format(Messages.SuccessfullHealMessage, healerName, receiverName,
                healer.AbilityPoints, receiverName, receiver.Health);
        }

        public string EndTurn()
        {
            var sb = new StringBuilder();
            var aliveChars = characters.Where(c => c.IsAlive == true).ToList();

            foreach (var character in aliveChars)
            {
                var previousHealth = character.Health;
                character.Rest();

                var currentHealth = character.Health;
                sb.AppendLine(string.Format(Messages.EndTurnMessage, character.Name,
                    previousHealth, currentHealth));
            }

            if (aliveChars.Count <= 1)
            {
                this.lastSurvivorRound++;
                
            }
            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            var oneOrZeroSurvivorsLeft = this.characters.Count(c => c.IsAlive == true) <= 1;
            var lastSurviverSurvivedTooLong = this.lastSurvivorRound > 1;

            return oneOrZeroSurvivorsLeft && lastSurviverSurvivedTooLong;
        }
    }
}
