using StardewModdingAPI;
using StardewValley;
using StardewValley.Tools;
using System;

// Taken from:
// https://raw.githubusercontent.com/KilZenc/Stardew-SMAPI-Mods/6b23ee04ba06e2c4b9693944bb28ca774bb71d0c/FishingAssistant/Framework/SFishingRod.cs
namespace FishingAutomator
{
    internal partial class ModEntry : Mod
    {
        private FishingRod fishingRod;

        private bool IsRodBobberStillInAir
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.castedButBobberStillInAir;
            }
        }

        private bool IsRodCasting
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.isCasting;
            }
        }

        private bool IsRodFishCaught
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.fishCaught;
            }
            set
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                fishingRod.fishCaught = value;
            }
        }

        private bool IsRodFishing
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.isFishing;
            }
        }

        private bool IsRodHit
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.hit;
            }
        }

        private bool IsRodInUse
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.inUse();
            }
        }

        private bool IsRodNibbing
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.isNibbling;
            }
        }

        private bool IsRodPullingOutOfWater
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.pullingOutOfWater;
            }
        }

        private bool IsRodReeling
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.isReeling;
            }
        }

        private bool IsRodShowingTreasure
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.showingTreasure;
            }
            set
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                fishingRod.showingTreasure = value;
            }
        }

        private bool IsRodTimingCasting
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.isTimingCast;
            }
        }

        private bool IsRodTreasureCaught
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.treasureCaught;
            }
        }

        private float RodCastPower
        {
            set
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                fishingRod.castingPower = value;
            }
        }

        private float RodTimeUntilFishBite
        {
            get
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                return fishingRod.timeUntilFishingBite;
            }
            set
            {
                if (fishingRod == null) throw new NullReferenceException(nameof(fishingRod));
                fishingRod.timeUntilFishingBite = value;
            }
        }

        /// <summary>Is player able to cast fishing rod</summary>
        /// <returns>True if player can cast fishing rod</returns>
        private bool RodIsNotInUse()
        {
            return Context.CanPlayerMove && Game1.activeClickableMenu == null && !fishingRod.inUse();
        }

        /// <summary>Is fish bite or not</summary>
        /// <returns>True if fish bite</returns>
        private bool IsRodCanHook(FishingRod rod)
        {
            fishingRod = rod;
            return IsRodNibbing && !IsRodReeling && !IsRodHit && !IsRodPullingOutOfWater && !IsRodFishCaught;
        }

        /// <summary>Is player currenly showing fish</summary>
        /// <returns>True if fish popup is show</returns>
        private bool IsRodShowingFish()
        {
            return !Context.CanPlayerMove && IsRodFishCaught && IsRodInUse && !IsRodCasting && !IsRodTimingCasting && !IsRodReeling && !IsRodPullingOutOfWater && !IsRodShowingTreasure;
        }
    }
}
