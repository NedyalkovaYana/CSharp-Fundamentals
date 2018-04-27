using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Interfaces
{
    public interface IMainController
    {
        void AddCharacter(ICharacter character);
        void AddItem(IItem item);
        string PickUpItem(string name);
        string CharacterUseItem(string characterName, string itemName);
        string CharacterUseItemOn(string giverName, string resiverName, string itemName);
        string CharacterGiveItem(string giverName, string resiverName, string itemName);
        string CharacterGetStatus();
        string Attack(string attackerName, string receiverName);
        string Heal(string healerName, string receiverName);
        string EndTurn();
        bool IsGameOver();
    }
}
