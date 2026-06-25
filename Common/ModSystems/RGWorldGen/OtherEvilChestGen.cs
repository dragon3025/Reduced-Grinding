using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;

namespace ReducedGrinding.Common.ModSystems
{
    public partial class RGWorldGen
    {
        public class OtherEvilChestGen(string name, float loadWeight) : GenPass(name, loadWeight)
        {
            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {
                if (WorldGen.drunkWorldGen)
                {
                    return;
                }
                progress.Message = ReducedGrinding.GetText("Misc.WorldGeneration.OtherEvilChestGen");

                bool placedChest = false;
                while (!placedChest)
                {
                    int positionX = WorldGen.genRand.Next(GenVars.dMinX, GenVars.dMaxX);
                    int positionY = WorldGen.genRand.Next((int)Main.worldSurface, GenVars.dMaxY);
                    if (!Main.wallDungeon[Main.tile[positionX, positionY].WallType] || Main.tile[positionX, positionY].HasTile)
                    {
                        continue;
                    }

                    int contain;
                    int style;
                    if (WorldGen.crimson)
                    {
                        style = 24;
                        contain = ItemID.ScourgeoftheCorruptor;
                    }
                    else
                    {
                        style = 25;
                        contain = ItemID.VampireKnives;
                    }
                    placedChest = WorldGen.AddBuriedChest(positionX, positionY, contain, false, style, false, 21);
                }
            }
        }
    }
}