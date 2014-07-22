#region Copyright & License Information
/*
 * Copyright 2007-2011 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 */
#endregion

using OpenRA.Traits;

namespace OpenRA.Mods.RA
{
	[Desc("Fires a weapon at the location when collected.")]
	class ExplodeCrateActionInfo : CrateActionInfo
	{
		[Desc("The weapon to fire upon collection.")]
		[WeaponReference] public string Weapon = null;

		public override object Create(ActorInitializer init) { return new ExplodeCrateAction(init.self, this); }
	}

	class ExplodeCrateAction : CrateAction
	{
		public ExplodeCrateAction(Actor self, ExplodeCrateActionInfo info)
			: base(self, info) {}

		public override void Activate(Actor collector)
		{
			Combat.DoExplosion(self, ((ExplodeCrateActionInfo)info).Weapon, collector.CenterPosition);
			base.Activate(collector);
		}
	}
}
