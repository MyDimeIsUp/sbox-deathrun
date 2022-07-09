using Deathrun.Entites.Hammer;
using Sandbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deathrun.Rounds;

public class RoundPrep : Round {
	public override string RoundId { get; set; } = "round_prep";
	public override string RoundName { get; set; } = "Preparing";

	/// <summary>
	/// Initial method that is run when the round state is changed
	/// </summary>
	public override async void StateStart() {
		List<DeathrunPlayer> PlayersInRound = new();
		IEnumerable<SpawnPointDeath> SpawnPoints = Entity.All
			.OfType<SpawnPointDeath>();              // get all death spawnpoints

		// Add players to list and disable their input due to pre-round timer. Set default team to Runner
		foreach ( var client in Client.All ) {
			if ( client.Pawn is DeathrunPlayer player ) {
				PlayersInRound.Add( player );
				player.Controller = null;
				player.Team = "Runner";
			}
		}

		// Randomize list
		PlayersInRound = PlayersInRound.OrderBy( x => Guid.NewGuid() ).ToList();

		// Now set our players to be death and set their pos
		for ( int i = 0; i < Math.Ceiling( PlayersInRound.Count * 0.15 ); i++ ) {
			PlayersInRound[i].Team = "Death";
			PlayersInRound[i].Transform = SpawnPoints.ElementAt( 0 ).Transform;

			Log.Info( $"{PlayersInRound[i].Client.Name} has been made a Death" );
		}

		await GameTask.RunInThreadAsync(BeginRound);
	}

	/// <summary>
	/// Returns player input and if players haven't left, switch round state to RoundActive
	/// </summary>
	/// <returns></returns>
	public async Task BeginRound() {
		await GameTask.Delay(3500);
		GameCore.Instance.RoundHandler.SwitchState( new RoundActive() );
	}
}
