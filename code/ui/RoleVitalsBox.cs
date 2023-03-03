using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;
using Deathrun.Rounds;

namespace Deathrun;

[UseTemplate]
public partial class RoleVitalsBox : Panel {
	private Color HealthBarContainerColor = new Color( 0.78f, 0.2f, 0.2f );
	private Color HealthBarColor = new Color( 0.39f, 0.2f, 0.2f );

	private Panel RoleContainer { get; set; }
	private Panel HealthBar { get; set; }
	private Panel HealthBarContainer { get; set; }
	private Panel HealthTextPanel { get; set; }
	private Panel HealthAmmoContainer { get; set; }
	private string HealthText { get; set; }
	private string PlayerName { get; set; }

	public override void Tick() {
		if ( Game.LocalPawn is not DeathrunPlayer player ) return;

		PlayerName = player.Team;

		if ( GameCore.Instance.RoundHandler.GetActiveState().RoundId == "waiting" ) {
			PlayerName = "Waiting";
			RoleContainer.AddClass( "waiting" );
			HealthAmmoContainer.RemoveClass( "hidden" );
		} else if (player.LifeState == LifeState.Dead) {
			PlayerName = "In Progress";
			RoleContainer.RemoveClass( "waiting" );
			HealthAmmoContainer.AddClass( "hidden" );
			RoleContainer.AddClass( "dead" );
		} else {
			PlayerName = player.Team;
			RoleContainer.RemoveClass( "waiting" );
			HealthAmmoContainer.RemoveClass( "hidden" );
			RoleContainer.AddClass( player.Team );
		}

		if ( player.Health == 100 ) {
			HealthTextPanel.Style.Opacity = 0;

			HealthBarContainer.Style.Height = 5;
			HealthBarContainer.Style.BackgroundColor = HealthBarContainerColor;

			HealthBar.Style.Width = Length.Percent( player.Health );
		} else {
			// Handle health text display
			HealthTextPanel.Style.Opacity = 1;
			HealthText = $"{player.Health.CeilToInt()}";

			HealthBarContainer.Style.Height = 40;
			HealthBarContainer.Style.BackgroundColor = HealthBarColor;

			HealthBar.Style.Width = Length.Percent( player.Health );
		}

		base.Tick();
	}
}
