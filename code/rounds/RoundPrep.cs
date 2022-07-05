using Sandbox;
using System.Linq;

namespace Deathrun.Rounds
{
	public class RoundPrep : Round
	{
		public override string RoundId { get; set; } = "round_prep";
		public override string RoundName { get; set; } = "Preparing";

		/// <summary>
		/// Initial method that is run when the round state is changed
		/// </summary>
		public override void StateStart()
		{
			if ( Entity.All.OfType<Pawn>().Count() >= 2 )
			{
				GameCore.Instance.RoundHandler.SwitchState( "round_prep" );
			}
		}
	}
}
