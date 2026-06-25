using System;
using Terraria;

namespace ReducedGrinding.Content.Items
{
    internal class ItemHelper
    {
        public static int GetItemRarityFromIngredients(int baseRare, int type, int type2)
        {
            Item dummyItem = new();
            int ingredientRare;
            if (type == 0)
            {
                if (type2 == 0)
                {
                    return 0;
                }
                dummyItem.SetDefaults(type2);
                ingredientRare = dummyItem.rare;
            }
            else
            {
                dummyItem.SetDefaults(type);
                ingredientRare = dummyItem.rare;
                if (type2 != 0)
                {
                    dummyItem.SetDefaults(type2);
                    ingredientRare = Math.Min(ingredientRare, dummyItem.rare);
                }
            }
            return Math.Max(baseRare, ingredientRare);
        }

        public static int GetItemValueFromIngredients(int baseValue, int type, int type2, int stack)
        {
            Item dummyItem = new();
            int ingredientValue;
            if (type == 0)
            {
                if (type2 == 0)
                {
                    return baseValue;
                }
                dummyItem.SetDefaults(type2);
                ingredientValue = dummyItem.value;
            }
            else
            {
                dummyItem.SetDefaults(type);
                ingredientValue = dummyItem.value;
                if (type2 != 0)
                {
                    dummyItem.SetDefaults(type2);
                    ingredientValue = Math.Min(ingredientValue, dummyItem.value);
                }
            }
            return baseValue + ingredientValue * stack;
        }
    }
}
