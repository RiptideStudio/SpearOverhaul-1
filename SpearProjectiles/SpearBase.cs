using Microsoft.Xna.Framework;
using SpearOverhaul.GlobalStuff;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.SpearProjectiles
{
    public abstract class SpearBase : ModProjectile
    {
        // Define the range of the Spear Projectile. These are overridable properties, in case you'll want to make a class inheriting from this one.
        protected virtual float HoldoutRangeMin => 24f;
        protected virtual float HoldoutRangeMax => 96f;
        protected bool HasReachedHalfway = false; // whether our spear is retracting or not
        protected virtual bool CanShootProjectile { get; set; } = false; // whether or not this spear can shoot a projectile
        protected virtual string projectile => ""; // the projectile the spear shoots, set as a string name for now
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Spear); // Clone the default values for a vanilla spear. Spear specific values set for width, height, aiStyle, friendly, penetrate, tileCollide, scale, hide, ownerHitCheck, and melee.
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner]; // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            int duration = player.itemAnimationMax; // Define the duration the projectile will exist in frames

            player.heldProj = Projectile.whoAmI; // Update the player's held projectile id

            // Reset projectile time left if necessary
            if (Projectile.timeLeft > duration)
            {
                Projectile.timeLeft = duration;
            }

            Projectile.velocity = Vector2.Normalize(Projectile.velocity); // Velocity isn't used in this spear implementation, but we use the field to store the spear's attack direction.

            float halfDuration = duration * 0.5f;
            float progress;

            // Here 'progress' is set to a value that goes from 0.0 to 1.0 and back during the item use animation.
            if (Projectile.timeLeft < halfDuration)
            {
                progress = Projectile.timeLeft / halfDuration;
            }
            else
            {
                progress = (duration - Projectile.timeLeft) / halfDuration;
            }

            if (player.itemAnimation < player.itemAnimationMax / 3)
            {
                // Some spears have a projectile they shoot when retracting
                if (CanShootProjectile && !HasReachedHalfway)
                {
                    Projectile.NewProjectile(base.Projectile.GetSource_Death(), base.Projectile.Center.X + base.Projectile.velocity.X * -4f, base.Projectile.Center.Y + base.Projectile.velocity.Y * -4f, base.Projectile.velocity.X * 2, base.Projectile.velocity.Y * 2, base.Mod.Find<ModProjectile>(projectile).Type, base.Projectile.damage, base.Projectile.knockBack / 2f, player.whoAmI);
                    HasReachedHalfway = true;
                }
            }

            GlobalProj.SpearHoming(Projectile, 1f);
            // Move the projectile from the HoldoutRangeMin to the HoldoutRangeMax and back, using SmoothStep for easing the movement
            Projectile.Center = player.MountedCenter + Vector2.SmoothStep(Projectile.velocity * HoldoutRangeMin, Projectile.velocity * HoldoutRangeMax, progress);

            // Apply proper rotation to the sprite.
            if (Projectile.spriteDirection == -1)
            {
                // If sprite is facing left, rotate 45 degrees
                Projectile.rotation += MathHelper.ToRadians(45f);
            }
            else
            {
                // If sprite is facing right, rotate 135 degrees
                Projectile.rotation += MathHelper.ToRadians(135f);
            }

            return false; // Don't execute vanilla AI.
        }
    }
}
