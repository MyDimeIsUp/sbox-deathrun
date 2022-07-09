using Sandbox;
// using System.Reflection;
using System.Collections.Generic;

namespace Deathrun.Rounds {
	public partial class RoundHandler : BaseNetworkable {
		Dictionary<string, Round> Rounds = new Dictionary<string, Round>();

		[Net]
		Round ActiveState { get; set; }

		public RoundHandler() {
			Round WaitingState = new WaitingState();
			Round PrepState = new RoundPrep();
			Round RoundActive = new RoundActive();

			Rounds.Add( WaitingState.RoundId, WaitingState );
			Rounds.Add( PrepState.RoundId, PrepState );
			Rounds.Add( RoundActive.RoundId, RoundActive );
		}

		public void SwitchState( Round round ) {
			if ( !Rounds.ContainsKey( round.RoundId ) ) {
				Log.Error( $"Attempted to switch round state to invalid ID: {round.RoundId}" );
				return;
			}

			Log.Info( $"Attempting to change round to {round.RoundId}" );

			ActiveState?.StateEnd();
			ActiveState = round;

			ActiveState.StateStart();
		}

		public Round GetActiveState() {
			return ActiveState;
		}
	}
}
