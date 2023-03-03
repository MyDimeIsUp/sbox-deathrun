using Sandbox;

namespace Deathrun;

partial class DeathrunPlayer : Player {
	[Net]
	public string Team { get; set; } = "Runner";
	TimeSince _timeSinceDeath;

	public override void Respawn() {
		SetModel( "models/citizen/citizen.vmdl" );

		Controller = new DeathrunWalkController();
		//Animator = new StandardPlayerAnimator();
		//CameraMode = new FirstPersonCamera();

		EnableAllCollisions = true;
		EnableDrawing = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;

		base.Respawn();
	}

	public override void OnKilled() {
		base.OnKilled();

		_timeSinceDeath = 0;
	}

	/// <summary>
	/// Handles player every tick. Do not call base since it will result in a respawn 3 secs after death
	/// </summary>
	/// <param name="cl"></param>
	public override void Simulate( IClient cl ) {
		if ( cl.Pawn is not Player player ) return;

		if ( LifeState == LifeState.Dead &&  player.Controller is not SpectateController) {
			// Prevent any movement if we are dead and not in spectator cam mode
			if ( _timeSinceDeath >= 3 && Game.IsServer ) {
				player.Controller = new SpectateController();
			}

			return;
		}

		TickPlayerUse();
	}
}
