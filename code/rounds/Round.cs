using Sandbox;

namespace Deathrun.Rounds {
	public abstract partial class Round : BaseNetworkable {
		public virtual string RoundId { get; set; } = "base";
		public virtual string RoundName { get; set; } = "BASE ROUND";

		public virtual void StateStart() {

		}

		public virtual void Tick() {

		}

		public virtual void StateEnd() {

		}
	}
}
