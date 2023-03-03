using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;

namespace Deathrun;

public partial class HudManager : Sandbox.HudEntity<RootPanel> {
	public HudManager() {
		if (Game.IsServer) { return; }

		RootPanel.AddChild<RoleVitalsBox>();
		RootPanel.AddChild<ChatBox>();
	}
}
