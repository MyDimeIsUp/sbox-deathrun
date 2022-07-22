using Sandbox;
using System.Linq;

namespace Deathrun.Rounds;
public class WinState: Round {
	public override string RoundId { get; set; } = "waiting";
	public override string RoundName { get; set; } = "Waiting";

	/// <summary>
	/// Determine the winning team
	/// </summary>
	public override void StateStart() {
		Log.Info( "END ROUND" );
	}
}
