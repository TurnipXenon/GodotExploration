namespace GodotExploration.Scripts.Common;

public static class ResourcePaths
{
	private const string BasePath = "res://Scripts/Scenes";
	public static class SimplePong
	{
		private const string SimplePongBasePath = $"{BasePath}/simple_pong";
		public static class Menu
		{
			private const string MenuBasePath = $"{SimplePongBasePath}/menu";
			public const string PongMenuScene = $"{MenuBasePath}/PongMenu.tscn";
		}
	}
}
