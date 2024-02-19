using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Projectiles;

public class SporeCloud : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Spore Cloud");
		ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
		Main.projFrames[base.Projectile.type] = 5;
	}

	public override void SetDefaults()
	{
		base.Projectile.arrow = true;
		base.Projectile.aiStyle = 612;
		base.Projectile.friendly = true;
		base.Projectile.hostile = false;
		base.Projectile.DamageType = DamageClass.Magic;
		base.Projectile.penetrate = 1;
		base.Projectile.light = 0.25f;
		base.Projectile.ignoreWater = true;
		base.Projectile.width = 16;
		base.Projectile.height = 16;
		base.Projectile.timeLeft = 60;
		base.Projectile.tileCollide = false;
	}

	public override void AI()
	{
		if (++base.Projectile.frameCounter >= 6)
		{
			base.Projectile.frameCounter = 0;
			if (++base.Projectile.frame > 4)
			{
				base.Projectile.frame = 0;
			}
		}
		base.Projectile.velocity.X = 0f;
		base.Projectile.velocity.Y = 0f;
		if (base.Projectile.timeLeft < 30)
		{
			base.Projectile.alpha += 4;
		}
	}
}
