using Sandbox;
using System.Linq;
using System.Collections.Generic;

namespace Deathrun.Rounds {
	public class RoundActive : Round {
		public override string RoundId { get; set; } = "active";
		public override string RoundName { get; set; } = "Active";

		/// <summary>
		/// Initial method that is run when the round state is changed
		/// </summary>
		public override void StateStart() {
			foreach ( var client in Client.All ) {
				if ( client.Pawn is DeathrunPlayer player ) {
					player.Controller = new WalkController();
				}
			}
		}


		/// <summary>
		/// Check for win state and check if we can still have an active round
		/// </summary>
		public override void Tick() {
			base.Tick();

			CheckForWin();
		}

		/// <summary>
		/// Checks for a win condition. Returns true if all deaths or all runners are alive
		/// </summary>
		/// <returns></returns>
		public void CheckForWin() {
			List<DeathrunPlayer> PlayersInRound = new();

			foreach ( var client in Client.All ) {
				if ( client.Pawn is DeathrunPlayer player ) {
					PlayersInRound.Add( player );
				}
			}
		}
	}
}
