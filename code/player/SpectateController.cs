using Sandbox;

namespace Deathrun;

public partial class SpectateController : BasePlayerController {
	public override void Simulate() {
		WishVelocity = Velocity;
		GroundEntity = null;
		BaseVelocity = Vector3.Zero;
	}
}
