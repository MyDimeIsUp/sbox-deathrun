using Sandbox;

namespace Deathrun;

partial class DeathrunPlayer : Player {
	[Net]
	public string Team { get; set; } = "Runner";

	public override void Respawn() {
		SetModel( "models/citizen/citizen.vmdl" );

		Controller = new WalkController();
		Animator = new StandardPlayerAnimator();
		CameraMode = new FirstPersonCamera();

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		base.Respawn();
	}

	public override void Simulate( Client cl ) {
		base.Simulate( cl );

		TickPlayerUse();
	}
}
