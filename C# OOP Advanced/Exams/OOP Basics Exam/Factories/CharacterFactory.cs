using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Exceptions;
using DungeonsAndCodeWizards.Interfaces;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory : ICharacterFactory
    {
        private Type[] charactersTypes;

        public CharacterFactory()
        {
            this.charactersTypes = new TypeCollector().
                                       GetAllInheritingTypes<ICharacter>();
        }

        public ICharacter CreateCharacter(IList<string> args)
        {
            var targetType = this.charactersTypes
                .FirstOrDefault(t => t.Name.Equals(args[1]));

            if (targetType == null)
            {
                throw new ArgumentException(String.Format(
                    Messages.InvalidCharacterType, args[2]));
            }

            var faction = args[0];
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
            var characterName = args[2];
            

            return (ICharacter)Activator.CreateInstance(targetType, characterName, parsedFaction);
        }
    }
}
