﻿using ExtinctionTalesMod.Items.IngotBars;
using ExtinctionTalesMod.Items.Materials;
using ExtinctionTalesMod.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExtinctionTalesMod.Items.Equipment.Armors.ChargedGraniteArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class ChargedGraniteChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Charged Granite Chestplate");
            Tooltip.SetDefault("7% increased damage\n9% increased critical strike chance");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 20;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 12);
            item.defense = 20;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<ChargedGraniteHelmet>() && legs.type == ModContent.ItemType<ChargedGraniteLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.07f;
            player.magicCrit += 8;
            player.meleeCrit += 8;
            player.rangedCrit += 8;
            player.thrownCrit += 8;
            player.GetAssassinPlayer().assassinCrit += 8;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "16% increased magic damage\nReduces mana cost by 20%";
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ChargedGraniteAlloy>(), 20);
            recipe.AddIngredient(ModContent.ItemType<ElementalGraniteCharge>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}