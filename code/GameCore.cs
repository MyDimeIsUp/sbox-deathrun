using Sandbox;
using Deathrun.Rounds;

namespace Deathrun {
	public partial class GameCore : Game {
		public static GameCore Instance => Current as GameCore;
		public HudManager HudManager;

		[Net]
		public RoundHandler RoundHandler { get; private set; }

		public GameCore() {
			RoundHandler = new RoundHandler();

			if ( IsServer ) {
				HudManager = new HudManager();

				RoundHandler.SwitchState( new WaitingState() );
			}
		}

		[Event.Hotload]
		public void HotloadUpdate() {
			if ( !IsClient ) return;

			HudManager?.Delete();
			HudManager = new HudManager();

			Log.Info( "Created new HUD Hotload" );
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client ) {
			base.ClientJoined( client );

			// Create a pawn and assign it to the client.
			var player = new DeathrunPlayer();
			client.Pawn = player;

			player.Respawn();
		}

		[Event.Tick.Server]
		public void Tick() {
			Round ActiveState = RoundHandler.GetActiveState();

			ActiveState.Tick();
		}

		[ConCmd.Server( "deathrun_getactivestate" )]
		public static void GetActiveState() {
			Log.Info( Instance.RoundHandler.GetActiveState() );
		}

		[ConCmd.Client( "deathrun_getactivestate_client" )]
		public static void GetActiveStateClient() {
			Log.Info( Instance.RoundHandler.GetActiveState() );
		}
	}
}
