using Terraria.ID;
using Terraria.ModLoader;

namespace SpearOverhaul.Projectiles;

public class ExplosionBig : ModProjectile
{
	public override void SetStaticDefaults()
	{
		// base.DisplayName.SetDefault("Explosion");
		ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 4;
		ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		base.Projectile.width = 16;
		base.Projectile.DamageType = DamageClass.Melee;
		base.Projectile.height = 16;
		base.Projectile.aiStyle = 612;
		base.Projectile.friendly = true;
		base.Projectile.hostile = false;
		base.Projectile.DamageType = DamageClass.Magic;
		base.Projectile.penetrate = 3751057;
		base.Projectile.light = 0f;
		base.Projectile.ignoreWater = true;
		base.Projectile.extraUpdates = 1;
		base.Projectile.width = 96;
		base.Projectile.height = 96;
		base.Projectile.timeLeft = 1;
		base.Projectile.tileCollide = false;
		base.Projectile.alpha = 125;
		base.Projectile.scale = 0.75f;
		base.Projectile.friendly = true;
		base.Projectile.hostile = false;
	}
}
