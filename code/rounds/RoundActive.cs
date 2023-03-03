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
			foreach ( var client in Game.Clients) {
				if ( client.Pawn is DeathrunPlayer player && player.Controller is DeathrunWalkController controller ) {
					controller.DisableWalkMovement = false;	
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

		}
	}
}
