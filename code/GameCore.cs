using Sandbox;
using Deathrun.Rounds;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Deathrun {

	/// <summary>
	/// This is your game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	/// 
	/// You can use this to create things like HUDs and declare which player class
	/// to use for spawned players.
	/// </summary>
	public partial class GameCore : Game
	{
		public static GameCore Instance => Current as GameCore;
		public RoundHandler RoundHandler;

		public GameCore()
		{
			RoundHandler = new RoundHandler();

			if (IsServer)
			{
				RoundHandler.SwitchState( "waiting" );
			}
		}


		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			// Create a pawn and assign it to the client.
			var player = new Pawn();
			client.Pawn = player;

			player.Respawn();
		}

		[Event.Tick.Server]
		public void Tick()
		{
			Round ActiveState = RoundHandler.GetActiveState();

			Log.Info( $"Current state is {ActiveState.RoundName}" );

			ActiveState.Tick();
		}
	}
}
