using System;
using System.Linq;
using System.Reflection;

using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Core.Enums;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Core.Factories
{
    public class CharacterFactory
    {
        private const string InvalidFactionExceptionMessage = @"Invalid faction ""{0}""!";
        private const string InvalidCharacterTypeExceptionMessage = @"Invalid character type ""{0}""!";

        public Character CreateCharacter(string factionStr, string type, string name)
        {
            if (!Enum.TryParse(typeof(Faction), factionStr, out object faction))
            {
                throw new ArgumentException(string.Format(
                    InvalidFactionExceptionMessage,
                    factionStr));
            }

            Type characterType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.CustomAttributes
                    .Any(a => a.AttributeType == typeof(CharacterAttribute)) &&
                        t.Name == type);

            if (characterType == null)
            {
                throw new ArgumentException(string.Format(
                    InvalidCharacterTypeExceptionMessage, type));
            }

            Character character = (Character) Activator.CreateInstance(characterType, name, (Faction) faction);

            return character;
        }
    }
}