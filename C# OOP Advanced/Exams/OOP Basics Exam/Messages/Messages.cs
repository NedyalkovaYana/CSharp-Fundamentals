using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Exceptions
{
    public static class Messages
    {
        public const string ExceptionMessegeForWrongName = "Name cannot be null or whitespace!";

        public const string MustBeAliveMessage = "Must be alive to perform this action!";

        public const string CannotAttackSelf = "Invalid Operation: Cannot attack self!";

        public const string FrendlyFireMessage = "Friendly fire! Both characters are from {0} faction!";

        public const string CannotHealEnemy = "Cannot heal enemy character!";

        public const string BagIsFull = "Bag is full!";

        public const string BagIsEmpty = "Bag is empty!";

        public const string NoExistingNameInABag = "Invalid Operation: No item with name {0} in bag!";

        public const string InvalidCharacterType = "Invalid character type \"{0}\"!";

        public const string InvalidItemType = "Invalid item type \"{0}\"!";

        public const string InvalidFaction = "Invalid faction \"{0}\"!";

        public const string SucsessfullAddToParty = "{0} joined the party!";

        public const string InvalidItemName = "Invalid item \"{0}\"!";

        public const string AddItemToPool = "{0} added to pool.";

        public const string CharacterNameNotFound = "Parameter Error: Character {0} not found!";

        public const string NoItemsLeftInPool = "Invalid Operation: No items left in pool!";

        public const string PickedUPItem = "{0} picked up {1}!";

        public const string UseItemMessage = "{0} used {1}.";

        public const string ItemUseOnMessage = "{0} used {1} on {2}";

        public const string GiveCharacterItem = "{0} gave {1} {2}.";

        public const string CharacterToString =
            "{0} - HP: {1}/{2}, AP: {3}/{4}, Status: {5}";

        public const string AttackerCannotAttack = "{0} cannot attack!";

        public const string AfterAttackingMessage =
            "{0} attacks {1} for {2} hit points! " +
            "{3} has {4}/{5} HP and " +
            "{6}/{7} AP left!";

        public const string MessageIfCharacterAttackIsDead = "{0} is dead!";

        public const string CharacterCannotHeal = "{0} cannot heal!";

        public const string SuccessfullHealMessage =
            "{0} heals {1} for {2}! " +
            "{3} has {4} health now!";

        public const string EndTurnMessage = "{0} rests ({1} => {2})";
    }
}
