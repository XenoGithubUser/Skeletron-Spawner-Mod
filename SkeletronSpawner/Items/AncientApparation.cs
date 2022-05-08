using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SkeletronSpawner.Items
{
    public class AncientApparation : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Not Consumable\nSummons Skeletron when used at night.");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.maxStack = 1;
            item.rare = 3;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;
        }
        public override bool CanUseItem(Player player)
        {
            return (!Main.dayTime && !NPC.AnyNPCs(NPCID.SkeletronHead));
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position);
            if(Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.SkeletronHead);
            }
            return true;
            }
        public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(154, 20);
			modRecipe.AddIngredient(68, 8);
			modRecipe.AddIngredient(86, 5);
            modRecipe.AddTile(26);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();

            ModRecipe modRecipe2 = new ModRecipe(mod);
			modRecipe2.AddIngredient(154, 20);
			modRecipe2.AddIngredient(1330, 8);
			modRecipe2.AddIngredient(1329, 5);
            modRecipe2.AddTile(26);
			modRecipe2.SetResult(this);
			modRecipe2.AddRecipe();
        }
    }
}