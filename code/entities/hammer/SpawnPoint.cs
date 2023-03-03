using Sandbox;
using Editor;

namespace Deathrun.Entites.Hammer {
	[Library( "info_player_spawn_death" ), HammerEntity]
	[EditorModel( "models/editor/playerstart.vmdl", FixedBounds = true )]
	[Title( "Death Spawnpoint" ), Category( "Player" ), Icon( "place" ), Description("Defines the spawn point for those who are a Death.")]
	public class SpawnPointDeath : Entity {

	}
}
