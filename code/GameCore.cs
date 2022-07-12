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

		/// <summary>
		/// Called each tick.
		/// Serverside: Called for each client every tick
		/// Clientside: Called for each tick for local client. Can be called multiple times per tick.
		/// </summary>
		public override void Simulate( Client cl ) {
			if ( !cl.Pawn.IsValid() ) return;

			// Block Simulate from running clientside
			// if we're not predictable.
			if ( !cl.Pawn.IsAuthority ) return;

			cl.Pawn.Simulate( cl );
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


		[Event.Hotload]
		public void HotloadUpdate() {
			if ( !IsClient ) return;

			HudManager?.Delete();
			HudManager = new HudManager();

			Log.Info( "Created new HUD Hotload" );
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
