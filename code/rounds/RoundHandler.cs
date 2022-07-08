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

			Rounds.Add( WaitingState.RoundId, WaitingState );
			Rounds.Add( PrepState.RoundId, PrepState );
		}

		public void SwitchState( string RoundId ) {
			if ( !Rounds.ContainsKey( RoundId ) ) {
				Log.Error( $"Attempted to switch round state to invalid ID: {RoundId}" );
				return;
			}

			Log.Info( $"Attempting to change round to {RoundId}" );

			ActiveState?.StateEnd();
			ActiveState = Rounds[RoundId];

			ActiveState.StateStart();
		}

		public Round GetActiveState() {
			return ActiveState;
		}
	}
}
