using Microsoft.Xna.Framework;
using ReducedGrinding.Configuration;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ReducedGrinding.Common
{
    public class LocatorInfoArrows : GlobalInfoDisplay
    {
        public override void ModifyDisplayParameters(InfoDisplay currentDisplay, ref string displayValue, ref string displayName, ref Color displayColor, ref Color displayShadowColor)
        {
            if (!GetInstance<OtherConfig>().LocatingInfoShowsDirection)
            {
                return;
            }
            Vector2 playerPos;
            if (displayName == Language.GetTextValue("LegacyInterface.105"))
            {
                if (displayValue == Language.GetTextValue("GameUI.NoRareCreatures"))
                {
                    return;
                }
                Player player = Main.LocalPlayer;
                if (!Main.npc[player.accCritterGuideNumber].active)
                {
                    return;
                }

                playerPos = Main.LocalPlayer.position;
                Vector2 npcPosition = Main.npc[player.accCritterGuideNumber].position;
                displayValue = AddArrow(displayValue, playerPos, npcPosition);
                return;
            }
            if (displayName != Language.GetTextValue("LegacyInterface.104") ||
                displayValue == Language.GetTextValue("GameUI.NoTreasureNearby") ||
                !Main.SceneMetrics.ClosestOrePosition.HasValue)
            {
                return;
            }

            Point sceneMetricsTreasurePos = Main.SceneMetrics.ClosestOrePosition.Value;
            Tile sceneMetricsTreasureTile = Framing.GetTileSafely(sceneMetricsTreasurePos);
            if (!sceneMetricsTreasureTile.HasTile)
            {
                return;
            }

            FindActualClosestTreasure(out playerPos, sceneMetricsTreasurePos, sceneMetricsTreasureTile, out Vector2 treasurePosition);

            displayValue = AddArrow(displayValue, playerPos, treasurePosition);
        }

        private static void FindActualClosestTreasure(out Vector2 playerPos, Point sceneMetricsTreasurePos, Tile sceneMetricsTreasureTile, out Vector2 treasurePosition)
        {
            //ClosestOrePosition doesn't actually get the closest tile, so we need to find the actual closest tile, with the same type.
            int tileType = sceneMetricsTreasureTile.TileType;
            playerPos = Main.LocalPlayer.Center;
            List<Vector2> treasureTilePositions = [];
            for (int x = playerPos.ToTileCoordinates().X - 85; x < playerPos.ToTileCoordinates().X + 86; x++)
            {
                for (int y = playerPos.ToTileCoordinates().Y - 63; y < playerPos.ToTileCoordinates().Y + 64; y++)
                {
                    Tile searchTileSafely = Framing.GetTileSafely(x, y);
                    if (!searchTileSafely.HasTile)
                    {
                        continue;
                    }
                    if (searchTileSafely.TileType == tileType)
                    {
                        treasureTilePositions.Add(new Vector2(x, y));
                    }
                }
            }

            Vector2 closestTreasureTile = new(-1, -1);
            if (treasureTilePositions.Count > 0)
            {
                float distanceToTreasureTile = playerPos.Distance(treasureTilePositions[0].ToWorldCoordinates());
                closestTreasureTile = treasureTilePositions[0];
                foreach (Vector2 treasureTilePosition in treasureTilePositions)
                {
                    if (playerPos.Distance(treasureTilePosition.ToWorldCoordinates()) >= distanceToTreasureTile)
                    {
                        continue;
                    }
                    distanceToTreasureTile = playerPos.Distance(treasureTilePosition.ToWorldCoordinates());
                    closestTreasureTile = treasureTilePosition;
                }
            }
            if (closestTreasureTile.X == -1)
            {
                treasurePosition = sceneMetricsTreasurePos.ToVector2().ToWorldCoordinates();
            }
            else
            {
                treasurePosition = closestTreasureTile.ToWorldCoordinates();
            }
        }

        private static string AddArrow(string displayValue, Vector2 playerPosition, Vector2 objectPosition)
        {
            if (Math.Abs(objectPosition.X - playerPosition.X) > Math.Abs(objectPosition.Y - playerPosition.Y))
            {
                if (objectPosition.X < playerPosition.X)
                {
                    return ReducedGrinding.GetText("Misc.TriangularArrows.Left") + displayValue;
                }
                else
                {
                    return ReducedGrinding.GetText("Misc.TriangularArrows.Right") + displayValue;
                }
            }
            else
            {
                if (objectPosition.Y < playerPosition.Y)
                {
                    return ReducedGrinding.GetText("Misc.TriangularArrows.Up") + displayValue;
                }
                else
                {
                    return ReducedGrinding.GetText("Misc.TriangularArrows.Down") + displayValue;
                }
            }
        }
    }
}
