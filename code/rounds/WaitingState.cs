using Sandbox;
using System.Linq;

namespace Deathrun.Rounds {
	public class WaitingState : Round {
		public override string RoundId { get; set; } = "waiting";
		public override string RoundName { get; set; } = "Waiting";

		/// <summary>
		/// Initial method that is run when the round state is changed
		/// </summary>
		public override void StateStart() {

		}


		public override void Tick() {
			base.Tick();

			if ( Entity.All.OfType<Pawn>().Count() >= 2 ) {
				GameCore.Instance.RoundHandler.SwitchState( "round_prep" );
			}
		}
	}
}
