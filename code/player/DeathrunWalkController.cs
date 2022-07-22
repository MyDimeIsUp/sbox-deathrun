using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace Deathrun; 
public partial class DeathrunWalkController : WalkController {
	[Net]
	public bool DisableWalkMovement { get; set; } = false;

	public override float GetWishSpeed() {
		if ( DisableWalkMovement ) return 0;

		return base.GetWishSpeed();
	}
}
