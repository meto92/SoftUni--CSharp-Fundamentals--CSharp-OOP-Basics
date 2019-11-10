using System;
using System.Linq;
using System.Reflection;

using DungeonsAndCodeWizards.Attributes;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Core.Factories
{
    public class ItemFactory
    {
        private const string InvalidItemTypeExceptionMessage = @"Invalid item ""{0}""!";

        public Item CreateItem(string type)
        {
            Type itemType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.CustomAttributes.Any(a => a.AttributeType == typeof(ItemAttribute)) &&
                    t.Name == type);

            if (itemType == null)
            {
                throw new ArgumentException(string.Format(
                    InvalidItemTypeExceptionMessage,
                    type));
            }

            Item item = (Item) Activator.CreateInstance(itemType);

            return item;
        }
    }
}